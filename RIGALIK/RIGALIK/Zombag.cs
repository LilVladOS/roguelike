using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIGALIK
{
    internal class Zombag : Enemy
    {
        public Zombag() : base(initialHealth: 50, damage: 10, symbol:'з')
        {

        }
        public override void Attack(Player player)
        {
            player.TakeDamage(damage);
        }



        public override void Draw()
        {
            base.Draw();
            if (!IsDead)
            {
                Console.SetCursorPosition(Position.X, Position.Y);
                Console.Write(Symbol);
            }
        }



    }

}
