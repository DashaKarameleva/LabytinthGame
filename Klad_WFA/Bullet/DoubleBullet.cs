using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labyrinth.Bullet
{
   public class DoubleBullet:BulletDecorator
    {
        public DoubleBullet(Bullet bullet) : base(bullet)
        {

        }

        public override float Power { get => bullet.Power * 2; }

        public override string ToString()
        {
            return "Double power";
        }
    }
}
