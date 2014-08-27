using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieApocalypseSimulator;

namespace CedenoB_ZombieGame.UnitMovement
{
    public class Movement
    {
        static Random rand = new Random();

        public List<Square> characterList = new List<Square>();

        public Square[,] grid = new Square[25, 25];

        int[] selected = new int[2];

        readonly int pickUpItem = 2;
        readonly int dropItem = 1;
        readonly int giveItem = 3;
        //Melee Attacks cost half total squares
        //Aimed Ranged Attacks cost ALL of the squares
        //Un-Aimed Ranged Attackes cost half total squares

        int totalSquaresMoved = 5;

        ////////static void Main(string[] args)
        ////////{
        ////////    (new Program()).Run();
        ////////}

        #region run()
        public void Run()
        {
            #region playerRun
            ////////////////int possible = 10;

            ////////////////for (int x = 0; x < 15; x++)
            ////////////////{
            ////////////////    for (int y = 0; y < 15; y++)
            ////////////////    {
            ////////////////        grid[x, y] = new Square();

            ////////////////        if (rand.Next(0, 2) == 1 && possible > 0)
            ////////////////        {
            ////////////////            grid[x, y].genChar(setCharacterInitiative());
            ////////////////            --possible;
            ////////////////        }
            ////////////////    }
            ////////////////}


            //////Character c;

            //////////////int[] currentLoc = new int[2];
            //////////////int[] toLoc = new int[2];


            //////////////for (int i = 0; i < 15; i++)
            //////////////{
            //////////////    for (int j = 0; j < 15; j++)
            //////////////    {
            //////////////        if (grid[i, j].c != null)
            //////////////        {
            //////////////            c = grid[i, j].c;
            //////////////            currentLoc[0] = i;
            //////////////            currentLoc[1] = j;
            //////////////            toLoc[0] = rand.Next(0, 15);
            //////////////            toLoc[1] = rand.Next(0, 15);

            //////////////            MoveCharacter(c, toLoc, currentLoc);
            //////////////        }
            //////////////    }
            //////////////}

            //////////////Console.WriteLine("Below is a list of all of the character's Initiative \n");

            //////////////checkCharactersInitiatives();

            ////genTurns();

            ////////////////////for (int x = 0; x < 15; x++)
            ////////////////////{
            ////////////////////    for (int y = 0; y < 15; y++)
            ////////////////////    {
            ////////////////////        if (grid[x, y].Token != null)
            ////////////////////        {
            ////////////////////            Console.WriteLine(grid[x, y].Token.Initiative);
            ////////////////////        }
            ////////////////////    }
            ////////////////////}

            ////////////////////Console.WriteLine("\nList Below \n\n");

            ////////////////////for (int i = 0; i < 5; i++)
            ////////////////////{
            ////////////////////    Console.WriteLine(characterList.ElementAt(i).c.Inititative);
            ////////////////////}

            ////////////////////testDropItem();
            ////////////////////testPickupItem();
            ////////////////////testGiveItem();
            #endregion

            genTurns();

            #region zedRun
            //////////////////int possibleZed = 20;

            //////////////////for (int i = 0; i < 15; i++)
            //////////////////{
            //////////////////    for (int j = 0; j < 15; j++)
            //////////////////    {
            //////////////////        if (rand.Next(0, 10) > 8 && possibleZed > 0)
            //////////////////        {
            //////////////////            --possibleZed;

            //////////////////            grid[i, j].genZed(rand.Next(1, 6));
            //////////////////        }
            //////////////////    }
            //////////////////}

            //////////////////for (int i = 0; i < 15; i++)
            //////////////////{
            //////////////////    for (int j = 0; j < 15; j++)
            //////////////////    {
            //////////////////        if (grid[i, j].c is TestModules.Zeds)
            //////////////////        {
            //////////////////            Console.WriteLine("grid[" + i + ", " + j + "] holds a Zombie of type " + ((Zeds)grid[i, j].c).t.ToString());
            //////////////////        }
            //////////////////        else if (grid[i, j].c is Character)
            //////////////////        {
            //////////////////            Console.WriteLine("grid[" + i + ", " + j + "] holds a character.");
            //////////////////        }
            //////////////////    }
            //////////////////}
            //////////////////for (int i = 0; i < 15; i++)
            //////////////////{
            //////////////////    for (int j = 0; j < 15; j++)
            //////////////////    {
            //////////////////        if (grid[i, j].c is TestModules.Zeds)
            //////////////////        {
            //////////////////            calcZedAttack(((Zeds)grid[i, j].c));
            //////////////////        }
            //////////////////    }
            //////////////////}
            #endregion

            #region CheckLineOfSight
            //////////////////bool canHit = false;
            //////////////////int[] current = new int[2];
            //////////////////int[] toHit = new int[2];

            ////////////////////for (int i = 0; i < 15; i++)
            ////////////////////{
            ////////////////////    for (int j = 0; j < 15; j++)
            ////////////////////    {
            ////////////////////        if (grid[i, j] != null)
            ////////////////////        {
            ////////////////////            current[0] = rand.Next(0, 15);
            ////////////////////            current[1] = rand.Next(0, 15);

            ////////////////////            toHit[0] = rand.Next(0, 15);
            ////////////////////            toHit[1] = rand.Next(0, 15);

            ////////////////////            canHit = checkLineOfSight(toHit, current);
            ////////////////////            Console.WriteLine("Character at [" + i + ", " + j + "] targeted \n[" + toHit[0] + ", " + toHit[1] + "] \nand the hit was " + canHit.ToString());
            ////////////////////        }
            ////////////////////    }
            ////////////////////}
            #endregion

            #region testZedItem
            ////////////////////TestZedItem t = new TestZedItem();
            ////////////////////t.run();
            #endregion
        }
        #endregion

