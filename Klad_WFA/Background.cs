using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace labyrinth
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class Background : IDisposable
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
        /// The texture
        /// </summary>
        private Texture texture;
        /// <summary>
        /// Initializes a new instance of the <see cref="Background"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="filename">The filename.</param>
        public Background(int width, int height, string filename)
        {
            texture = new Texture(filename);
            vertexData = new float[]
            {
                0.0f, 0.0f, 0.0f,
                width, 0.0f, 0.0f,
                width, height, 0.0f,
                0.0f, height, 0.0f,
            };
            vertexBufferID = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferID);
            GL.BufferData(BufferTarget.ArrayBuffer, vertexData.Length * sizeof(float), vertexData, BufferUsageHint.StaticRead);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }
        /// <summary>
        /// Resizes the specified width.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public void Resize(int width, int height)
        {
            vertexData = new float[]
            {
                0.0f, 0.0f, 0.0f,
                width, 0.0f, 0.0f,
                width, height, 0.0f,
                0.0f, height, 0.0f,
            };
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferID);
            GL.BufferData(BufferTarget.ArrayBuffer, vertexData.Length * sizeof(float), vertexData, BufferUsageHint.StaticRead);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }
        /// <summary>
        /// Draws this instance.
        /// </summary>
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
        /// Выполняет определяемые приложением задачи, связанные с удалением, высвобождением или сбросом неуправляемых ресурсов.
        /// </summary>
        public void Dispose()
        {
            texture.Dispose();
            GL.DeleteBuffer(vertexBufferID);
        }
    }
}
