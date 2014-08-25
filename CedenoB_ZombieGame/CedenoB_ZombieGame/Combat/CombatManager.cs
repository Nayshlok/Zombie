using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieApocalypseSimulator;
using zombieApocalypse.Model;

namespace zombieApocalypse.Combat
{
    enum Defense
    {
        Dodge, Parry, None
    }

    class CombatManager
    {
        private readonly Dice D20 = new Dice(1, 20);
        private bool isCritSuccess, isDefendCrit, isDefendFail, botchDefend;
        private int MeleePSBonus;
        private int MeleePPBonus;
        private Character attacker, defender;
        private CombatResults results;

        /// <summary>
        /// The only method that can be called outside the class. It will take in two Character objects and try to battle them.
        /// This method is responsible for subtracting the actual damage from the Character SDC or HP property.
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="defender"></param>
        /// <returns>A boolean that represents that damage was dealt in combat.</returns>
        public CombatResults startCombat(Character attacker, Character defender)
        {
            results = new CombatResults();
            if ((attacker is Player && defender is Player)
                || (attacker is Zed && defender is Zed))
            {
                results.Allies = true;
                results.Message = "The combatants are allies";
                return results;
            }
            else
            {
                this.attacker = attacker;
                this.defender = defender;
                setAttackerBonuses();
                bool attackHit = confirmHit();
                results.AttackHit = attackHit;
                if (attackHit)
                {
                    bool damageHP = false;
                    if (attacker is Zed)
                    {
                        damageHP = (((Zed)attacker) is Shank) ? true : false;
                    }
                    int damage = damageDone();
                    results.Damage = damage;
                    if (defender.SCD >= damage && !damageHP)
                    {
                        defender.SCD -= damage;
                    }
                    else if (defender.SCD < damage && defender.SCD > 0 && !damageHP)
                    {
                        damage -= defender.SCD;
                        defender.SCD = 0;
                        defender.HP -= damage;
                    }
                    else
                    {
                        defender.HP -= damage;
                    }
                    return results;
                }
                else
                {
                    results.Message = "Attack missed";
                    return results;
                }
            }
        }

        public void testCombat(Character attacker, Character defender)
        {
            this.attacker = attacker;
            this.defender = defender;
            this.isCritSuccess = true;
            setAttackerBonuses();
        }

        /// <summary>
        /// Called to find what bonuses apply to the attackers damage and chance to hit, using the Characters
        /// PP and PS properties.
        /// </summary>
        private void setAttackerBonuses()
        {
            MeleePSBonus = 0;
            MeleePPBonus = 0;
            if (attacker is Player)
            {
                Weapon attackerWeapon = ((Player)attacker).inventory.equippedWeapon;
                if (attackerWeapon is MeleeWeapon)
                {
                    MeleePPBonus = ((attacker.PP - 14) / 2);
                    if (MeleePPBonus < 0)
                    {
                        MeleePPBonus = 0;
                    }
                    MeleePSBonus = (attacker.PS - 15);
                    if (MeleePSBonus < 0)
                    {
                        MeleePSBonus = 0;
                    }
                }
            }
            else
            {
                if (!((Zed)attacker is Spitter))
                {
                    MeleePPBonus = ((attacker.PP - 14) / 2);
                    if (MeleePPBonus < 0)
                    {
                        MeleePPBonus = 0;
                    }
                    MeleePSBonus = (attacker.PS - 15);
                    if (MeleePSBonus < 0)
                    {
                        MeleePSBonus = 0;
                    }
                }
            }
        }

        /// <summary>
        /// This method will determine whether the attacker is able to sccussfully hit the target. It is also responsible for setting the 
        /// isCritSuccess field. Once an attack chance is determined it calculates the number that the attacker has to beat, based on the defender's
        /// AR, and defense chance.
        /// </summary>
        /// <returns></returns>
        private bool confirmHit()
        {

            int baseRoll = D20.Roll();
            isCritSuccess = (baseRoll == 20) ? true : false;
            results.AttackCrit = isCritSuccess;

            if (baseRoll == 1)
            {
                results.AttackFail = true;
                return false;
            }
            int strike = MeleePPBonus;

            strike += attacker.Strike;
            int toHit = baseRoll + strike;
            if (attacker is Player)
            {
                toHit += ((Player)attacker).bonusToHit();
            }

            results.AttackRoll = toHit;

            int AR = 4;
            if (defender is Player)
            {
                if ((Player)defender is Warrior)
                {
                    AR += 2;
                }
            } 
            if(defender is Zed)
            {
                Player tempPlayer = (Player)attacker;
                if (!tempPlayer.inventory.equippedWeapon.ignoreAR)
                {
                    AR += 10;
                }
            }
            int defendAttempt = defendChance();

            results.DefendRoll = defendAttempt;

            if (toHit > AR || isDefendFail)
            {
                botchDefend = (toHit > AR && isDefendFail) ? true : false;

                if ((toHit > defendAttempt && !isDefendCrit) || isDefendFail || (isCritSuccess && !isDefendCrit))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Calculates the defender's chance to defend, which is compared to the attacker's chance to hit in the confirmHit method.
        /// </summary>
        /// <returns></returns>
        private int defendChance()
        {
            Defense defendOption = defenseChoice();
            results.DefenseType = defendOption;
            if (defendOption != Defense.None)
            {
                int defense = D20.Roll();
                isDefendCrit = (defense == 20) ? true : false;
                results.DefendCrit = isDefendCrit;

                isDefendFail = (defense == 1) ? true : false;
                results.DefendFail = isDefendFail;

                if (defendOption == Defense.Parry && defender is Player)
                {
                    if ((Player)defender is Warrior)
                        defense += 2;
                }

                if (defender.PP >= 15)
                {
                    defense += ((defender.PP - 14) / 2);
                }
                return defense;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Determines the defending actions a defender can take. Picks in order, Parry, Dodge, or none if no defense is available.
        /// </summary>
        /// <returns></returns>
        private Defense defenseChoice()
        {
            bool tankAttack = false;
            if (attacker is Zed)
            {
                tankAttack = ((Zed)attacker is Tank) ? true : false;
            }

            if (defender.canParry && !tankAttack)
            {
                defender.canParry = false;
                return Defense.Parry;
            }
            else if (defender.CanDodge)
            {
                defender.CanDodge = false;
                return Defense.Dodge;
            }
            else
            {
                return Defense.None;
            }
        }

        /// <summary>
        /// Calculates the damage done in case of a successful hit, it takes the bonus determined in setAttackerBonus() and the Character's
        /// strike property, plus the base damage of Zed or Player Weapon.
        /// </summary>
        /// <returns></returns>
        private int damageDone()
        {
            int damage = MeleePSBonus;
            if (attacker is Player)
            {
                Player tempPlayer = (Player)attacker;
                damage += tempPlayer.inventory.equippedWeapon.baseDamage.Roll();
                damage += tempPlayer.inventory.equippedWeapon.BonusDamage;
            }
            else
            {
                Zed tempZed = (Zed)attacker;
                damage += tempZed.BaseDamage.Roll();
                damage += tempZed.BonusDamage;
            }

            damage *= (isCritSuccess) ? 2 : 1;
            damage *= (botchDefend) ? 2 : 1;

            return damage;
        }

        /// <summary>
        /// Used to determine if damage will bypass SDC and be subtracted from Character's HP property.
        /// </summary>
        /// <returns></returns>
        private bool pierceDamage()
        {
            bool isPierce = false;

            isPierce = (attacker is Zed && ((Zed)attacker) is Shank) ? true : false;
            
            return isPierce;
        }
    }
}
