﻿using labyrinth;
using labyrinth.Bullet;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;

namespace labyrinth
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="labyrinth.GameObject" />
    public class Monster : GameObject
    {
        /// <summary>
        /// The type
        /// </summary>
        public string type = "Monster";
        /// <summary>
        /// The vertex buffer identifier
        /// </summary>
        private int vertexBufferID;
        /// <summary>
        /// The vertex data
        /// </summary>
        private float[] vertexData;
        /// <summary>
        /// Gets or sets the health.
        /// </summary>
        /// <value>
        /// The health.
        /// </value>
        public int Health { get; set; } = 4;
        /// <summary>
        /// Gets or sets the speed.
        /// </summary>
        /// <value>
        /// The speed.
        /// </value>
        public float speed { get; set; } = 1;
        /// <summary>
        /// Gets or sets the curr position.
        /// </summary>
        /// <value>
        /// The curr position.
        /// </value>
        private Vector2 CurrPosition { get; set; }
        private BulletMagazine bulletMagazine = new BulletMagazine();
        public BulletMagazine BulletMagazine { get => bulletMagazine; }
        /// <summary>
        /// Gets or sets the Direction movement.
        /// </summary>
        /// <value>
        /// The Direction movement.
        /// </value>
        public Vector2 DirectionMovement { get; set; } = new Vector2(1,0);
        /// <summary>
        /// Initializes a new instance of the <see cref="Monster"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="filename">The filename.</param>
        /// <param name="position">The position.</param>
        /// 

        public Monster(int width, int height, string filename, Vector2 position) : base(width, height, filename, position)
        {

            CurrPosition = position;
            bulletMagazine.Add(new StandartTypeBullet(2, 1000));
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
        /// Sets the Direction.
        /// </summary>
        /// <param name="directionMonster">The Direction monster.</param>
        public void SetDirection(Direction directionMonster)
        {
            switch (directionMonster)
            {
                case Direction.Up:
                    DirectionMovement = new Vector2(0,-1);
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
        public Direction GetDirection()
        {
            switch (this.DirectionMovement.X)
            {
                case -1:
                    return Direction.Left;
                    
                case 1:
                    return Direction.Right;

                default: return Direction.Left;


            }
        }
        /// <summary>
        /// Moves this instance.
        /// </summary>
        public void Move()
        {
            CurrPosition = Position;
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
        /// Cancels the move.
        /// </summary>
        public void CancelMove()
        {
            Position = CurrPosition;
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
