using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace labyrinth
{
    abstract class Bonus : GameObject
    {
        public int timeSetMinutes;
        public int timeSetSecond;
        public int duration;
        public bool active = false;
        public Player player;

        public Bonus(int width, int height, string filename, Vector2 position): base(width, height, filename, position)
        {
            duration = 5;
        }

        abstract public void UpPlayer(Player player);

        abstract public void DefaltPlayer(Player player);

        public override void Draw()
        {
            if (!active)
            {
                base.Draw();
            }
        }

    }
}
