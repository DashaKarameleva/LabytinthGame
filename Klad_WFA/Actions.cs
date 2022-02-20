using System;
using System.Collections.Generic;
using System.Threading;
using labyrinth;
using labyrinth.bonus;
using labyrinth.Bullet;
using OpenTK;
using OpenTK.Input;
namespace labyrinth
{
    /// <summary>
    /// 
    /// </summary>
    public class Actions
    {
        static bool isShotPlayer1 = true;
        static bool isShotPlayer2 = true;
        static bool isSwitchPlayer1 = true;
        static bool isSwitchPlayer2 = true;
        private static Level level = new Level();
        static List<GameObject> RemoveList = new List<GameObject>();

        /// <summary>
        /// Games the object move.
        /// </summary>
        /// <param name="player1">The player1.</param>
        /// <param name="player2">The player2.</param>
        /// <param name="sides">The sides.</param>
        /// <param name="boosts">The boosts.</param>
        /// <param name="monsters">The monsters.</param>
        public void GameObjectMove(Player player1, Player player2, List<Sides> sides, List<Bonus> boosts, List<Monster> monsters, List<ObjectBullet> patrons)
        {
            Collision collision = new Collision(player1, player2, sides, monsters);
            KeyboardState kb_state = Keyboard.GetState();
            if (boosts.Count < 15)
            {
                level.CreateBonus(sides, boosts);
            } 
            if (kb_state.IsKeyDown(Key.D))
            {
                if (collision.MoveD()) player1.Move(new Vector2(+player1.speed, 0));
                player1.SetDirection(Direction.Right);
            }
            if (kb_state.IsKeyDown(Key.A))
            {
                if (collision.MoveA()) player1.Move(new Vector2(-player1.speed, 0));
                player1.SetDirection(Direction.Left);
            }
            if (kb_state.IsKeyDown(Key.W))
            {
                if (collision.MoveW()) player1.Move(new Vector2(0, -player1.speed));
                player1.SetDirection(Direction.Up);
            }
            if (kb_state.IsKeyDown(Key.S))
            {
                if (collision.MoveS()) player1.Move(new Vector2(0, +player1.speed));
                player1.SetDirection(Direction.Down);
            }
            if (kb_state.IsKeyDown(Key.Left))
            {
                if (collision.MoveLeft()) player2.Move(new Vector2(-player2.speed, 0));
                player2.SetDirection(Direction.Left);
            }
            if (kb_state.IsKeyDown(Key.Right))
            {
                if (collision.MoveRight()) player2.Move(new Vector2(+player2.speed, 0));
                player2.SetDirection(Direction.Right);
            }
            if (kb_state.IsKeyDown(Key.Up))
            {
                if (collision.MoveUp()) player2.Move(new Vector2(0, -player2.speed));
                player2.SetDirection(Direction.Up);
            }
            if (kb_state.IsKeyDown(Key.Down))
            {
                if (collision.MoveDown()) player2.Move(new Vector2(0, +player2.speed));
                player2.SetDirection(Direction.Down);
            }
            if (kb_state.IsKeyDown(Key.Down))
            {
                if (collision.MoveDown()) player2.Move(new Vector2(0, +player2.speed));
                player2.SetDirection(Direction.Down);
            }
            if (kb_state.IsKeyDown(Key.Space) && isShotPlayer1)
            {
                if(player1.BulletMagazine.Bullet.Shot())
                    level.CreateBullet(patrons, player1);

                isShotPlayer1 = false;
            }
            if (kb_state.IsKeyUp(Key.Space))
            {
                isShotPlayer1 = true;
            }

            if (kb_state.IsKeyDown(Key.E) && isSwitchPlayer1)
            {
                player1.BulletMagazine.Switch();

                isSwitchPlayer1 = false;
            }
            if (kb_state.IsKeyUp(Key.E))
            {
                isSwitchPlayer1 = true;
            }

            if (kb_state.IsKeyDown(Key.KeypadEnter) && isSwitchPlayer2)
            {
                player2.BulletMagazine.Switch();

                isSwitchPlayer2 = false;
            }
            if (kb_state.IsKeyUp(Key.KeypadEnter))
            {
                isSwitchPlayer2 = true;
            }

            if (kb_state.IsKeyDown(Key.Keypad0) && isShotPlayer2)
            {
                if (player2.BulletMagazine.Bullet.Shot())
                    level.CreateBullet(patrons, player2);
              
                isShotPlayer2 = false;
            }
            if (kb_state.IsKeyUp(Key.Keypad0))
            {
                isShotPlayer2 = true;
            }

            for (int j = 0; j < boosts.Count; j++)
            {
                if (collision.IsCanBoosts(player1, boosts[j]) && !boosts[j].active)
                {
                    boosts[j].UpPlayer(player1);
                    if (!(boosts[j] is UpBonus))
                    {
                        boosts.RemoveAt(j);
                        level.CreateBonus(sides, boosts);
                    }

                }
                else if (collision.IsCanBoosts(player2, boosts[j]) && !boosts[j].active)
                {
                    boosts[j].UpPlayer(player2);
                    if (!(boosts[j] is UpBonus))
                    {
                        boosts.RemoveAt(j);
                        level.CreateBonus(sides, boosts);
                    }

                }
                
                if (boosts[j] is UpBonus)
                {
                    if (boosts[j].active && boosts[j].timeSetMinutes <= DateTime.Now.Minute)
                    {
                        if (boosts[j].timeSetSecond <= DateTime.Now.Second)
                        {
                            if (boosts[j].player == player1)
                            {
                                boosts[j].DefaltPlayer(player1);
                            }
                            else
                            {
                                boosts[j].DefaltPlayer(player2);
                            }
                            boosts.RemoveAt(j);
                            j--;
                        }
                    }
                }
            }
            for (int l = 0; l < monsters.Count; l++)
            {
                if (collision.DestroyCollision(player1, monsters[l]))
                {
                   
                        player1.health = 10;
                        player1.Position = new Vector2(35, 35);
                        
                    
                }
            }
            for (int j = 0; j < monsters.Count; j++)
            {
                if (collision.DestroyCollision(player2, monsters[j]))
                {
                    
                        player2.health = 10;
                        player2.Position = new Vector2(1480, 750);
                        
                   
                }
            }
            foreach (Monster monster in monsters)
            {
                if (!collision.MonsterMoveRight(monster))
                {
                    monster.SetDirection(Direction.Left);
                }

                if (!collision.MonsterMoveLeft(monster))
                {
                    monster.SetDirection(Direction.Right);
                }

                monster.Move();
                if (DateTime.Now.Millisecond > 1 && DateTime.Now.Millisecond < 59)
                {
                    Level.CreateMonsterBullet(patrons, monster);
                }
            }
            foreach (var patron in patrons)
            {
                if (collision.DestroyCollision(player2, patron))
                {
                   
                    if(player2.armor>= patron.Power) player2.armor -= patron.Power;
                    else player2.health -= patron.Power;
                    if(player2.health <= 0)
                    {
                        player2.health = 10;
                            if (player2.count >= 1)
                            player2.count-=1;
                        player2.Position = new Vector2(1480, 750);
                    }
                    RemoveList.Add(patron);

                }

                if (collision.DestroyCollision(player1, patron))
                {
                    if(player1.armor>= patron.Power) player1.armor -= patron.Power;
                    else player1.health -= patron.Power;
                    if (player1.health <= 0)
                    {
                        player1.health = 10;
                        if(player1.count>=1)
                        player1.count -= 1; 
                        player1.Position = new Vector2(35, 35);
                    }
                    RemoveList.Add(patron);
                }
                for(int i=0;i<monsters.Count;i++)
               // foreach(var monster in monsters)
                {
                    if (collision.DestroyCollision(monsters[i], patron))
                    {
                        monsters[i].Health -= patron.Power;
                        RemoveList.Add(patron);
                        if (monsters[i].Health <= 0 && patron.Tag == "player1")
                        {
                            monsters.RemoveAt(i);
                            player1.count++;
                        }
                        else if (monsters[i].Health <= 0 && patron.Tag == "player2")
                        {
                            monsters.RemoveAt(i);
                            player2.count++;
                        }

                    }
                }

                foreach (var side in sides)
                {
                    if (side.type != "Empty" && collision.DestroyCollision(patron,side))
                    {
                        RemoveList.Add(patron);
                    }
                }

                patron.Move();
            }

            if(RemoveList.Count > 0)
            {
                foreach (var obj in RemoveList)
                {
                    patrons.Remove((ObjectBullet) obj);
                    //((ObjectBullet)obj).Dispose();
                }
            }
        }
    }
}

