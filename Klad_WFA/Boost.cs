using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Klad_WFA
{
    class Boost : GameObject
    {
        public string[] types = new string[] { "Increase", "Reduce" };

        public string type;
        public Boost(int width, int height, string filename, Vector2 position, int id)
    : base(width, height, filename, position)
        {
            type = types[id];
        }
    }
}
