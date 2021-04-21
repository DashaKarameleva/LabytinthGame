using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labyrinth.Bullet
{
    public class BulletDecorator : Bullet
    {
        protected Bullet bullet;

        public BulletDecorator(Bullet bullet)
        {
            this.bullet = bullet;
        }

        public override float Power { get => bullet.Power; }

        public override int Count { get => bullet.Count; }

        public override void Add(int count)
        {
            bullet.Add(count);
        }


        public override bool Shot()
        {
            return bullet.Shot();
        }
    }
}
