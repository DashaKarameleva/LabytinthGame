using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using labyrinth.bonus;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace labyrinth
{
    class Levels
    {
        public static Bitmap bmp = new Bitmap(Image.FromFile(Game.mape.Mape));


        public static void CreateLevel(List<Sides> sides, List<Monster> monster)
        {
            int[,] ar = new int[bmp.Width, bmp.Height];
                                               
            for (int j = 0; j < bmp.Height; j++)
            {
                for (int i = 0; i < bmp.Width; i++)
                {
                    if (bmp.GetPixel(i, j) == Color.FromArgb(255, 255, 255, 255)) ar[i, j] = 0;
                    else if (bmp.GetPixel(i, j) == Color.FromArgb(255, 0, 0, 0)) ar[i, j] = 1;
                    else if (bmp.GetPixel(i, j) == Color.FromArgb(255, 255, 255, 0)) ar[i, j] = 2;
                    else if (bmp.GetPixel(i, j) == Color.FromArgb(255, 0, 255, 0)) ar[i, j] = 3;
                    else if (bmp.GetPixel(i, j) == Color.FromArgb(255, 255, 0, 0)) ar[i, j] = 9;
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
                    else if (ar[i, j] == 1)
                    {
                        Vector2 sidesPosition = new Vector2(0 + 27 * i, 0 + 27 * j);
                        Sides qwe = new Sides(27, 27, "texture/side3.png", sidesPosition, ar[i, j]);
                        sides.Add(qwe);
                    }
                    //else if (ar[i, j] == 2)
                    //{
                    //    Vector2 sidesPosition = new Vector2(0 + 27 * i, 0 + 27 * j);
                    //    Sides qwe = new Sides(27, 27, "texture/side2.png", sidesPosition, ar[i, j]);
                    //    sides.Add(qwe);
                    //}
                    //else if (ar[i, j] == 3)
                    //{
                    //    Vector2 sidesPosition = new Vector2(0 + 27 * i, 0 + 27 * j);
                    //    Sides qwe = new Sides(27, 27, "texture/side1.png", sidesPosition, ar[i, j]);
                    //    sides.Add(qwe);
                    //}
                    else if (ar[i, j] == 9)
                    {
                        Vector2 sidesPosition = new Vector2(0 + 27 * i, 0 + 27 * j);
                        Monster qwe = new Monster(25, 25, "texture/monster.png", sidesPosition);
                        monster.Add(qwe);
                    }
                }
            }            
        }

        public static List<Sides> FreeSpace(List<Sides> sides)
        {
            List<Sides> freeSpace = new List<Sides>();
            //bool space;
            for (int i = 0; i < sides.Count; i++)
            {
                if (sides[i].type == "Empty")
                {
                    freeSpace.Add(sides[i]);
                }
            }
            return freeSpace;
        }
        static Random rand = new Random();

        public static void CreateMonster(List<Sides> sides, List<Monster> monsters)
        {
            List<Sides> freeSpace = FreeSpace(sides);
           // monsterFactory = GetFactoryMonster(rand.Next(0, 2));
            Monster monster = new Monster(24, 24, "texture/monster.png", freeSpace[rand.Next(1, freeSpace.Count)].Position);
            monsters.Add(monster);
        }
     
        //BONUS

        static BonusFactory bonusFactory;
        public static void CreateBonus(List<Sides> sides, List<Bonus> boosts)
        {
            List<Sides> freeSpace = FreeSpace(sides);
            bonusFactory = GetFactoryBonus(rand.Next(0, 4)); 
            Bonus boost = bonusFactory.GetBoost(24, 24, "texture/bonus.png", freeSpace[rand.Next(0, freeSpace.Count)].Position);
            boosts.Add(boost);
            
        }
        
        private static BonusFactory GetFactoryBonus(int index)
        {

            switch (index)
            {
                case 0: return new SpeedUpFactory();
                case 1: return new HealthFactory();
                case 2: return new ArmorFactory();
                case 3: return new PatronFactory();
            }
            return null;
        }

    
    }
}
