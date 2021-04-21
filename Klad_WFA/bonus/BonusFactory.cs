using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labyrinth.bonus
{
    abstract class BonusFactory
    {
        protected BonusFactory()
        {
        }

        public abstract Bonus GetBoost(int width, int height, string filename, Vector2 Position);
    }
}
