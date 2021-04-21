using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labyrinth.bonus
{
    class HealthFactory : BonusFactory
    {
        public HealthFactory() : base()
        {
        }

        public override Bonus GetBoost(int width, int height, string filename, Vector2 Position)
        {
            return new HealthBonus(width, height, filename, Position);
        }

    }
}
