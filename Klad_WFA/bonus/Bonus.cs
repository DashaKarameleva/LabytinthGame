
using OpenTK;

namespace labyrinth
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="labyrinth.GameObject" />
    public abstract class Bonus : GameObject
    {
        /// <summary>
        /// The time set minutes
        /// </summary>
        public int timeSetMinutes;
        /// <summary>
        /// The time set second
        /// </summary>
        public int timeSetSecond;
        /// <summary>
        /// The duration
        /// </summary>
        public int duration;
        /// <summary>
        /// The active
        /// </summary>
        public bool active = false;
        /// <summary>
        /// The player
        /// </summary>
        public Player player;

        /// <summary>
        /// Initializes a new instance of the <see cref="Bonus"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="filename">The filename.</param>
        /// <param name="position">The position.</param>
        public int power;
        public Bonus(int width, int height, string filename, Vector2 position): base(width, height, filename, position)
        {
            duration = 5;
           // this.power = 0;
        }

        /// <summary>
        /// Ups the player.
        /// </summary>
        /// <param name="player">The player.</param>
        abstract public void UpPlayer(Player player);

        /// <summary>
        /// Defalts the player.
        /// </summary>
        /// <param name="player">The player.</param>
        abstract public void DefaltPlayer(Player player);

        /// <summary>
        /// Draws this instance.
        /// </summary>
        public override void Draw()
        {
            if (!active)
            {
                base.Draw();
            }
        }

    }
}
