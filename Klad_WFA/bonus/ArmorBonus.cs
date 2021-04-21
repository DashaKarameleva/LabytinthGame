using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labyrinth.bonus
{
    class ArmorBonus : Bonus
    {
        public string Type { get; set; } = "Armor";
        public ArmorBonus(int width, int height, string filename, Vector2 position) : base(width, height, filename, position)
        {
        }

        public override void UpPlayer(Player player)
        {
            player.armor += 2;
        

            active = true;
            this.player = player;
        }

        public override void DefaltPlayer(Player player)
        {
            player.armor = player.armor;
        }
    }
}
