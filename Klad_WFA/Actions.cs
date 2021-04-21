using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using labyrinth.maze;
using labyrinth.bonus;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;


namespace labyrinth
{
    class Actions
    {
        public static void PlayersMoves(Player player1, Player player2, List<Sides> sides, List<Bonus> boosts, List<Monster> monsters, List<Sides> createSides)
        {
            
            Collision collision = new Collision(player1, player2, sides, createSides);

            KeyboardState kb_state = Keyboard.GetState();

            if (boosts.Count < 10)
            {
                Levels.CreateBonus(sides, boosts);
            }

            //if (monsters.Count < 6)
            //{
            //    Levels.CreateMonster(sides, monsters);
            //}




            //MOVE
            //PL1
            if (kb_state.IsKeyDown(Key.D))
            {            
                if (collision.MoveD()) player1.Move(new Vector2(+player1.speed, 0));
                player1.direction = Direction.Right;
            }
            if (kb_state.IsKeyDown(Key.A))
            {
                if(collision.MoveA()) player1.Move(new Vector2(-player1.speed, 0));
                player1.direction = Direction.Left;
            }
            if (kb_state.IsKeyDown(Key.W))
            {
                if(collision.MoveW()) player1.Move(new Vector2(0, -player1.speed));
                player1.direction = Direction.Up;
            }
            if (kb_state.IsKeyDown(Key.S))
            {
                if(collision.MoveS()) player1.Move(new Vector2(0, +player1.speed));
                player1.direction = Direction.Down;
            }

            //PL2
            if (kb_state.IsKeyDown(Key.Left))
            {
                if(collision.MoveLeft()) player2.Move(new Vector2(-player2.speed, 0));
                player2.direction = Direction.Left;
            }
            if (kb_state.IsKeyDown(Key.Right))
            {
                if(collision.MoveRight()) player2.Move(new Vector2(+player2.speed, 0));
                player2.direction = Direction.Right;
            }
            if (kb_state.IsKeyDown(Key.Up))
            {
                if(collision.MoveUp()) player2.Move(new Vector2(0, -player2.speed));
                player2.direction = Direction.Up;
            }
            if (kb_state.IsKeyDown(Key.Down))
            {
                if(collision.MoveDown()) player2.Move(new Vector2(0, +player2.speed));
                player2.direction = Direction.Down;
            }


            //DESTROY
            //for (int i = 0; i < sides.Count; i++)
            //{
            //    if (kb_state.IsKeyDown(Key.E) && player1.destroy && sides[i].type == "TemporaryDestructible" && collision.DestroyCollision(player1, sides[i]))
            //    {
            //        sides[i] = new RestorationSides(sides[i], player1);
            //    }
            //    if (kb_state.IsKeyDown(Key.E) && player1.destroy && sides[i].type == "Destructible" && collision.DestroyCollision(player1, sides[i]))
            //    {
            //        sides[i] = new DestroySides(sides[i], player1);
            //    }
            //    if (kb_state.IsKeyDown(Key.Keypad1) && player2.destroy && sides[i].type == "TemporaryDestructible" && collision.DestroyCollision(player2, sides[i]))
            //    {
            //        sides[i] = new RestorationSides(sides[i], player2);
            //    }
            //    if (kb_state.IsKeyDown(Key.Keypad1) && player2.destroy && sides[i].type == "Destructible" && collision.DestroyCollision(player2, sides[i]))
            //    {
            //        sides[i] = new DestroySides(sides[i], player2);
            //    }
            //}
            //for (int i = 0; i < sides.Count; i++)
            //{
            //    if (sides[i] is SidesDecorator && ((SidesDecorator)sides[i]).IsDecorate && ((SidesDecorator)sides[i]).TimeSetMinutes <= DateTime.Now.Minute)
            //    {
            //        if (((SidesDecorator)sides[i]).TimeSetMinutes < DateTime.Now.Minute || ((SidesDecorator)sides[i]).TimeSetSeconds <= DateTime.Now.Second && !collision.DestroyCollision(player1, sides[i]) && !collision.DestroyCollision(player2, sides[i]))
            //        {
            //            sides[i] = ((SidesDecorator)sides[i]).GetOldSides();
            //        }
            //    }
            //}

            ////CREATE
            //if (kb_state.IsKeyDown(Key.Q) && player1.create)
            //{
            //    if (player1.direction == Direction.Left)
            //    {
            //        createSides.Add(new Sides(27, 27, "texture/side0.png", player1.Position + new Vector2(-30, 0), 4));
            //    }
            //    else if (player1.direction == Direction.Right)
            //    {
            //        createSides.Add(new Sides(27, 27, "texture/side0.png", player1.Position + new Vector2(+30, 0), 4));
            //    }
            //    else if (player1.direction == Direction.Up)
            //    {
            //        createSides.Add(new Sides(27, 27, "texture/side0.png", player1.Position + new Vector2(0, -30), 4));
            //    }
            //    else if (player1.direction == Direction.Down)
            //    {
            //        createSides.Add(new Sides(27, 27, "texture/side0.png", player1.Position + new Vector2(0, +30), 4));
            //    }
            //}
            //if (kb_state.IsKeyDown(Key.Keypad2) && player2.create)
            //{
            //    if (player2.direction == Direction.Left)
            //    {
            //        createSides.Add(new Sides(27, 27, "texture/side0.png", player2.Position + new Vector2(-30, 0), 5));
            //    }
            //    else if (player2.direction == Direction.Right)
            //    {
            //        createSides.Add(new Sides(27, 27, "texture/side0.png", player2.Position + new Vector2(+30, 0), 5));
            //    }
            //    else if (player2.direction == Direction.Up)
            //    {
            //        createSides.Add(new Sides(27, 27, "texture/side0.png", player2.Position + new Vector2(0, -30), 5));
            //    }
            //    else if (player2.direction == Direction.Down)
            //    {
            //        createSides.Add(new Sides(27, 27, "texture/side0.png", player2.Position + new Vector2(0, +30), 5));
            //    }
            //}
            //for (int i = 0; i < createSides.Count; i++)
            //{
            //    if (player1.create && createSides[i].type == "CreateBypl1" && !collision.CreateCollision(player2, createSides[i]))
            //    {
            //        createSides[i] = new CreateSides(createSides[i], player1);
            //    }

            //    if (player2.create && createSides[i].type == "CreateBypl2" && !collision.CreateCollision(player1, createSides[i]))
            //    {
            //        createSides[i] = new CreateSides(createSides[i], player2);
            //    }

            //    if (createSides.Count != 0 && createSides[i].type == "CreateBypl2") createSides.RemoveAt(i);
            //    if (createSides.Count != 0 && createSides[i].type == "CreateBypl1") createSides.RemoveAt(i);

            //}
            //for (int i = 0; i < createSides.Count; i++)
            //{

            //    if (createSides[i] is SidesDecorator && ((SidesDecorator)createSides[i]).IsDecorate && ((SidesDecorator)createSides[i]).TimeSetMinutes <= DateTime.Now.Minute)
            //    {
            //        if (((SidesDecorator)createSides[i]).TimeSetMinutes < DateTime.Now.Minute || ((SidesDecorator)createSides[i]).TimeSetSeconds < DateTime.Now.Second)
            //        {
            //            createSides[i] = ((SidesDecorator)createSides[i]).GetOldSides();
            //            createSides.RemoveAt(i);
            //            i--;
            //        }
            //    }
            //}


            //BOOSTS
            for (int i = 0; i < boosts.Count; i++)
            {
                //up
                if (collision.IsCanBoosts(player1, boosts[i]) && !boosts[i].active)
                {
                    boosts[i].UpPlayer(player1);
                }
                else if (collision.IsCanBoosts(player2, boosts[i]) && !boosts[i].active)
                {
                    boosts[i].UpPlayer(player2);
                }



                //down
                if (boosts[i] is UpBonus)
                {
                    if (boosts[i].active && boosts[i].timeSetMinutes <= DateTime.Now.Minute)
                    {
                        if (boosts[i].timeSetSecond <= DateTime.Now.Second)
                        {
                            if (boosts[i].player == player1)
                            {
                                boosts[i].DefaltPlayer(player1);
                            }
                            else
                            {
                                boosts[i].DefaltPlayer(player2);
                            }
                            boosts.RemoveAt(i);
                            i--;
                        }
                    }
                }

            }



            //TREASURE
            for (int i = 0; i < monsters.Count; i++)
            {
                if (collision.DestroyCollision(player1, monsters[i]))
                {
                    monsters.RemoveAt(i);
                    player1.count++;
                }
            }
            for (int i = 0; i < monsters.Count; i++)
            {
                if (collision.DestroyCollision(player2, monsters[i]))
                {
                    monsters.RemoveAt(i);
                    player2.count++;
                }
            }
        }
    }
}

