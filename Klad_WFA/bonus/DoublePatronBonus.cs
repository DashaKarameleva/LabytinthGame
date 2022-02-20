using labyrinth;
using labyrinth.Bullet;
using OpenTK;

namespace Labyrinth.bonus
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Labyrinth.bonus.PatronDecorator" />
    public class DoublePatronBonus : Bonus
    {
        /// <summary>
        /// The position
        /// </summary>
        private static Vector2 position;
        /// <summary>
        /// The width
        /// </summary>
        private static int width;
        /// <summary>
        /// The height
        /// </summary>
        private static int height;
        /// <summary>
        /// The filename
        /// </summary>
        private static string filename;

        /// <summary>
        /// Initializes a new instance of the <see cref="DoublePatronBonus"/> class.
        /// </summary>
        /// <param name="bonus">The bonus.</param>
        public DoublePatronBonus(Bonus bonus) : base(width, height, filename, position)
        {
            this.power = bonus.power *2;
            position = bonus.Position;
            width = bonus.W;
            height = bonus.H;
            filename = "texture/bonus.png";
        }
        /// <summary>
        /// Defalts the player.
        /// </summary>
        /// <param name="player">The player.</param>
        public override void DefaltPlayer(Player player)
        {
        }
        /// <summary>
        /// Ups the player.
        /// </summary>
        /// <param name="player">The player.</param>
        public override void UpPlayer(Player player)
        {
            player.BulletMagazine.Add(new DoubleTypeBullet( new StandartTypeBullet(2, 5)));
            active = true;
            this.player = player;
        }
    }
}
