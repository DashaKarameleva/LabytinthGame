using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;


namespace labyrinth
{
    class Monster : GameObject
    {
        public string type = "Monster";
        public Monster(int width, int height, string filename, Vector2 position) : base(width, height, filename, position) { }


        public int Health { get; private set; } = 2;
        public float Speed { get; set; } = 5;
        public bool IsCanMove { get; set; } = true;


        public void MonsterMove(Monster monstr,
        ref float x, ref float y,
        ref float bx1, ref float sx1, ref int l_r)
        {
            X = x;
            Y = y;
            left_right = l_r;
            LX = sx1;
            RX = bx1;
            if (left_right == 1 && Monstr != null) //movement to the right
            {
                if (X < RX)
                {
                    X += Speed;
                    if (X >= RX)
                    {
                        left_right = 0;
                        Random bx = new Random();
                        LX = bx.Next(-800, -200) / 10000f;
                        Y -= RandY;
                        RandY = bx.Next(-100, 800) / 10000f;
                        Y += RandY;
                        Speed -= RandSpeed;
                        RandSpeed = bx.Next(-300, 300) / 100000f;
                        Speed += RandSpeed;
                    }
                }
            }
            if (left_right == 0 && Monstr != null)//movement to the left
            {
                if (X > LX)
                {
                    X -= Speed;
                }
                if (X <= LX)
                {
                    left_right = 1;
                    Random sx = new Random();
                    RX = sx.Next(300, 800) / 1000f;
                    Y -= RandY;
                    RandY = sx.Next(-100, 800) / 10000f;
                    Y += RandY;
                    Speed -= RandSpeed;
                    RandSpeed = sx.Next(-300, 300) / 100000f;
                    Speed += RandSpeed;
                }
            }
        }
    }
}
