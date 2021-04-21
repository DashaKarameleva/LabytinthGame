using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace labyrinth
{
    enum Walls
    {
        Empty,
        
        
        Created
    }
    
    class Sides : GameObject
    {
        Walls types;
        public virtual string type { get; set; }
        protected Sides() : base() { }
        public Sides(int width, int height, string filename, Vector2 position, int id)
            : base(width, height, filename, position)
        {
            types = (Walls)id;
            type = types.ToString();
        }
    }
}
