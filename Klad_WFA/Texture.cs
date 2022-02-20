using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using OpenTK.Graphics.OpenGL; 
namespace labyrinth
/// <summary>
/// 
/// </summary>
/// <seealso cref="System.IDisposable" />
{
    public class Texture : IDisposable
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int ID { get; private set; }
        /// <summary>
        /// Gets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        public int Width { get; private set; }
        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        public int Height { get; private set; }
        /// <summary>
        /// Gets the buffer identifier.
        /// </summary>
        /// <value>
        /// The buffer identifier.
        /// </value>
        public int BufferID { get; private set; }
        /// <summary>
        /// Gets the coordinates.
        /// </summary>
        /// <value>
        /// The coordinates.
        /// </value>
        public float[] Coordinates { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Texture"/> class.
        /// </summary>
        /// <param name="file_name">Name of the file.</param>
        public Texture(string file_name)
        {
            Bitmap bitmap = new Bitmap(1, 1);
            if (File.Exists(file_name))
            {
                bitmap = (Bitmap)Image.FromFile(file_name);
            }
            bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);
            Width = bitmap.Width;
            Height = bitmap.Height;
            BitmapData data = bitmap.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            ID = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, ID);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.ClampToEdge);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.ClampToEdge);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            GL.BindTexture(TextureTarget.Texture2D, 0);
            bitmap.UnlockBits(data);
            Coordinates = new float[]
            {
                0.0f, 1.0f, //LeftUp
                1.0f, 1.0f, //RightUp
                1.0f, 0.0f, //RightDown
                0.0f, 0.0f //LeftDown
            };
            BufferID = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, BufferID);
            GL.BufferData(BufferTarget.ArrayBuffer, Coordinates.Length * sizeof(float), Coordinates, BufferUsageHint.StaticDraw /*Частота изменения буфера*/);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }
        /// <summary>
        /// Binds this instance.
        /// </summary>
        public void Bind()
        {
            GL.BindTexture(TextureTarget.Texture2D, ID);
            GL.BindBuffer(BufferTarget.ArrayBuffer, BufferID);
            GL.TexCoordPointer(2, TexCoordPointerType.Float, 0, 0);
        }
        /// <summary>
        /// Unbinds this instance.
        /// </summary>
        public void Unbind()
        {
            GL.BindTexture(TextureTarget.Texture2D, 0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }
        /// <summary>
        /// Выполняет определяемые приложением задачи, связанные с удалением, высвобождением или сбросом неуправляемых ресурсов.
        /// </summary>
        public void Dispose()
        {
            GL.DeleteBuffer(BufferID);
            GL.DeleteTexture(ID);
        }
    }
}
