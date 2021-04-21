 using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labyrinth
{
    public class Map
    {
        public string Picture { get; set; }
        public string Mape { get; set; }
        public Vector2 Position1Player { get; set; }
        public Vector2 Position2Player { get; set; }

        public Map(string picture, string mape, Vector2 pl1p, Vector2 pl2p)
        {
            Picture = picture;
            Mape = mape;
            Position1Player = pl1p;
            Position2Player = pl2p;
        }

    }
}
