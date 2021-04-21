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
    public class Game : GameWindow
    {
        Background background;
        Background gameover1;
        Background gameover2;
      public  Player player1, player2;
        List<Sides> sides = new List<Sides>();
        List<Sides> createSides = new List<Sides>();
        List<Bonus> boosts = new List<Bonus>();
        List<Monster> monsters = new List<Monster>();
        BulletMagazine bulletMagazine = new BulletMagazine();

        public static Map mape;


        public Game()
        {
            mape = new Map("texture/Map1.png", "texture/Level1.bmp", new Vector2(35, 35), new Vector2(1480, 750));

            Width = 1557;
            Height = 900;
            Location = new Point(0, 0);
            Levels.CreateLevel(sides, monsters);

            background = new Background(Width, Height, "texture/background.jpg");
            gameover1 = new Background(Width, Height, "texture/pl1Win.png");
            gameover2 = new Background(Width, Height, "texture/pl2Win.png");
            player1 = new Player(25, 25, "texture/pl1S.png", mape.Position1Player, 1);
            player2 = new Player(25, 25, "texture/pl2S.png", mape.Position2Player, 2);


        }

        public void Rendering()
        {
            KeyboardState kb_state = Keyboard.GetState();
            if (kb_state.IsKeyDown(Key.Escape)) Exit();
            if (monsters.Count != 0)
            {
                GameEvents.ChangeHealthPlayer?.Invoke(player1.health, player2.health);
                GameEvents.ChangeArmor?.Invoke(player1.armor, player2.armor);
                GameEvents.ChangePlayerPoints?.Invoke(player1.count, player2.count);

                Actions.PlayersMoves(player1, player2, sides, boosts, monsters, createSides);


              //  GameEvents.ChangePatronCount?.Invoke(player1.BulletMagazine.Bullets.Count, player2.BulletMagazine.Bullets.Count);
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
