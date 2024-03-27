using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIGALIK
{
    internal class UI
    {
        public void DisplayScore(int score)
        {
            Console.WriteLine($"Score: {score}");
        }

        public void DisplayHealth(int health)
        {
            Console.WriteLine($"Health: {health}");
        }
    }
}
