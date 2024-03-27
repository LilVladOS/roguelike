using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIGALIK
{
    internal class ScoreCounter
    {
        private int score;
        public int Score => score;
        public void IncrementScore(int amount)
        { 
            score += amount; 
        }

    }
}