        #region players
        #region genTurns()
        public void genTurns()
        {
            Square holder1;
            Square holder2;

            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (grid[i, j].Token != null)
                    {
                        characterList.Add(grid[i, j]);
                    }
                }
            }
            int times = 0;
            for (int s = 0; s < characterList.Count; s++)
            {
                holder1 = characterList.ElementAt(s);
                for (int i = s + 1; i < characterList.Count; i++)
                {
                    holder2 = characterList.ElementAt(i);

                    if (i != s)
                    {
                        if (holder1.Token.Initiative == holder2.Token.Initiative)
                        {
                            if (rand.Next(0, 2) == 0)
                            {
                                characterList.Insert(s, holder2);
                                characterList.RemoveAt(i + 1);
                            }
                            else
                            {
                                characterList.Insert(s + 1, holder2);
                                characterList.RemoveAt(i + 1);
                                i = i - 1;
                                holder1 = characterList.ElementAt(s);
                            }
                        }
                        else if (holder1.Token.Initiative < holder2.Token.Initiative)
                        {
                            characterList.Insert(s, holder2);
                            characterList.RemoveAt(i + 1);
                            i = i - 1;

                            holder1 = characterList.ElementAt(s);
                        }
                    }
                    else
                    {
                        times++;
                    }
                }
            }
        }
        #endregion

        #region StartTurn()
        public void StartTurn(Character player)
        {
            int squares = player.SquaresToMove;
        }
        #endregion

        #region setCharacterInitiative()
        //public int setCharacterInitiative()
        //{
        //    return rand.Next(1, 21);
        //}
        #endregion

        #region checkCharacterInitiatives()
        public void checkCharactersInitiatives()
        {

            int[] used = new int[20];
            int count = 0;

            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (grid[i, j] != null && grid[i, j].Token != null)
                    {
                        used[count] = grid[i, j].Token.Initiative;
                        ++count;
                    }
                }
            }

            int current;

            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (grid[i, j] != null && grid[i, j].Token != null)
                    {
                        current = grid[i, j].Token.Initiative;
                        for (int k = 0; k < count - 1; k++)
                        {
                            if (current == used[k])
                            {
                                grid[i, j].Token.Initiative = newInitiative(used);
                                used[k] = grid[i, j].Token.Initiative;
                                k = count;
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region newInitiative()
        public int newInitiative(int[] inits)
        {
            int newInit = rand.Next(1, 21);

            for (int i = 0; i < inits.Count(); i++)
            {
                if (newInit == inits[i])
                {
                    newInit = newInitiative(inits);
                }
            }

            return newInit;
        }
        #endregion

        #region MoveCharacter()
        public bool MoveCharacter(Character player, int[] moveTo, int[] currentLocation = null)
        {
            totalSquaresMoved = 0;
            if (currentLocation == null)
            {
                for (int i = 0; i < 15; i++)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        if (grid[i, j].Token == player)
                        {
                            currentLocation = new int[2];
                            currentLocation[0] = i;
                            currentLocation[1] = j;
                        }
                    }
                }
            }

            int selectedX = moveTo[0];
            int selectedY = moveTo[1];

            if (grid[selectedX, selectedY].Token != null)
            {
                Console.WriteLine("Character at [" + currentLocation[0] + ", " + currentLocation[1] + "] Requested to \nmove to [" + moveTo[0] + ", " + moveTo[1] + "] which was an occupied square \n\n");
                return false;
            }

            int currentX = currentLocation[0];
            int currentY = currentLocation[1];

            int xSquaresToMove = moveTo[0] - currentLocation[0];
            int ySquaresToMove = moveTo[1] - currentLocation[1];

            int xSquaresBeforeDiagonal = xSquaresToMove;
            int ySquaresBeforeDiagonal = ySquaresToMove;

            int diagonalSquaresThisTurn = 0;

            int squaresPerTurn = player.SquaresToMove;
            int currentlyAllowedSquares = squaresPerTurn;

            int attemptedSquaresToMove = 0;

            if (xSquaresBeforeDiagonal > 0)
            {
                for (int i = 0; i < xSquaresBeforeDiagonal; i++)
                {
                    if (ySquaresToMove > 0)
                    {
                        --xSquaresToMove;
                        --ySquaresToMove;
                        ++diagonalSquaresThisTurn;
                        ++totalSquaresMoved;
                    }
                    else if (ySquaresToMove < 0)
                    {
                        --xSquaresToMove;
                        ++ySquaresToMove;
                        ++diagonalSquaresThisTurn;
                        ++totalSquaresMoved;
                    }
                }
            }
            else if (xSquaresBeforeDiagonal < 0)
            {
                for (int i = 0; i > xSquaresBeforeDiagonal; i--)
                {
                    if (ySquaresToMove > 0)
                    {
                        ++xSquaresToMove;
                        --ySquaresToMove;
                        ++diagonalSquaresThisTurn;
                        ++totalSquaresMoved;
                    }
                    else if (ySquaresToMove < 0)
                    {
                        ++xSquaresToMove;
                        ++ySquaresToMove;
                        ++diagonalSquaresThisTurn;
                        ++totalSquaresMoved;
                    }
                }
            }

            for (int i = 1; i < diagonalSquaresThisTurn + 1; i++)
            {
                if (i % 2 == 0)
                {
                    if ((attemptedSquaresToMove + 2) <= squaresPerTurn)
                    {
                        attemptedSquaresToMove += 2;
                        currentlyAllowedSquares -= 2;
                        totalSquaresMoved += 2;
                    }
                    else
                    {
                        int k = (diagonalSquaresThisTurn - i);

                        i = diagonalSquaresThisTurn;

                        xSquaresToMove += k;
                        ySquaresToMove += k;
                    }
                }
                else
                {
                    if ((attemptedSquaresToMove + 1) <= squaresPerTurn)
                    {
                        ++attemptedSquaresToMove;
                        currentlyAllowedSquares -= 1;
                        ++totalSquaresMoved;
                    }
                    else
                    {
                        int k = (diagonalSquaresThisTurn - i);

                        i = diagonalSquaresThisTurn;

                        xSquaresToMove += k;
                        ySquaresToMove += k;

                    }
                }
            }

            if (currentlyAllowedSquares != 0 && xSquaresToMove > 0)
            {
                for (int i = xSquaresToMove; i > 0; i--)
                {
                    if (currentlyAllowedSquares > 0)
                    {
                        --xSquaresToMove;
                        --currentlyAllowedSquares;
                        ++totalSquaresMoved;
                    }
                    else
                    {
                        i = 0;
                    }
                }
            }
            else if (currentlyAllowedSquares != 0 && xSquaresToMove < 0)
            {
                for (int i = xSquaresToMove; i < 0; i++)
                {
                    if (currentlyAllowedSquares > 0)
                    {
                        ++xSquaresToMove;
                        --currentlyAllowedSquares;
                        ++totalSquaresMoved;
                    }
                    else
                    {
                        i = 0;
                    }
                }
            }

            if (currentlyAllowedSquares != 0 && ySquaresToMove > 0)
            {
                for (int i = ySquaresToMove; i > 0; i--)
                {
                    if (currentlyAllowedSquares > 0)
                    {
                        --ySquaresToMove;
                        --currentlyAllowedSquares;
                        ++totalSquaresMoved;
                    }
                    else
                    {
                        i = 0;
                    }
                }
            }
            else if (currentlyAllowedSquares != 0 && ySquaresToMove < 0)
            {
                for (int i = ySquaresToMove; i < 0; i++)
                {
                    if (currentlyAllowedSquares > 0)
                    {
                        ++ySquaresToMove;
                        --currentlyAllowedSquares;
                        ++totalSquaresMoved;
                    }
                    else
                    {
                        i = 0;
                    }
                }
            }

            if (xSquaresToMove == 0 && ySquaresToMove == 0)
            {
                grid[selectedX, selectedY].Token = player;
                grid[currentX, currentY].Token = null;

                player.SquaresLeft = (squaresPerTurn - totalSquaresMoved);
                return true;
            }
            else
            {
                if (player is Zed)
                {
                    Console.WriteLine(((Zed)player).ZedClass + " at [" + currentLocation[0] + ", " + currentLocation[1] + "] Requested to\nmove to [" + moveTo[0] + ", " + moveTo[1] + "] and was denied due to lack of squares possible per turn");
                    Console.WriteLine("Squares per turn:" + player.SquaresToMove.ToString());
                    Console.WriteLine("\n\n");
                }
                else
                {
                    Console.WriteLine("Character at [" + currentLocation[0] + ", " + currentLocation[1] + "] Requested to\nmove to [" + moveTo[0] + ", " + moveTo[1] + "] and was denied due to lack of squares possible per turn");
                    Console.WriteLine("Squares per turn:" + player.SquaresToMove.ToString());
                    Console.WriteLine("\n\n");
                }
                return false;
            }

        }
        #endregion

        #region DropItem()
        public void DropItem(Player player, bool isWeapon, int inventoryIndex, int[] square)
        {

            //if (player is Player)
            //{
            //    Player tempP = (Player)player;
            //    player = tempP;
            //}

            int currentlyAllowedSquares = player.SquaresToMove;
            Item item;

            if (currentlyAllowedSquares >= dropItem)
            {
                currentlyAllowedSquares -= dropItem;

                if (isWeapon)
                {
                    //item = player.inventory[inventoryIndex];
                    player.setItemAt(inventoryIndex);
                    item = player.ItemAt;
                    player.killItemAt(inventoryIndex);
                    grid[square[0], square[1]].Items.Add(item);
                }
                else
                {
                    player.setItemAt(inventoryIndex);
                    item = player.ItemAt;
                    player.killItemAt(inventoryIndex);
                    grid[square[0], square[1]].Items.Add(item);
                }
            }
            else
            {
                Console.WriteLine("Player Does not currently have enough squares to Drop Item at Index " + inventoryIndex);
            }
        }
        #endregion

        #region PickUpItem()
        public void PickUpItem(Character player, Item item, bool isWeapon, int[] square)
        {
            int currentlyAllowedSquares = player.SquaresToMove;

            if (currentlyAllowedSquares >= pickUpItem)
            {
                currentlyAllowedSquares -= pickUpItem;

                if (isWeapon)
                {
                    for (int i = 5; i > 0; i--)
                    {
                        if (i == 5 && player.weapons[4] != null)
                        {
                            return;
                        }
                        else if (i == 1)
                        {
                            player.weapons[0] = item;
                            grid[square[0], square[1]].itemList.Remove(item);
                            return;
                        }
                        else if (player.weapons[i - 1] == null)
                        {

                        }
                        else if (player.weapons[i - 1] != null)
                        {
                            player.weapons[i] = item;
                            grid[square[0], square[1]].itemList.Remove(item);
                            return;
                        }
                    }
                }
                else
                {
                    player.inventory.Add(item);
                    grid[square[0], square[1]].itemList.Remove(item);
                }
            }
        }
        #endregion


        #region GiveItem()
        public void GiveItem(Character giver, Character givee, int inventoryIndex, bool isWeapon)
        {
            Item item;
            int currentlyAllowedSquares = giver.SquaresToMove;

            if (currentlyAllowedSquares >= giveItem)
            {
                currentlyAllowedSquares -= giveItem;
                if (isWeapon)
                {
                    item = giver.weapons[inventoryIndex];
                    for (int i = 5; i > 0; i--)
                    {
                        if (i == 5 && givee.weapons[4] != null)
                        {
                            return;
                        }
                        else if (i == 1)
                        {
                            givee.weapons[0] = item;
                            giver.weapons[inventoryIndex] = null;
                            return;
                        }
                        else if (givee.weapons[i - 1] == null)
                        {

                        }
                        else if (givee.weapons[i - 1] != null)
                        {
                            givee.weapons[i] = item;
                            giver.weapons[inventoryIndex] = null;
                            return;
                        }
                    }
                }
                else
                {
                    item = giver.inventory.ElementAt(inventoryIndex);
                    givee.inventory.Add(item);
                    giver.inventory.RemoveAt(inventoryIndex);
                }
            }
            else
            {
                Console.WriteLine("The Giver does not have enought available squares to perform said action");
            }
        }
        #endregion
        

        #region MakeMeleeAttack()
        public void MakeMeleeAttack(Character player)
        {
            int totalSquares = player.SquaresToMove;
            int currentlyAvailableSquares = player.SquaresLeft;

            if ((totalSquares / 2) > currentlyAvailableSquares)
            {
                Console.WriteLine("Player does not have enough squares to perform this action");
            }
            else
            {
                currentlyAvailableSquares -= (totalSquares / 2);

                //Do Melee Attack

                player.SquaresLeft = currentlyAvailableSquares;
            }
        }
        #endregion

        #region MakeUn-AimedRangedAttack()
        public void MakeUnAimedRangeAttack(Character player)
        {
            int totalSquares = player.SquaresToMove;
            int currentlyAvailableSquares = player.SquaresLeft;

            if ((totalSquares / 2) > currentlyAvailableSquares)
            {
                Console.WriteLine("Player does not have enough squares to perform this action");
            }
            else
            {
                currentlyAvailableSquares -= (totalSquares / 2);

                //Do UnAimed Ranged Attack

                player.SquaresLeft = currentlyAvailableSquares;
            }
        }
        #endregion

        #region MakeAimedRangeAttack()
        public void MakeAimedRangeAttack(Character player)
        {
            int totalSquares = player.SquaresToMove;
            int currentlyAvailableSquares = player.SquaresLeft;

            if (totalSquares != currentlyAvailableSquares)
            {
                Console.WriteLine("Player does not have enough squares to perform this action");
            }
            else
            {
                currentlyAvailableSquares -= totalSquares;

                //Do Aimed Ranged Attack

                player.SquaresLeft = currentlyAvailableSquares;
            }
        }
        #endregion

        ////////////////public void testDropItem()
        ////////////////{
        ////////////////    for (int i = 0; i < 15; i++)
        ////////////////    {
        ////////////////        if (grid[0, i].c != null)
        ////////////////        {
        ////////////////            grid[0, i].c.weapons[0] = new Item { name = "pistol", damage = 10 };
        ////////////////            int[] s = new int[2] { 0, i };
        ////////////////            DropItem(grid[0, i].c, true, 0, s);

        ////////////////            grid[0, i].c.inventory.Add(new Items { name = "Health Pack", damage = -6 });
        ////////////////            DropItem(grid[0, i].c, false, 0, s);

        ////////////////            if (grid[0, i].c.inventory.Count != 0)
        ////////////////            {
        ////////////////                Console.WriteLine("Character's Inventory List: " + grid[0, i].c.inventory.ElementAt(0).name);
        ////////////////            }
        ////////////////            if (grid[0, i].c.weapons[0] != null || grid[0, i].c.weapons[1] != null || grid[0, i].c.weapons[2] != null || grid[0, i].c.weapons[3] != null || grid[0, i].c.weapons[4] != null)
        ////////////////            {
        ////////////////                Console.WriteLine("Character's Inventory List: " + grid[0, i].c.weapons[0].name);
        ////////////////            }
        ////////////////            Console.WriteLine("\n\nSquare Item List: " + grid[0, i].itemList.ElementAt(0).name + "  -and-  " + grid[0, i].itemList.ElementAt(1).name);
        ////////////////            return;
        ////////////////        }
        ////////////////    }

        ////////////////    Console.WriteLine("No Characters on first row?!");
        ////////////////}

        ////////////////public void testPickupItem()
        ////////////////{

        ////////////////    for (int i = 0; i < 15; i++)
        ////////////////    {
        ////////////////        if (grid[0, i].c != null)
        ////////////////        {
        ////////////////            grid[0, i].itemList.Clear();


        ////////////////            grid[0, i].itemList.Add(new Items { name = "rifle", damage = 20 });
        ////////////////            int[] s = new int[2] { 0, i };
        ////////////////            PickUpItem(grid[0, i].c, grid[0, i].itemList.ElementAt(0), true, s);

        ////////////////            grid[0, i].itemList.Add(new Items { name = "Health Pack", damage = -6 });
        ////////////////            PickUpItem(grid[0, i].c, grid[0, i].itemList.ElementAt(0), false, s);

        ////////////////            if (grid[0, i].itemList.Count != 0)
        ////////////////            {
        ////////////////                Console.WriteLine(" \n\nSquare Item List: " + grid[0, i].itemList.ElementAt(0).name);
        ////////////////            }

        ////////////////            try
        ////////////////            {
        ////////////////                Console.WriteLine("\n\nCharacter's Inventory List: " + grid[0, i].c.weapons[0].name + "  -and-  " + grid[0, i].c.inventory.ElementAt(0).name);
        ////////////////            }
        ////////////////            catch
        ////////////////            {

        ////////////////            }
        ////////////////            grid[0, i].c.weapons = new Items[5];
        ////////////////            grid[0, i].c.inventory.Clear();
        ////////////////            return;
        ////////////////        }
        ////////////////    }

        ////////////////    Console.WriteLine("No Characters on first row?!");
        ////////////////}

        ////////////////public void testGiveItem()
        ////////////////{
        ////////////////    Character giver;
        ////////////////    Character givee;


        ////////////////    for (int i = 0; i < 15; i++)
        ////////////////    {
        ////////////////        if (grid[0, i].c != null)
        ////////////////        {
        ////////////////            giver = grid[0, i].c;

        ////////////////            for (int j = i + 1; j < 15; j++)
        ////////////////            {
        ////////////////                if (grid[0, j].c != null)
        ////////////////                {
        ////////////////                    givee = grid[0, j].c;

        ////////////////                    giver.weapons[0] = new Items { name = "sniper", damage = 50 };
        ////////////////                    GiveItem(giver, givee, 0, true);

        ////////////////                    giver.inventory.Add(new Items { name = "MEDICAL kit", damage = -25 });
        ////////////////                    GiveItem(giver, givee, 0, false);

        ////////////////                    try
        ////////////////                    {
        ////////////////                        Console.WriteLine("\n\nCharacter's Inventory List: " + grid[0, j].c.weapons[0].name + "  -and-  " + grid[0, j].c.inventory.ElementAt(0).name);
        ////////////////                    }
        ////////////////                    catch
        ////////////////                    {

        ////////////////                    }
        ////////////////                    Console.WriteLine("\n");
        ////////////////                    return;
        ////////////////                }
        ////////////////            }
        ////////////////        }
        ////////////////    }

        ////////////////    Console.WriteLine("There are not two people on the First row?!");
        ////////////////}
        #endregion

        #region Zeds

        #region calcZedAttack()
        public void calcZedAttack(Zed zed)
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (grid[i, j].Token == zed)
                    {
                        bool didCombat = false;

                        #region didCombat
                        //Directly Down
                        if (!didCombat)
                        {
                            try
                            {
                                if (grid[i + 1, j].Token is Character)
                                {
                                    if (!(grid[i + 1, j].Token is Zed))
                                    {
                                        //zombieApocalypse.Combat.CombatManager.startCombat(zed, grid[i + 1, j].c);
                                        didCombat = true;
                                    }
                                    else if (grid[i + 1, j].Token is Zed)
                                    {
                                        Console.WriteLine("Zed");
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }

                        //Down Left
                        if (!didCombat)
                        {
                            try
                            {
                                if (grid[i + 1, j - 1].Token is Character)
                                {
                                    if (!(grid[i + 1, j - 1].Token is Zed))
                                    {
                                        didCombat = true;
                                    }
                                    else if (grid[i + 1, j - 1].Token is Zed)
                                    {
                                        Console.WriteLine("Zed");

                                    }
                                }
                            }
                            catch
                            {

                            }
                        }

                        //Directly Left
                        if (!didCombat)
                        {
                            try
                            {
                                if (grid[i, j - 1].Token is Character)
                                {
                                    if (!(grid[i, j - 1].Token is Zed))
                                    {
                                        didCombat = true;
                                    }
                                    else if (grid[i, j - 1].Token is Zed)
                                    {
                                        Console.WriteLine("Zed");

                                    }
                                }
                            }
                            catch
                            {

                            }
                        }

                        //Above Left
                        if (!didCombat)
                        {
                            try
                            {
                                if (grid[i - 1, j - 1].Token is Character)
                                {
                                    if (!(grid[i - 1, j - 1].Token is Zed))
                                    {
                                        didCombat = true;
                                    }
                                    else if (grid[i - 1, j - 1].Token is Zed)
                                    {
                                        Console.WriteLine("Zed");

                                    }
                                }
                            }
                            catch
                            {

                            }
                        }

                        //Directly Above
                        if (!didCombat)
                        {
                            try
                            {
                                if (grid[i - 1, j].Token is Character)
                                {
                                    if (!(grid[i - 1, j].Token is Zed))
                                    {
                                        didCombat = true;
                                    }
                                    else if (grid[i - 1, j].Token is Zed)
                                    {
                                        Console.WriteLine("Zed");

                                    }
                                }
                            }
                            catch
                            {

                            }
                        }

                        //Above Right
                        if (!didCombat)
                        {
                            try
                            {
                                if (grid[i - 1, j + 1].Token is Character)
                                {
                                    if (!(grid[i - 1, j + 1].Token is Zed))
                                    {
                                        didCombat = true;
                                    }
                                    else if (grid[i - 1, j + 1].Token is Zed)
                                    {
                                        Console.WriteLine("Zed");

                                    }
                                }
                            }
                            catch
                            {

                            }
                        }

                        //Directly Right
                        if (!didCombat)
                        {
                            try
                            {
                                if (grid[i, j + 1].Token is Character)
                                {
                                    if (!(grid[i, j + 1].Token is Zed))
                                    {
                                        didCombat = true;
                                    }
                                    else if (grid[i, j + 1].Token is Zed)
                                    {
                                        Console.WriteLine("Zed");

                                    }
                                }
                            }
                            catch
                            {

                            }
                        }

                        //Down Right
                        if (!didCombat)
                        {
                            try
                            {
                                if (grid[i + 1, j + 1].Token is Character)
                                {
                                    if (!(grid[i + 1, j + 1].Token is Zed))
                                    {
                                        didCombat = true;
                                    }
                                    else if (grid[i + 1, j + 1].Token is Zed)
                                    {
                                        Console.WriteLine("Zed");

                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                        #endregion

                        #region !didCombat
                        if (!didCombat)
                        {

                            for (int w = 0; w < zed.SquaresToMove; w++) // i
                            {
                                for (int a = 0; a < zed.SquaresToMove; a++) // j
                                {
                                    bool foundOne = false;
                                    bool foundTwo = false;
                                    bool foundThree = false;
                                    bool foundFour = false;

                                    int found = 0;
                                    try
                                    {
                                        if (grid[i - w, j - a].Token != null && (!(grid[i - w, j - a].Token is Zed)))
                                        {
                                            foundOne = true;
                                            ++found;
                                            Console.WriteLine();
                                            Console.WriteLine("Found Someone at [" + (i - w) + ", " + (j - a) + "]");
                                        }
                                    }
                                    catch
                                    {

                                    }

                                    try
                                    {
                                        if (grid[i + w, j - a].Token != null && (!(grid[i + w, j - a].Token is Zed)))
                                        {
                                            foundThree = true;
                                            ++found;
                                            Console.WriteLine();
                                            Console.WriteLine("Found Someone at [" + (i + w) + ", " + (j - a) + "]");
                                        }
                                    }
                                    catch
                                    {

                                    }

                                    try
                                    {
                                        if (grid[i + w, j + a].Token != null && (!(grid[i + w, j + a].Token is Zed)))
                                        {
                                            foundTwo = true;
                                            ++found;
                                            Console.WriteLine();
                                            Console.WriteLine("Found Someone at [" + (i + w) + ", " + (j + a) + "]");
                                        }
                                    }
                                    catch
                                    {

                                    }

                                    try
                                    {
                                        if (grid[i - w, j + a].Token != null && (!(grid[i - w, j + a].Token is Zed)))
                                        {
                                            foundFour = true;
                                            ++found;
                                            Console.WriteLine();
                                            Console.WriteLine("Found Someone at [" + (i - w) + ", " + (j + a) + "]");
                                        }
                                    }
                                    catch
                                    {

                                    }

                                    if (found > 0)
                                    {
                                        int x = 0;
                                        int y = 0;
                                        int spaces = 0;

                                        if (foundOne)
                                        {
                                            //grid[i - w, j - a]
                                            y = (i - w);
                                            x = (j - a);

                                            calcMove(zed, x, y);
                                        }
                                        else if (foundTwo)
                                        {
                                            //grid[i + w, j + a]
                                            y = (i + w);
                                            x = (j + a);

                                            calcMove(zed, x, y);
                                        }
                                        else if (foundThree)
                                        {
                                            //grid[i + w, j - a]
                                            y = (i + w);
                                            x = (j - a);

                                            calcMove(zed, x, y);
                                        }
                                        else if (foundFour)
                                        {
                                            //grid[i - w, j + a]
                                            y = (i - w);
                                            x = (j + a);

                                            calcMove(zed, x, y);
                                        }
                                    }
                                }
                            }
                        }
                        #endregion
                    }
                }
            }
        }
        #endregion

        #region calcMove
        public void calcMove(Zed zed, int x, int y)
        {
            #region move
            bool moved = false;
            //Directly Down
            if (!moved)
            {
                try
                {
                    if (grid[y + 1, x].Token == null)
                    {
                        int[] toMove = { (y + 1), x };
                        moved = MoveCharacter(zed, toMove);
                    }
                }
                catch
                {

                }
            }

            //Down Left
            if (!moved)
            {
                try
                {
                    if (grid[y + 1, x - 1].Token == null)
                    {
                        int[] toMove = { (y + 1), (x - 1) };
                        moved = MoveCharacter(zed, toMove);
                    }
                }
                catch
                {

                }
            }

            //Directly Left
            if (!moved)
            {
                try
                {
                    if (grid[y, x - 1].Token == null)
                    {
                        int[] toMove = { y, (x - 1) };
                        moved = MoveCharacter(zed, toMove);
                    }
                }
                catch
                {

                }
            }

            //Above Left
            if (!moved)
            {
                try
                {
                    if (grid[y - 1, x - 1].Token == null)
                    {
                        int[] toMove = { (y - 1), (x - 1) };
                        moved = MoveCharacter(zed, toMove);
                    }
                }
                catch
                {

                }
            }

            //Directly Above
            if (!moved)
            {
                try
                {
                    if (grid[y - 1, x].Token == null)
                    {
                        int[] toMove = { (y - 1), x };
                        moved = MoveCharacter(zed, toMove);
                    }
                }
                catch
                {

                }
            }

            //Above Right
            if (!moved)
            {
                try
                {
                    if (grid[y - 1, x + 1].Token == null)
                    {
                        int[] toMove = { (y - 1), (x + 1) };
                        moved = MoveCharacter(zed, toMove);
                    }
                }
                catch
                {

                }
            }

            //Directly Right
            if (!moved)
            {
                try
                {
                    if (grid[y, x + 1].Token == null)
                    {
                        int[] toMove = { y, (x + 1) };
                        moved = MoveCharacter(zed, toMove);
                    }
                }
                catch
                {

                }
            }

            //Down Right
            if (!moved)
            {
                try
                {
                    if (grid[y + 1, x + 1].Token == null)
                    {
                        int[] toMove = { (y + 1), (x + 1) };
                        moved = MoveCharacter(zed, toMove);
                    }
                }
                catch
                {

                }
            }
            #endregion

            if (moved)
            {
                Console.WriteLine(zed.ZedClass + " moved");
                if (zed is Sloucher)
                {
                    if (totalSquaresMoved > 1)
                    {

                    }
                    else
                    {
                        Console.WriteLine("Sloucher is attacking");
                        //if currently allowd squares are > half
                        //{
                        //initiate attack here
                        //}

                        if (zed.SquaresLeft < (zed.SquaresToMove - 1))
                        {
                            //Attack
                        }

                        zed.SquaresLeft = zed.SquaresToMove;
                    }
                }
                else if (zed is FastAttack)
                {
                    Console.WriteLine("Fast attack may be able to attack");
                    //if currently allowd squares are > half
                    //{
                    //initiate attack here
                    //}

                    if (zed.SquaresLeft < (zed.SquaresToMove / 2))
                    {
                        //Attack
                    }

                    zed.SquaresLeft = zed.SquaresToMove;
                }
                else if (zed is Shank)
                {
                    Console.WriteLine("Shank may be able to attack");
                    //if currently allowd squares are > half
                    //{
                    //initiate attack here
                    //}

                    if (zed.SquaresLeft < (zed.SquaresToMove / 2))
                    {
                        //Attack
                    }

                    zed.SquaresLeft = zed.SquaresToMove;
                }
                else if (zed is Spitter)
                {
                    Console.WriteLine("Spitter may be able to attack");
                    //if currently allowd squares are > half
                    //{
                    //initiate attack here
                    //}

                    if (zed.SquaresLeft < (zed.SquaresToMove / 2))
                    {
                        //Attack
                    }

                    zed.SquaresLeft = zed.SquaresToMove;
                }
                else if (zed is Tank)
                {
                    Console.WriteLine("Tank may be able to attack");
                    //if currently allowd squares are > half
                    //{
                    //initiate attack here
                    //}

                    if (zed.SquaresLeft < (zed.SquaresToMove / 2))
                    {
                        //Attack
                    }

                    zed.SquaresLeft = zed.SquaresToMove;
                }

                totalSquaresMoved = 0;
            }
        }
        #endregion

        #region checkLineOfSight()
        public bool checkLineOfSight(int[] target, int[] currentLocation)
        {
            bool canHit = true;

            int targetX = target[0];
            int targetY = target[1];

            int currentX = currentLocation[0];
            int currentY = currentLocation[1];

            //int targetX = 10;
            //int targetY = 4;

            //int currentX = 14;
            //int currentY = 14;

            int xSquaresToMove = targetX - currentX;
            int ySquaresToMove = targetY - currentY;

            int intX = 0;
            int intY = 0;

            int xSquaresBeforeDiagonal = xSquaresToMove;
            int ySquaresBeforeDiagonal = ySquaresToMove;

            if (xSquaresBeforeDiagonal > 0)
            {
                for (int i = 0; i < xSquaresBeforeDiagonal; i++)
                {
                    if (canHit != false)
                    {
                        if (ySquaresToMove != 0)
                        {
                            if (ySquaresToMove > 0 && ((currentX + (intX + 1)) != targetX) && (currentY + (i + 1)) != targetY)
                            {
                                if (ySquaresToMove > 0 && (grid[currentX + (intX + 1), (currentY + (intY + 1))].Token == null))
                                {
                                    int x = (currentX + (intX + 1));
                                    int y = (currentY + (intY + 1));

                                    --xSquaresToMove;
                                    --ySquaresToMove;

                                    ++intX;
                                    ++intY;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else if ((currentX + (intX + 1)) == targetX && (currentY + (i + 1)) == targetY)
                            {
                                return true;
                            }
                            else if (ySquaresToMove < 0 && ((currentX + (intX + 1)) != targetX) && (currentY + (i - 1)) != targetY)
                            {
                                if (ySquaresToMove < 0 && (grid[currentX + (intX + 1), (currentY + (intY - 1))].Token == null))
                                {
                                    int x = (currentX + (intX + 1));
                                    int y = (currentY + (intY - 1));

                                    --xSquaresToMove;
                                    ++ySquaresToMove;

                                    ++intX;
                                    --intY;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else if ((currentX + (intX + 1)) == targetX && (currentY + (i - 1)) == targetY)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            else if (xSquaresBeforeDiagonal < 0)
            {
                for (int i = 0; i > xSquaresBeforeDiagonal; i--)
                {
                    if (canHit != false)
                    {
                        if (ySquaresToMove != 0)
                        {
                            if (ySquaresToMove > 0 && ((currentX + (intX - 1)) != targetX) && (currentY + (i - 1)) != targetY)
                            {
                                if (grid[currentX + (intX - 1), (currentY + (intY + 1))].Token == null)
                                {
                                    int x = (currentX + (intX - 1));
                                    int y = (currentY + (intY + 1));

                                    ++xSquaresToMove;
                                    --ySquaresToMove;

                                    --intX;
                                    ++intY;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else if ((currentX + (intX - 1)) == targetX && (currentY + (i - 1)) == targetY)
                            {
                                return true;
                            }
                            else if (ySquaresToMove < 0 && ((currentX + (intX - 1)) != targetX) && (currentY + (i - 1)) != targetY)
                            {
                                if (grid[currentX + (intX - 1), (currentY + (intY - 1))].Token == null)
                                {
                                    int x = (currentX + (intX - 1));
                                    int y = (currentY + (intY - 1));

                                    ++xSquaresToMove;
                                    ++ySquaresToMove;

                                    --intX;
                                    --intY;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else if ((currentX + (intX - 1)) == targetX && (currentY + (i - 1)) == targetY)
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            if (canHit != false)
            {
                if (xSquaresToMove > 0)
                {
                    for (int i = xSquaresToMove; i > 0; i--)
                    {
                        if (canHit != false)
                        {
                            if (currentX + (intX - 1) == targetX)
                            {
                                ++intX;
                            }
                            else if (grid[currentX + (intX + 1), currentY + intY].Token == null)
                            {
                                int x = (currentX + (intX + 1));
                                int y = (currentY + intY);

                                --xSquaresToMove;

                                ++intX;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
                else if (xSquaresToMove < 0)
                {
                    for (int i = xSquaresToMove; i < 0; i++)
                    {
                        if (canHit != false)
                        {
                            if (currentX + (intX - 1) == targetX)
                            {
                                --intX;
                            }
                            else if (grid[currentX + (intX - 1), currentY + intY].Token == null)
                            {
                                int x = (currentX + (intX - 1));
                                int y = (currentY + intY);

                                ++xSquaresToMove;

                                --intX;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            if (canHit != false)
            {
                if (ySquaresToMove > 0)
                {
                    for (int i = ySquaresToMove; i > 0; i--)
                    {
                        if (canHit != false)
                        {
                            if (currentY + (intY + 1) == targetY)
                            {
                                ++intY;
                            }
                            else if (grid[currentX + intX, currentY + (intY + 1)].Token == null)
                            {
                                int x = (currentX + intX);
                                int y = (currentY + (intY + 1));

                                --ySquaresToMove;

                                ++intY;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
                else if (ySquaresToMove < 0)
                {
                    for (int i = ySquaresToMove; i < 0; i++)
                    {
                        if (canHit != false)
                        {
                            if (currentY + (intY - 1) == targetY)
                            {
                                --intY;
                            }
                            else if (grid[currentX + intX, currentY + (intY - 1)].Token == null)
                            {
                                int x = (currentX + intX);
                                int y = (currentY + (intY - 1));

                                ++ySquaresToMove;

                                --intY;
                            }
                            else
                            {
                                int x = (currentX + intX);
                                int y = (currentY + (intY - 1));

                                return false;
                            }
                        }
                    }
                }
            }

            return canHit;
        }
        #endregion
        #endregion
    }
}
