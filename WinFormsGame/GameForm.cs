using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using labyrinth;
using labyrinth.Bullet;

namespace WinFormsGame
{
    public partial class GameForm : Form
    {
        Game game = new Game();

        private bool _loaded;
        public GameForm()
        {
            Location = new Point(0, 0);
            InitializeComponent();
            GameEvents.ChangeHealthPlayer += ChangeHealthPlayer;
            GameEvents.ChangeArmor += ChangeArmor;
            GameEvents.ChangePatronCount += ChangePatronCount;
            GameEvents.ChangePlayerPoints += ChangePlayerPoints;

        }
        private void ChangeHealthPlayer(int valueHealth1, int valueHealth2)
        {
            
                health1.Text = valueHealth1.ToString();
                health2.Text = valueHealth2.ToString();
        }
        private void ChangeArmor(int valueArmor1, int valueArmor2)
        {

            armor1.Text = valueArmor1.ToString();
            armor2.Text = valueArmor2.ToString();
        }
        private void ChangePlayerPoints(int valuePoints1, int valuePoints2)
        {

            points1.Text = valuePoints1.ToString();
            points2.Text = valuePoints2.ToString();
        }
        private void ChangePatronCount(int valuePatronCount1, int valuePatronCount2)
        {

            patronCount1.Text = valuePatronCount1.ToString();
            patronCount2.Text = valuePatronCount2.ToString();
        }
        private void GLControl_Load(object sender, EventArgs e)
        {
            GL.Enable(EnableCap.Blend);
            GL.Enable(EnableCap.Texture2D);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            GL.Viewport(0, 0, gLControl.Width, gLControl.Height);

            _loaded = true;

            gLControl.Invalidate();

            Application.Idle += Application_Idle;
        }

        void Application_Idle(object sender, EventArgs e)
        {
            while (gLControl.IsIdle)
            {
                Render();
            }
        }

        private void Render()
        {

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(System.Drawing.Color.CornflowerBlue);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, gLControl.Width, gLControl.Height, 0, -1, 1);

            game.Rendering();

            gLControl.SwapBuffers();
        }

        private void GLControl_Resize(object sender, EventArgs e)
        {
            if (!_loaded)
                return;
            GL.Viewport(0, 0, gLControl.Width, gLControl.Height);
            gLControl.Invalidate();
        }

        private void health1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
