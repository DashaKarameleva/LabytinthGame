using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Klad_WFA
{
    class Sides : GameObject
    {
        public string[] types = new string[] { "Walkable", "Indestructible", "Destructible", "TemporaryDestructible", "Constructed", "Treasure" };
        public string type;
        
        
        public Sides(int width, int height, string filename, Vector2 position, int id)
            : base(width, height, filename, position)
        {
            type = types[id];
        }
    }
}
