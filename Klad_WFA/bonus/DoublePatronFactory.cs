using labyrinth;
using labyrinth.bonus;
using OpenTK;

namespace Labyrinth.bonus
{
    public class DoublePatronFactory : BonusFactory
    {
        public DoublePatronFactory() : base()
        {
        }
        public override Bonus GetBoost(int width, int height, string filename, Vector2 Position)
        {
            return new DoublePatronBonus(new PatronBonus(width, height, filename, Position));
        }
    }
}
