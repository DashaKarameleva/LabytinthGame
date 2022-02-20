using labyrinth.Bullet;
using OpenTK;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labyrinth
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="OpenTK.GameWindow" />
    public class Game : GameWindow
    {
        /// <summary>
        /// The background
        /// </summary>
        Background background;
        /// <summary>
        /// The gameover1
        /// </summary>
        Background gameover1;
        /// <summary>
        /// The gameover2
        /// </summary>
        Background gameover2;
        /// <summary>
        /// The player1
        /// </summary>
        public Player player1, player2;
        /// <summary>
        /// The sides
        /// </summary>
        List<Sides> sides = new List<Sides>();
        /// <summary>
        /// The create sides
        /// </summary>
        List<Sides> createSides = new List<Sides>();
        /// <summary>
        /// The boosts
        /// </summary>
        List<Bonus> boosts = new List<Bonus>();
        /// <summary>
        /// The monsters
        /// </summary>
        List<Monster> monsters = new List<Monster>();
        /// <summary>
        /// The monsters
        /// </summary>
        List<ObjectBullet> patrons;
        /// <summary>
        /// The bullet magazine
        /// </summary>
        BulletMagazine bulletMagazine = new BulletMagazine();
        /// <summary>
        /// The mape
        /// </summary>
        public static Map mape;
        Level level = new Level();

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        public Game()
        {
            mape = new Map("texture/Map1.png", "texture/Level1.bmp", new Vector2(35, 35), new Vector2(1480, 750));

            Width = 1557;
            Height = 900;
            Location = new Point(0, 0);
            level.CreateLevel(sides, monsters);
            background = new Background(Width, Height, "texture/background.jpg");
            gameover1 = new Background(Width, Height, "texture/pl1Win.png");
            gameover2 = new Background(Width, Height, "texture/pl2Win.png");
            player1 = new Player(20, 20, "texture/pl1S.png", mape.Position1Player, 1);
            player1.Tag = "player1";
            player2 = new Player(20, 20, "texture/pl2S.png", mape.Position2Player, 2);
            player2.Tag = "player2";
            patrons = new List<ObjectBullet>();
        }
        /// <summary>
        /// Renderings this instance.
        /// </summary>
        /// 
        public static List<ObjectBullet> GetPatrons { get; set; }
        Actions actions = new Actions();
        public void Rendering()
        {
            KeyboardState kb_state = Keyboard.GetState();
            if (kb_state.IsKeyDown(Key.Escape)) Exit();
            if (monsters.Count != 0)
            {
                GameEvents.ChangeHealthPlayer?.Invoke(player1.health, player2.health);
                GameEvents.ChangeArmor?.Invoke(player1.armor, player2.armor);
                GameEvents.ChangePatronCount?.Invoke(player1.patron, player2.patron);
                GameEvents.ChangePlayerPoints?.Invoke(player1.count, player2.count);

                actions.GameObjectMove(player1, player2, sides, boosts, monsters,patrons);
            }
            background.Draw();
            for (int i = 0; i < sides.Count; i++)
            {
                sides[i].Draw();
            }
            for (int i = 0; i < createSides.Count; i++)
            {
                createSides[i].Draw();
            }
            player1.Draw();
            player2.Draw();

            for (int i = 0; i < monsters.Count; i++)
            {
                monsters[i].Draw();
            }

            for (int i = 0; i < patrons.Count; i++)
            {
                patrons[i].Draw();
            }

            for (int i = 0; i < boosts.Count; i++)
            {
                boosts[i].Draw();
            }
            if (monsters.Count == 0)
            {
                if (player1.count > player2.count)
                {
                    gameover1.Draw();
                }
                else
                {
                    gameover2.Draw();
                }
            }
        }
    }
}
