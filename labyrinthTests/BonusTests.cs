using labyrinth;
using labyrinth.bonus;
using Labyrinth.bonus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenTK;
using System;
using System.Collections.Generic;

namespace labyrinthTests
{
    [TestClass()]
    public class BonusTests:GameWindow
    {
        [TestMethod()]
        public void GenBonusTest()
        {
            BonusFactory standardBonusFactory = new PatronFactory();
            Bonus standardBoost = standardBonusFactory.GetBoost(24, 24, "texture/bonus.png", new Vector2(40, 40));

            BonusFactory doubleBonusFactory = new DoublePatronFactory();
            Bonus doubleBoost = doubleBonusFactory.GetBoost(24, 24, "texture/bonus.png", new Vector2(50, 50));

            BonusFactory armorBonusFactory = new ArmorFactory();
            Bonus armorBoost = armorBonusFactory.GetBoost(24, 24, "texture/bonus.png", new Vector2(60, 60));

            BonusFactory healthFactory = new HealthFactory();
            Bonus healthBoost = healthFactory.GetBoost(24, 24, "texture/bonus.png", new Vector2(70, 70));

            BonusFactory speedUpFactory = new SpeedUpFactory();
            Bonus speedUpFactoryBoost = speedUpFactory.GetBoost(24, 24, "texture/bonus.png", new Vector2(80, 80));
        }
        [TestMethod()]
        public void UpPlayerBoostTest()
        {
            Level level = new Level();
            List<Sides> sides = new List<Sides> { (new Sides(27, 27, "", new Vector2(35, 34), 0)),
            ( new Sides(27, 27, "", new Vector2(1480, 749), 1)) };
            Player player1 = new Player(20, 20, "texture/pl1S.png", new Vector2(250, 250), 1);
            Player player2 = new Player(20, 20, "texture/pl2S.png", new Vector2(300, 300), 2);
            List<Monster> monsters = new List<Monster> { new Monster(24, 24, "texture/monster.png", new Vector2(40, 40)) };
            Collision collision = new Collision(player1, player2, sides, monsters);
            List<Bonus> boosts = new List<Bonus> { new UpBonus(25, 25, "texture/bonus.png", new Vector2(300, 300)),
            new HealthBonus(25, 25, "texture/bonus.png", new Vector2(250, 250)),
            new ArmorBonus(25, 25, "texture/bonus.png", new Vector2(300, 300)),
            new PatronBonus(25, 25, "texture/bonus.png", new Vector2(250, 250)),
            new DoublePatronBonus(new PatronBonus(25, 25, "texture/bonus.png", new Vector2(200, 200)))};

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
            }
        }
    }
}
