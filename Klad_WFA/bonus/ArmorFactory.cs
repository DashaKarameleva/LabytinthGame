using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace labyrinth.bonus
{
    class ArmorFactory: BonusFactory
    {
        public ArmorFactory() : base()
        {
        }
        public override Bonus GetBoost(int width, int height, string filename, Vector2 Position)
        {
            return new ArmorBonus(width, height, filename, Position);
        }
    }

    
}
