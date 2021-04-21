using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labyrinth.bonus
{
    class SpeedUpFactory : BonusFactory
    {
        public SpeedUpFactory() : base()
        {
        }

        public override Bonus GetBoost(int width, int height, string filename, Vector2 Position)
        {
            return new UpBonus(width, height, filename, Position);
        }
    }
}
