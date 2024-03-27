using RIGALIK.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIGALIK
{
    internal class Level
    {
        private int currentLevel;
        private Player player;
        private List<Map> levels;

        public Level(Player player)
        {
            this.player = player;
            levels = new List<Map>();
            currentLevel = 0;
        }
        public void LoadLevel(int levelIndex)
        { 
        
        }

        public void GenerateNewLevel()
        {

            
        }
        public void MoveToNextLevel()
        {
            currentLevel++;
            if (currentLevel < levels.Count) 
            {
                LoadLevel(currentLevel);
            }
            else
            {
                GenerateNewLevel();
            }
        }
    }
}
