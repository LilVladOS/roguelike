using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIGALIK
{
    internal class HP
    {
        private int health;
        public int Health => health;
        public event Action Death;
        public HP(int initialHealth) 
        {
            health = initialHealth;
        }
        public void TakeDamage(int damage) 
        {
            health -= damage;
            if (health <= 0) 
            {
                //add Player's death
                Die();
            }
        }
        public void Heal(int amount) 
        {
            health += amount;
        }
        protected virtual void Die() 
        {
            Death?.Invoke();
        }
    }
}
