using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIGALIK
{
    internal abstract class Enemy
    {
        protected int health;
        protected int damage;

        public event Action Death;

        public int Health => health;

        public Point Position { get; protected set; }
        public char Symbol { get; protected set; }
        public bool IsDead { get; protected set; }

        public Enemy(int initialHealth, int damage, char symbol)
        {
            health = initialHealth;
            this.damage = damage;
            Symbol = symbol;
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                OnDeath();
            }
        }

        protected virtual void OnDeath()
        {
            Death?.Invoke();
        }
        public abstract void Attack(Player player);
        /*public virtual void Draw(List<Enemy> enemies)
        {
            foreach (var enemy in enemies)
            {
                if (!enemy.IsDead)
                {
                    Console.SetCursorPosition(enemy.Position.X, enemy.Position.Y);
                    Console.Write(enemy.Symbol);
                }
            }

        }*/
        public virtual void Draw()
        {
            if (!IsDead)
            {
                Console.SetCursorPosition(Position.X, Position.Y);
                Console.Write(Symbol);
            }
        }



    }
}
