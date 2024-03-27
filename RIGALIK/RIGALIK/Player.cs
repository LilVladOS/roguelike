using RIGALIK.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIGALIK
{
    internal class Player
    {

        private int score;
        private int health;
        //private Map _map;

        public int X { get;private set; }
        public int Y { get;private set; }
        public int Score { get; private set; } 
        public int Health { get { return health; } }
        public Player(int startX, int startY)
        { 
            X = startX;
            Y = startY; 
            score = 0;
            health = 100;
            
        }
        public void ProcessInput(ConsoleKeyInfo key)
        {
            
            switch (key.Key)
            {
                case ConsoleKey.W: // Движение вверх
                    Y--;
                    break;
                case ConsoleKey.S: // Движение вниз
                    Y++;
                    break;
                case ConsoleKey.A: // Движение влево
                    X--;
                    break;
                case ConsoleKey.D: // Движение вправо
                    X++;
                    break;
                default:
                    // Обработка других клавиш (если необходимо)
                    break;
            }
           
        }
        public void IncrementScore(int points) 
        {
            score += points;
        }

        public void TakeDamage(int damage) 
        {
            health -= damage;
            if (health <= 0)
            {
                Console.WriteLine("GAME OVER");
            }
        }

    }
}
