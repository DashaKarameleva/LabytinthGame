 using OpenTK;
namespace labyrinth
{
    /// <summary>
    /// 
    /// </summary>
    public class Map
    {
        /// <summary>
        /// Gets or sets the picture.
        /// </summary>
        /// <value>
        /// The picture.
        /// </value>
        public string Picture { get; set; }
        /// <summary>
        /// Gets or sets the mape.
        /// </summary>
        /// <value>
        /// The mape.
        /// </value>
        public string Mape { get; set; }
        /// <summary>
        /// Gets or sets the position1 player.
        /// </summary>
        /// <value>
        /// The position1 player.
        /// </value>
        public Vector2 Position1Player { get; set; }
        /// <summary>
        /// Gets or sets the position2 player.
        /// </summary>
        /// <value>
        /// The position2 player.
        /// </value>
        public Vector2 Position2Player { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Map"/> class.
        /// </summary>
        /// <param name="picture">The picture.</param>
        /// <param name="mape">The mape.</param>
        /// <param name="pl1p">The PL1P.</param>
        /// <param name="pl2p">The PL2P.</param>
        public Map(string picture, string mape, Vector2 pl1p, Vector2 pl2p)
        {
            Picture = picture;
            Mape = mape;
            Position1Player = pl1p;
            Position2Player = pl2p;
        }

    }
}
