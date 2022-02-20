using OpenTK;
using System;
namespace labyrinth.bonus
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="labyrinth.Bonus" />
    public class UpBonus : Bonus
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string Type { get; set; } = "SpeedUp";
        /// <summary>
        /// Initializes a new instance of the <see cref="UpBonus"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="filename">The filename.</param>
        /// <param name="position">The position.</param>
        public UpBonus(int width, int height, string filename, Vector2 position) : base(width, height, filename, position)
        {
        }

        /// <summary>
        /// Ups the player.
        /// </summary>
        /// <param name="player">The player.</param>
        public override void UpPlayer(Player player)
        {
            player.speed = 4;
            timeSetMinutes = DateTime.Now.Minute;
            timeSetSecond = DateTime.Now.Second;
            if (timeSetSecond + duration >= 60)
            {
                timeSetMinutes += 1;
                timeSetSecond = timeSetSecond + duration - 60;
            }
            else
            {
                timeSetSecond += duration;
            }

            active = true;
            this.player = player;
        }

        /// <summary>
        /// Defalts the player.
        /// </summary>
        /// <param name="player">The player.</param>
        public override void DefaltPlayer(Player player)
        {
            player.speed = 2;
        }
    }
}
