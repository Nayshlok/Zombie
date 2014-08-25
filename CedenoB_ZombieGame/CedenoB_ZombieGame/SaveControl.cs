using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using CedenoB_ZombieGame.Model;

namespace CedenoB_ZombieGame
{
    [Serializable()]
    class SaveControl
    {
        
        public void save(Stream myStream, Square[,] GameGrid)
        {
            using (myStream)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(myStream, SetupSave(GameGrid));
            }
        }

        private SaveClass SetupSave(Square[,] GameBoard)
        {
            SaveableSquare[,] testBoard = new SaveableSquare[25, 25];
            foreach (Square s in GameBoard)
            {
                SaveableSquare square = new SaveableSquare();
                square.Items = s.Items;
                square.IsOpen = s.IsOpen;
                square.Token = s.Token;
                //square.PassCharacter = s.PassCharacter;
                square.imagePath = s.imagePath;
                square.X = s.X;
                square.Y = s.Y;
                testBoard[s.X, s.Y] = square;
            }

            SaveClass save = new SaveClass(testBoard);
            return save;
        }

        public SaveClass open(Stream myStream)
        {
            using (myStream)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                SaveClass save = (SaveClass)formatter.Deserialize(myStream);
                return save;
                //createGridDisplay();
            }
        }

    }
}
