using labyrinth;
using labyrinth.bonus;
using labyrinth.Bullet;
using Labyrinth.bonus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenTK;
using System;
using System.Collections.Generic;

namespace labyrinthTests
{
    [TestClass()]
    public class MoveTests : GameWindow
    {
        [TestMethod()]

        public void MoveTest()
        {
            Player player1 = new Player(20, 20, "texture/pl1S.png", new Vector2(35, 35), 1);
            Player player2 = new Player(20, 20, "texture/pl2S.png", new Vector2(1480, 750), 2);
            List<Monster> monsters = new List<Monster> { new Monster(24, 24, "texture/monster.png", new Vector2(40, 40)) };
            List<Sides> sides = new List<Sides> { (new Sides(27, 27, "", new Vector2(35, 34), 0)),
            ( new Sides(27, 27, "", new Vector2(1480, 749), 1)) };
            List<Bonus> boosts = new List<Bonus> { };
            List<ObjectBullet> patrons = new List<ObjectBullet> { new ObjectBullet(15, 15, "texture/patron.png", new Vector2(35, 34), 1) };
            Actions actions = new Actions();
            actions.GameObjectMove( player1,  player2, sides, boosts, monsters, patrons);
        }
    }
}
