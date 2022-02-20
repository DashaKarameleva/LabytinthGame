using Microsoft.VisualStudio.TestTools.UnitTesting;
using labyrinth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using labyrinth.Bullet;

namespace labyrinth.Tests
{
    [TestClass()]
    public class CollisionTests : GameWindow
    {
         
        [TestMethod()]
        public void CollisionPlayerMonsterTest()
        {
             List<Sides> sides = new List<Sides> { (new Sides(27, 27, "", new Vector2(35, 34), 0)),
            ( new Sides(27, 27, "", new Vector2(1480, 749), 1)) };
             Player player1 = new Player(20, 20, "texture/pl1S.png", new Vector2(35, 35), 1);
             Player player2 = new Player(20, 20, "texture/pl2S.png", new Vector2(1480, 750), 2);
             List<Monster> monsters = new List<Monster> { new Monster(24, 24, "texture/monster.png", new Vector2(40, 40)) };
            Collision collision = new Collision(player1, player2, sides, monsters);
            Assert.IsFalse(collision.DestroyCollision(player2, monsters[0]));
        }
        [TestMethod()]
        public void CollisionBulletSideTest()
        {
            List<Sides> sides = new List<Sides> { (new Sides(27, 27, "", new Vector2(35, 34), 0)),
            ( new Sides(27, 27, "", new Vector2(1480, 749), 1)) };
            Player player1 = new Player(20, 20, "texture/pl1S.png", new Vector2(35, 35), 1);
            Player player2 = new Player(20, 20, "texture/pl2S.png", new Vector2(1480, 750), 2);
            List<Monster> monsters = new List<Monster> { new Monster(24, 24, "texture/monster.png", new Vector2(40, 40)) };
            Collision collision = new Collision(player1, player2, sides, monsters);
            List<ObjectBullet> patrons = new List<ObjectBullet> { new ObjectBullet(15, 15, "texture/patron.png", new Vector2(35, 34), 1) };
            Assert.IsTrue(collision.DestroyCollision(patrons[0], sides[0]));

            
        }
        [TestMethod()]
        public void CollisionMonsterSideTest()
        {
            List<Sides> sides = new List<Sides> { (new Sides(27, 27, "", new Vector2(35, 34), 0)),
            ( new Sides(27, 27, "", new Vector2(1480, 749), 1)) };
            Player player1 = new Player(20, 20, "texture/pl1S.png", new Vector2(35, 35), 1);
            Player player2 = new Player(20, 20, "texture/pl2S.png", new Vector2(1480, 750), 2);
            List<Monster> monsters = new List<Monster> { new Monster(24, 24, "texture/monster.png", new Vector2(40, 40)) };
            Collision collision = new Collision(player1, player2, sides, monsters);
            List<ObjectBullet> patrons = new List<ObjectBullet> { new ObjectBullet(15, 15, "texture/patron.png", new Vector2(35, 34), 1) };
            Assert.IsTrue(collision.DestroyCollision(monsters[0], sides[0]));
        }
        [TestMethod()]
        public void CollisionRiseTest()
        {
            List<Sides> sides = new List<Sides> { (new Sides(27, 27, "", new Vector2(35, 34), 0)),
            ( new Sides(27, 27, "", new Vector2(1480, 749), 1)) };
            Player player1 = new Player(20, 20, "texture/pl1S.png", new Vector2(35, 35), 1);
            Player player2 = new Player(20, 20, "texture/pl2S.png", new Vector2(1480, 750), 2);
            List<Monster> monsters = new List<Monster> { new Monster(24, 24, "texture/monster.png", new Vector2(40, 40)) };
            Collision collision = new Collision(player1, player2, sides, monsters);
            Assert.IsFalse(collision.RiseDown(player1, sides[0]));
            Assert.IsFalse(collision.RiseLeft(player1, sides[0]));
            Assert.IsFalse(collision.RiseRight(player1, sides[0]));
            Assert.IsFalse(collision.RiseUp(player1, sides[0]));


        }

    }
}