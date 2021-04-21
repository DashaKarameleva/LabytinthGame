using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labyrinth.bonus
{
    class UpBonus : Bonus
    {
        public string Type { get; set; } = "SpeedUp";
        public UpBonus(int width, int height, string filename, Vector2 position) : base(width, height, filename, position)
        {
        }

        public override void UpPlayer(Player player)
        {
            player.speed = 4;
            timeSetMinutes = DateTime.Now.Minute;
            timeSetSecond = DateTime.Now.Second;
            if (timeSetSecond + duration >= 60)
            {
                timeSetMinutes += 1;
                timeSetSecond = timeSetSecond + duration - 60;
            }
            else
            {
                timeSetSecond += duration;
            }

            active = true;
            this.player = player;
        }

        public override void DefaltPlayer(Player player)
        {
            player.speed = 2;
        }
    }
}
