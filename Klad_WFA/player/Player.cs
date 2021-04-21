using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using labyrinth.Bullet;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace labyrinth
{

  public  enum Direction
    {
        Right,
        Left,
        Up,
        Down
    }
   public  class Player : GameObject
    {
        private int vertexBufferID;
        private float[] vertexData;
        private Texture texture;
        private int number;
        private BulletMagazine bulletMagazine = new BulletMagazine();

        public int speed { get; set; } = 2;
        public int health { get; set; } = 10;
        public int armor { get; set; } = 10;
        //public int patron { get=>bulletMagazine.CountPatrons;  } 
        public int count { get; set; } = 0;
        public bool destroy { get; set; } = true;
        public bool create {get; set;} = true;
        public Direction direction { get; set; }
        //public BulletMagazine BulletMagazine { get=> BulletMagazine;   }
        public bool firstPlayer { get; private set; }
        //public Player(bool firstPlayer) : base()
        //{

        //    BulletMagazine.Add(new StandartBullet(1, 50));
        //    this.firstPlayer = firstPlayer;
        //}
        public Player(int width, int height, string filename, Vector2 position, int number) : base(width, height, filename, position)
        {
            texture = new Texture(filename);
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

        public override void Dispose()
        {
            texture.Dispose();
            GL.DeleteBuffer(vertexBufferID);
        }
    }
}
