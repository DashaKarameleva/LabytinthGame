using OpenTK;

namespace labyrinth.bonus
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="labyrinth.bonus.BonusFactory" />
    public class HealthFactory : BonusFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HealthFactory"/> class.
        /// </summary>
        public HealthFactory() : base()
        {
        }

        /// <summary>
        /// Gets the boost.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="filename">The filename.</param>
        /// <param name="Position">The position.</param>
        /// <returns></returns>
        public override Bonus GetBoost(int width, int height, string filename, Vector2 Position)
        {
            return new HealthBonus(width, height, filename, Position);
        }

    }
}
