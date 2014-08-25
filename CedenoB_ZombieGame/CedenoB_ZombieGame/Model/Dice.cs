using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zombieApocalypse.Model
{
    [Serializable()]
    public class Dice
    {
        private int _NumberOfDie;
        private int _FaceOfDie;
        private Random rand = new Random();

        public Dice(int numberOfDie, int faceOfDie)
        {
            _NumberOfDie = numberOfDie;
            _FaceOfDie = faceOfDie;
        }

        public int Roll()
        {
            int result = 0;

            for (int i = 0; i < _NumberOfDie; i++)
            {
                result += rand.Next(1, _FaceOfDie + 1);
            }

            return result;
        }
    }
}
