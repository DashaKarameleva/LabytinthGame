using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Threading;
using OpenTK.Graphics.ES10;
using DataType = OpenTK.Graphics.OpenGL.DataType;

namespace Klad_WFA
{
    class PlayerMove
    {
        public static int player1Count = 0;
        public static int player2Count = 0;



        public static void PlayersMoves(Player player1, Player player2, List<Sides> sides, List<Boost> boosts)
        {

            Collision collision = new Collision(player1, player2, sides, boosts);
            bool Player1Boost = false;
            bool Player2Boost = false;
            List<Sides> freeSpace = Levels.FreeSpace(sides);
            Random rand = new Random();
            KeyboardState kb_state = Keyboard.GetState();



            //MOVE
            //PL1
            if (kb_state.IsKeyDown(Key.D) && collision.MoveD())
            {
                player1.Move(new Vector2(+player1.speed, 0));
            }
            if (kb_state.IsKeyDown(Key.A) && collision.MoveA())
            {
                player1.Move(new Vector2(-player1.speed, 0));
            }
            if (kb_state.IsKeyDown(Key.W) && collision.MoveW())
            {
                player1.Move(new Vector2(0, -player1.speed));
            }
            if (kb_state.IsKeyDown(Key.S) && collision.MoveS())
            {
                player1.Move(new Vector2(0, +player1.speed));
            }
            //PL2
            if (kb_state.IsKeyDown(Key.Left) && collision.MoveLeft())
            {
                player2.Move(new Vector2(-player2.speed, 0));
            }
            if (kb_state.IsKeyDown(Key.Right) && collision.MoveRight())
            {
                player2.Move(new Vector2(+player2.speed, 0));
            }
            if (kb_state.IsKeyDown(Key.Up) && collision.MoveUp())
            {
                player2.Move(new Vector2(0, -player2.speed));
            }
            if (kb_state.IsKeyDown(Key.Down) && collision.MoveDown())
            {
                player2.Move(new Vector2(0, +player2.speed));
            }
            

            //DESTRUCTABLE
            for (int i = 0; i < sides.Count; i++) 
            {
                if (kb_state.IsKeyDown(Key.E) && sides[i].type == "Destructible" && collision.DestroyCollision(player1, sides[i]))
                {
                    sides[i] = new Sides(27, 27, "texture/side0.png", sides[i].Position, 0);
                }
            }
            for (int i = 0; i < sides.Count; i++)
            {
                if (kb_state.IsKeyDown(Key.Keypad1) && sides[i].type == "Destructible" && collision.DestroyCollision(player2, sides[i]))
                {
                    sides[i] = new Sides(27, 27, "texture/side0.png", sides[i].Position, 0);
                }
            }
            

            //BOOSTS
            for (int i = 0; i < boosts.Count; i++)
            {
                if (collision.SpeedBoosts(player1, boosts[i], Player1Boost))
                {
                    if (boosts[i].type == "Increase")
                    {
                        player1.speed = 4;
                        boosts[i] = new Boost(24, 24, "texture/SpeedUp.png", freeSpace[rand.Next(0, freeSpace.Count)].Position, rand.Next(0, 2));
                    }
                    else if (boosts[i].type == "Reduce")
                    {
                        player1.speed = 1;
                        boosts[i] = new Boost(24, 24, "texture/SpeedUp.png", freeSpace[rand.Next(0, freeSpace.Count)].Position, rand.Next(0, 2));
                    }
                }
            }
            for (int i = 0; i < boosts.Count; i++)
            {
                if (collision.SpeedBoosts(player2, boosts[i], Player2Boost))
                {
                    if (boosts[i].type == "Increase")
                    {
                        player2.speed = 4;
                        boosts[i] = new Boost(24, 24, "texture/SpeedUp.png", freeSpace[rand.Next(0, freeSpace.Count)].Position, rand.Next(0, 2));
                    }
                    else if (boosts[i].type == "Reduce")
                    {
                        player2.speed = 1;
                        boosts[i] = new Boost(24, 24, "texture/SpeedUp.png", freeSpace[rand.Next(0, freeSpace.Count)].Position, rand.Next(0, 2));
                    }
                }
            }


            //TREASURE
            for (int i = 0; i < sides.Count; i++)
            {
                if (sides[i].type == "Treasure" && collision.DestroyCollision(player1, sides[i]))
                {
                    sides[i] = new Sides(27, 27, "texture/side0.png", sides[i].Position, 0);
                    player1Count++;
                }
            }
            for (int i = 0; i < sides.Count; i++)
            {
                if (sides[i].type == "Treasure" && collision.DestroyCollision(player2, sides[i]))
                {
                    sides[i] = new Sides(27, 27, "texture/side0.png", sides[i].Position, 0);
                    player2Count++;
                }
            }    
        }
    }
}

