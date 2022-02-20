//using labyrinth;
using labyrinth.bonus;
using labyrinth.Bullet;
using Labyrinth.bonus;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace labyrinth
{
    /// <summary>
    /// 
    /// </summary>
    public class Level
    {
        public Level()
        {
        }
        /// <summary>
        /// The BMP
        /// </summary>
        /// <summary>
        /// Creates the level.
        /// </summary>
        /// <param name="sides">The sides.</param>
        /// <param name="monsters">The monsters.</param>
        public void CreateLevel(List<Sides> sides, List<Monster> monsters)
        {
         Bitmap bmp = new Bitmap(Image.FromFile(Game.mape.Mape));

        int[,] ar = new int[bmp.Width, bmp.Height];
                                               
            for (int j = 0; j < bmp.Height; j++)
            {
                for (int i = 0; i < bmp.Width; i++)
                {
                    if (bmp.GetPixel(i, j) == Color.FromArgb(255, 255, 255, 255)) ar[i, j] = 0;
                    else if (bmp.GetPixel(i, j) == Color.FromArgb(255, 0, 0, 0)) ar[i, j] = 1;
                }
            }
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    if (ar[i, j] == 0)
                    {
                        Vector2 sidesPosition = new Vector2(0 + 27 * i, 0 + 27 * j);
                        Sides qwe = new Sides(27, 27, "", sidesPosition, ar[i, j]);
                        sides.Add(qwe);
                    }
                    else 
                    {
                        Vector2 sidesPosition = new Vector2(0 + 27 * i, 0 + 27 * j);
                        Sides qwe = new Sides(27, 27, "texture/side3.png", sidesPosition, ar[i, j]);
                        sides.Add(qwe);
                    }
                }
            }
            while (monsters.Count < 6 )
            {
                CreateMonster(sides, monsters);
            }
        }
        /// <summary>
        /// Frees the space.
        /// </summary>
        /// <param name="sides">The sides.</param>
        /// <returns></returns>
        public static List<Sides> FreeSpace(List<Sides> sides)
        {
            List<Sides> freeSpace = new List<Sides>();
            for (int i = 0; i < sides.Count; i++)
            {
                if (sides[i].type == "Empty")
                {
                    freeSpace.Add(sides[i]);
                }
            }
            return freeSpace;
        }
        /// <summary>
        /// The rand
        /// </summary>
        static Random rand = new Random();
        /// <summary>
        /// Creates the monster.
        /// </summary>
        /// <param name="sides">The sides.</param>
        /// <param name="monsters">The monsters.</param>
        public void CreateMonster(List<Sides> sides, List<Monster> monsters)
        {
            List<Sides> freeSpace = FreeSpace(sides);
            Monster monster = new Monster(24, 24, "texture/monster.png", freeSpace[rand.Next(0, freeSpace.Count)].Position);
            monsters.Add(monster);
        }
        /// <summary>
        /// The bonus factory
        /// </summary>
        static BonusFactory bonusFactory;

        

        /// <summary>
        /// Creates the bonus.
        /// </summary>
        /// <param name="sides">The sides.</param>
        /// <param name="boosts">The boosts.</param>
        public void CreateBonus(List<Sides> sides, List<Bonus> boosts)
        {
            BonusFactory bonusFactory;
            Random rand = new Random();
            List<Sides> freeSpace = FreeSpace(sides);
            bonusFactory = GetFactoryBonus(rand.Next(0, 5)); 
            Bonus boost = bonusFactory.GetBoost(24, 24, "texture/bonus.png", freeSpace[rand.Next(0, freeSpace.Count)].Position);
            boosts.Add(boost);            
        }

        /// <summary>
        /// Creates the bonus.
        /// </summary>
        /// <param name="sides">The sides.</param>
        /// <param name="boosts">The boosts.</param>
        public void CreateBullet(List<ObjectBullet> patron3,Player player)
        {
           // List<ObjectBullet>patrons = player.BulletMagazine
            Vector2 DirectionMovement = Vector2.Zero;

            switch (player.direction)
            {
                case Direction.Up:
                    DirectionMovement = new Vector2(0, -1);
                    break;
                case Direction.Down:
                    DirectionMovement = new Vector2(0, 1);
                    break;
                case Direction.Left:
                    DirectionMovement = new Vector2(-1, 0);
                    break;
                case Direction.Right:
                    DirectionMovement = new Vector2(1, 0);
                    break;
            }

            ObjectBullet bullet = new ObjectBullet(15, 15, "texture/patron.png", player.Position + DirectionMovement * 26, (int)player.BulletMagazine.Bullets[0].Power);
            bullet.SetDirection(player.direction);
            bullet.Tag = player.Tag;
            patron3.Add(bullet);
        }

        public static void CreateMonsterBullet(List<ObjectBullet> patrons, Monster monster)
        {
            ObjectBullet bullet = new ObjectBullet(15, 15, "texture/patron.png", monster.Position + monster.DirectionMovement * 26, (int)monster.BulletMagazine.Bullets[0].Power);
            bullet.SetDirection(monster.GetDirection());
            patrons.Add(bullet);
        }
        /// <summary>
        /// Gets the factory bonus.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        static BonusFactory GetFactoryBonus(int index)
        {
            switch (index)
            {
                case 0: return new SpeedUpFactory();
                case 1: return new HealthFactory();
                case 2: return new PatronFactory();
                case 3: return new ArmorFactory();
                case 4: return new DoublePatronFactory();
            }
            return null;
        }    
    }
}
