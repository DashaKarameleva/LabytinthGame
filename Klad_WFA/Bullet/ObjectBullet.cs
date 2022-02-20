
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labyrinth.Bullet
{
    public class ObjectBullet : GameObject
    {
        public string Tag { get; set; }
        /// <summary>
        /// The type
        /// </summary>
        public string type = "Bullet";
        /// <summary>
        /// The vertex buffer identifier
        /// </summary>
        private int vertexBufferID;
        /// <summary>
        /// The vertex data
        /// </summary>
        private float[] vertexData;
        /// <summary>
        /// Gets or sets the speed.
        /// </summary>
        /// <value>
        /// The speed.
        /// </value>
        public float speed { get; set; } = 5;
        /// <summary>
        /// Gets or sets the Direction movement.
        /// </summary>
        /// <value>
        /// The Direction movement.
        /// </value>
        private Vector2 DirectionMovement { get; set; } = new Vector2(1, 0);

        public int Power { get;  private set; }

        public ObjectBullet(int width, int height, string filename, Vector2 position, int power) : base(width, height, filename, position)
        {
            Power = power;


            vertexData = new float[]
           {
                position.X + 0.0f, position.Y + 0.0f,   0.0f,
                position.X + width,    position.Y + 0.0f,   0.0f,
                position.X + width,    position.Y + height,      0.0f,
                position.X + 0.0f, position.Y + height,      0.0f,
           };
            vertexBufferID = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferID);
            GL.BufferData(BufferTarget.ArrayBuffer, vertexData.Length * sizeof(float), vertexData, BufferUsageHint.StaticRead);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        public void Damage(Player player)
        {

        }

        public void Damage(Monster monster)
        {

        }

        /// <summary>
        /// Sets the Direction.
        /// </summary>
        /// <param name="directionMonster">The Direction monster.</param>
        public void SetDirection(Direction directionMonster)
        {
            switch (directionMonster)
            {
                case Direction.Up:
                    DirectionMovement = new Vector2(0, -1);
                    break;
                case Direction.Down:
                    DirectionMovement = new Vector2(0, 1);
                    break;
                case Direction.Left:
                    DirectionMovement = new Vector2(-1, 0);
                    break;
                case Direction.Right:
                    DirectionMovement = new Vector2(1, 0);
                    break;
            }
        }

        /// <summary>
        /// Moves this instance.
        /// </summary>
        public void Move()
        {
            //CurrPosition = Position;
            Position += DirectionMovement * speed;
            vertexData = new float[]
            {
                 Position.X + 0.0f, Position.Y + 0.0f,   0.0f,
                 Position.X + W,    Position.Y + 0.0f,   0.0f,
                 Position.X + W,    Position.Y + H,      0.0f,
                 Position.X + 0.0f, Position.Y + H,      0.0f,
            };
            vertexBufferID = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferID);
            GL.BufferData(BufferTarget.ArrayBuffer, vertexData.Length * sizeof(float), vertexData, BufferUsageHint.StaticRead);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        /// <summary>
        /// Draws this instance.
        /// </summary>
        public override void Draw()
        {
            EnableStates();
            texture.Bind();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferID);
            GL.VertexPointer(3, VertexPointerType.Float, 0, 0);
            GL.DrawArrays(PrimitiveType.Quads, 0, vertexData.Length);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            texture.Unbind();
            DisableStates();
        }

        /// <summary>
        /// Enables the states.
        /// </summary>
        private void EnableStates()
        {
            GL.EnableClientState(ArrayCap.VertexArray);
            GL.EnableClientState(ArrayCap.TextureCoordArray);
        }
        /// <summary>
        /// Disables the states.
        /// </summary>
        private void DisableStates()
        {
            GL.DisableClientState(ArrayCap.VertexArray);
            GL.DisableClientState(ArrayCap.TextureCoordArray);
        }
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public override void Dispose()
        {
            texture.Dispose();
            GL.DeleteBuffer(vertexBufferID);
        }
    }
}
