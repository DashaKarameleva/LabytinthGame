using OpenTK.Graphics.OpenGL;
using System;
using System.Drawing;
using System.Windows.Forms;
using labyrinth;
using labyrinth.Bullet;

namespace WinFormsGame
{
    /// <summary>
    ///   <br />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class GameForm : Form
    {
        /// <summary>
        /// The game
        /// </summary>
        Game game = new Game();

        /// <summary>
        /// The loaded
        /// </summary>
        private bool _loaded;
        /// <summary>
        /// Initializes a new instance of the <see cref="GameForm"/> class.
        /// </summary>
        public GameForm()
        {
            
            Location = new Point(0, 0);
            InitializeComponent();
            GameEvents.ChangeHealthPlayer += ChangeHealthPlayer;
            GameEvents.ChangeArmor += ChangeArmor;
            GameEvents.ChangePatronCount += ChangePatronCount;
            GameEvents.ChangePlayerPoints += ChangePlayerPoints;
          
            pictureBox1.Image = Image.FromFile("texture/healthHeart.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = Image.FromFile("texture/healthHeart.png");
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

            armor.Image = Image.FromFile("texture/armor.png");
            armor.SizeMode = PictureBoxSizeMode.StretchImage;
            armor3.Image = Image.FromFile("texture/armor.png");
            armor3.SizeMode = PictureBoxSizeMode.StretchImage;

            patron1.Image = Image.FromFile("texture/patron.png");
            patron1.SizeMode = PictureBoxSizeMode.StretchImage;
            patron2.Image = Image.FromFile("texture/patron.png");
            patron2.SizeMode = PictureBoxSizeMode.StretchImage;

            points.Image = Image.FromFile("texture/points.png");
            points.SizeMode = PictureBoxSizeMode.StretchImage;
            pointsA.Image = Image.FromFile("texture/points.png");
            pointsA.SizeMode = PictureBoxSizeMode.StretchImage;

        }
        /// <summary>
        /// Changes the health player.
        /// </summary>
        /// <param name="valueHealth1">The value health1.</param>
        /// <param name="valueHealth2">The value health2.</param>
        private void ChangeHealthPlayer(int valueHealth1, int valueHealth2)
        {
            
                health1.Text = valueHealth1.ToString();
                health2.Text = valueHealth2.ToString();
        }
        /// <summary>
        /// Changes the armor.
        /// </summary>
        /// <param name="valueArmor1">The value armor1.</param>
        /// <param name="valueArmor2">The value armor2.</param>
        private void ChangeArmor(int valueArmor1, int valueArmor2)
        {

            armor1.Text = valueArmor1.ToString();
            armor2.Text = valueArmor2.ToString();
        }
        /// <summary>
        /// Changes the player points.
        /// </summary>
        /// <param name="valuePoints1">The value points1.</param>
        /// <param name="valuePoints2">The value points2.</param>
        private void ChangePlayerPoints(int valuePoints1, int valuePoints2)
        {

            points1.Text = valuePoints1.ToString();
            points2.Text = valuePoints2.ToString();
        }
        /// <summary>
        /// Changes the patron count.
        /// </summary>
        /// <param name="valuePatronCount1">The value patron count1.</param>
        /// <param name="valuePatronCount2">The value patron count2.</param>
        private void ChangePatronCount(int valuePatronCount1, int valuePatronCount2)
        {

            patronCount1.Text = valuePatronCount1.ToString();
            patronCount2.Text = valuePatronCount2.ToString();
        }
        /// <summary>
        /// Handles the Load event of the GLControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the Idle event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void Application_Idle(object sender, EventArgs e)
        {
            while (gLControl.IsIdle)
            {
                Render();
            }
        }

        /// <summary>
        /// Renders this instance.
        /// </summary>
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

        /// <summary>
        /// Handles the Resize event of the GLControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void GLControl_Resize(object sender, EventArgs e)
        {
            if (!_loaded)
                return;
            GL.Viewport(0, 0, gLControl.Width, gLControl.Height);
            gLControl.Invalidate();
        }

        /// <summary>
        /// Handles the Click event of the health1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void health1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the label1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the label2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void label2_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the pictureBox1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //pictureBox1.BackColar = NoNullAllowedException;

            

        }

        /// <summary>
        /// Handles the Click event of the pictureBox2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the patronCount1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void patronCount1_Click(object sender, EventArgs e)
        {

        }
    }
}
