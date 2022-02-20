using labyrinth;
using labyrinth.Bullet;
using OpenTK;
using OpenTK.Graphics.OpenGL;
namespace labyrinth
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="labyrinth.GameObject" />
    public class Player : GameObject
    {
        public string Tag { get; set; }
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
        /// The number
        /// </summary>
        private int number;
        /// <summary>
        /// The bullet magazine
        /// </summary>
        private BulletMagazine bulletMagazine = new BulletMagazine();
        /// <summary>
        /// Gets or sets the speed.
        /// </summary>
        /// <value>
        /// The speed.
        /// </value>
        public int speed { get; set; } = 2;
        /// <summary>
        /// Gets or sets the health.
        /// </summary>
        /// <value>
        /// The health.
        /// </value>
        public int health { get; set; } = 10;
        /// <summary>
        /// Gets or sets the armor.
        /// </summary>
        /// <value>
        /// The armor.
        /// </value>
        public int armor { get; set; } = 10;
        /// <summary>
        /// Gets the patron.
        /// </summary>
        /// <value>
        /// The patron.
        /// </value>
        public int patron { get=>bulletMagazine.CountPatrons;  }
        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public int count { get; set; } = 0;
        /// <summary>
        /// Gets or sets the Direction.
        /// </summary>
        /// <value>
        /// The Direction.
        /// </value>
        public Direction direction { get; private set; }
        /// <summary>
        /// Gets the bullet magazine.
        /// </summary>
        /// <value>
        /// The bullet magazine.
        /// </value>
        public BulletMagazine BulletMagazine { get => bulletMagazine; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="filename">The filename.</param>
        /// <param name="position">The position.</param>
        /// <param name="number">The number.</param>
        public Player(int width, int height, string filename, Vector2 position, int number) : base(width, height, filename, position)
        {
            texture = new Texture(filename);

            bulletMagazine.Add(new StandartTypeBullet(2,10));
            bulletMagazine.Add(new DoubleTypeBullet(new StandartTypeBullet(2,5)));

            this.number = number;    
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
        /// <summary>
        /// Moves the specified Direction.
        /// </summary>
        /// <param name="direction">The Direction.</param>
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
            if (direction.ToString() == "Down")
            {
                texture = new Texture("texture/pl" + number + "S.png");
            }
            else if (direction.ToString() == "Left")
            {
                texture = new Texture("texture/pl" + number + "A.png");
            }
            else if (direction.ToString() == "Up")
            {
                texture = new Texture("texture/pl" + number + "W.png");
            }
            else if (direction.ToString() == "Right")
            {
                texture = new Texture("texture/pl" + number + "D.png");
            }
        }

        /// <summary>
        /// Sets the Direction.
        /// </summary>
        /// <param name="directionMonster">The Direction monster.</param>
        public void SetDirection(Direction direction)
        {
            this.direction = direction;
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
