using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labyrinth.Bullet
{
    class StandartBullet:Bullet
    {
        public StandartBullet(float power, int count)
        {
            currPower = power;
            currCout = count;
        }

        public override float Power => currPower;

        public override int Count => currCout;

        public override string ToString()
        {
            return "Standart power";
        }
    }
}
