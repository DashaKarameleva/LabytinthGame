using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace labyrinth
{
  public  class GameObject
    {
        private int vertexBufferID;
        private float[] vertexData;

        public virtual Texture texture { get; set; }
        public virtual Vector2 Position { get; set; }
        public virtual int W { get; set; }
        public virtual int H { get; set; }

        protected GameObject() { }
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
        
        public  virtual void Draw()
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

        private void EnableStates()
        {
            GL.EnableClientState(ArrayCap.VertexArray);
            GL.EnableClientState(ArrayCap.TextureCoordArray);
        }

        private void DisableStates()
        {
            GL.DisableClientState(ArrayCap.VertexArray);
            GL.DisableClientState(ArrayCap.TextureCoordArray);
        }

        public virtual void Dispose()
        {
            texture.Dispose();
            GL.DeleteBuffer(vertexBufferID);
        }
    }
}
