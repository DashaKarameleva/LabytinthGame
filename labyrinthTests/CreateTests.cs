using labyrinth;
using labyrinth.bonus;
using labyrinth.Bullet;
using Labyrinth.bonus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenTK;
using System;
using System.Collections.Generic;

namespace labyrinth.Tests
{
    [TestClass()]
    public class CreateTests : GameWindow
    {
        [TestMethod()]
        public void CreatePlayerBulletTest()
        {
            Player player1 = new Player(20, 20, "texture/pl1S.png", new Vector2(35, 35), 1);
            player1.Tag = "player1";
            List<ObjectBullet> patrons = new List<ObjectBullet> { };
            Level level = new Level();

            level.CreateBullet(patrons, player1);
            
        }
        [TestMethod()]
        public void CreateBonusTest()
        {
            List<Sides> sides = new List<Sides> { (new Sides(27, 27, "", new Vector2(35, 34), 0)),
            ( new Sides(27, 27, "", new Vector2(1480, 749), 1)) };
            List<Bonus> boosts = new List<Bonus> { };
            Level level = new Level();
            level.CreateBonus(sides, boosts);

        }
        [TestMethod()]
        public void CreateMonsterTest()
        {
            List<Sides> sides = new List<Sides> { (new Sides(27, 27, "", new Vector2(35, 34), 0)),
            ( new Sides(27, 27, "", new Vector2(1480, 749), 1)) };
            List<Monster> monsters = new List<Monster> { new Monster(24, 24, "texture/monster.png", new Vector2(40, 40)) };
            Level level = new Level();
            level.CreateMonster(sides, monsters);

        }
        [TestMethod()]
        public void RenderingTest()
        {
            Game game = new Game();
            game.Rendering();

        }
    }
}
