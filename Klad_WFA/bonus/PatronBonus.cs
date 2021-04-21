using labyrinth.Bullet;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labyrinth.bonus
{
    class PatronBonus : Bonus
    {
        public string Type { get; set; } = "Patron";
        public PatronBonus(int width, int height, string filename, Vector2 position) : base(width, height, filename, position)
        {
        }

        public override void UpPlayer(Player player)
        {
            //player.BulletMagazine.Add(new StandartBullet(1, 10));


            active = true;
            this.player = player;
        }

        public override void DefaltPlayer(Player player)
        {
            //player.BulletMagazine = player.BulletMagazine;
        }
    }
}
