using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Klad_WFA
{
    class Player : GameObject
    {
        private int vertexBufferID;
        private float[] vertexData;
        private Texture texture;

        public int speed = 2;

        public Player(int width, int height, string filename, Vector2 position) : base(width, height, filename, position)
        {
            texture = new Texture(filename);

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

        public void Move(Vector2 direction)
        {
            Position += direction;

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
        
        public void Draw()
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

        public void Dispose()
        {
            texture.Dispose();
            GL.DeleteBuffer(vertexBufferID);
        }
    }
}
