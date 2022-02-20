using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace labyrinth
{
    /// <summary>
    /// 
    /// </summary>
    public class GameObject : Object
    {
        /// <summary>
        /// The vertex buffer identifier
        /// </summary>
        private int vertexBufferID;
        /// <summary>
        /// The vertex data
        /// </summary>
        private float[] vertexData;
        /// <summary>
        /// The game object
        /// </summary>
        public GameObject gameObject;
        /// <summary>
        /// Gets or sets the texture.
        /// </summary>
        /// <value>
        /// The texture.
        /// </value>
        public virtual Texture texture { get; set; }
        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public virtual Vector2 Position { get; set; }
        /// <summary>
        /// Gets or sets the w.
        /// </summary>
        /// <value>
        /// The w.
        /// </value>
        public virtual int W { get; set; }
        /// <summary>
        /// Gets or sets the h.
        /// </summary>
        /// <value>
        /// The h.
        /// </value>
        public virtual int H { get; set; }
        public virtual string Filename { get; set; }
        /// <summary>
        /// Gets or sets the transform.
        /// </summary>
        /// <value>
        /// The transform.
        /// </value>
        /// <summary>
        /// Initializes a new instance of the <see cref="GameObject"/> class.
        /// </summary>
        protected GameObject() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GameObject"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="filename">The filename.</param>
        /// <param name="position">The position.</param>
        public GameObject(int width, int height, string filename, Vector2 position)
        {
            texture = new Texture(filename);
            Position = position;
            W = width;
            H = height;
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
        public virtual void Draw()
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
        public virtual void Dispose()
        {
            texture.Dispose();
            GL.DeleteBuffer(vertexBufferID);
        }
    }
}
