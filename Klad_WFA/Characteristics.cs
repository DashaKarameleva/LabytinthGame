using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labyrinth
{
    class Characteristics : GameObject
    {
        //Characteristics types;
       // public virtual string type { get; set; }
        protected Characteristics() : base() { }
       // public Vector2 HealthPosition {  set { new Point(300, 300); } }
        public Characteristics(int width, int height, string filename, Vector2 position, Player player)
            : base(width, height, filename, position)
        {
            Label health1 = new Label();
            health1.Text = player.health.ToString();
            health1.Width = width;
            health1.Height = height;
            health1.Visible = true;
            
            health1.Location = new Point(50, 50); 
            health1.BackColor = Color.Red;
           // health1.
        }

        

        

    }
}
