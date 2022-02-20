using OpenTK;

namespace labyrinth.bonus
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BonusFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BonusFactory"/> class.
        /// </summary>
        protected BonusFactory()
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
        public abstract Bonus GetBoost(int width, int height, string filename, Vector2 Position);
    }
}
