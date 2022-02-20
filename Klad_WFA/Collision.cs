using labyrinth.Bullet;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labyrinth
{
    /// <summary>
    /// 
    /// </summary>
    public class Collision
    {
        /// <summary>
        /// The move d
        /// </summary>
        bool moveD = true;
        /// <summary>
        /// The move a
        /// </summary>
        bool moveA = true;
        /// <summary>
        /// The move s
        /// </summary>
        bool moveS = true;
        /// <summary>
        /// The move w
        /// </summary>
        bool moveW = true;
        /// <summary>
        /// The move right
        /// </summary>
        bool moveRight = true;
        /// <summary>
        /// The move left
        /// </summary>
        bool moveLeft = true;
        /// <summary>
        /// The move down
        /// </summary>
        bool moveDown = true;
        /// <summary>
        /// The move up
        /// </summary>
        bool moveUp = true;
        /// <summary>
        /// The player1
        /// </summary>
        private readonly GameObject player1, player2;
        /// <summary>
        /// The monsters
        /// </summary>
        private readonly List<Monster> monsters;
        /// <summary>
        /// The side
        /// </summary>
        readonly List<GameObject> side = new List<GameObject>();
        /// <summary>
        /// Initializes a new instance of the <see cref="Collision"/> class.
        /// </summary>
        /// <param name="Player1">The player1.</param>
        /// <param name="Player2">The player2.</param>
        /// <param name="sides">The sides.</param>
        /// <param name="Monsters">The monsters.</param>
        public Collision(Player Player1, Player Player2, List<Sides> sides,  List<Monster> Monsters)
        {
            player1 = Player1;
            player2 = Player2;
            monsters = Monsters;

            side = new List<GameObject>();
            foreach (Sides item in sides)
            {
                side.Add(item);
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Collision"/> class.
        /// </summary>
        /// <param name="Monsters">The monsters.</param>
        public Collision( List<Monster> Monsters)
        {
            monsters = Monsters;
        }
        /// <summary>
        /// Rises the right.
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns></returns>
        public bool RiseRight(GameObject obj1, GameObject obj2)
        {
            if (obj1.Position.Y + obj1.H / 2 > obj2.Position.Y - obj2.H / 2 && obj1.Position.Y - obj1.H / 2 < obj2.Position.Y + obj2.H / 2)
            {
                if (obj1.Position.X + ((Player)obj1).speed + obj1.W / 2 > obj2.Position.X - obj2.W / 2 && obj1.Position.X - obj1.W / 2 < obj2.Position.X + obj2.W / 2) return false;
            }
            return true;
        }
        /// <summary>
        /// Rises the left.
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns></returns>
        public bool RiseLeft(GameObject obj1, GameObject obj2)
        {
            if (obj1.Position.Y + obj1.H / 2 > obj2.Position.Y - obj2.H / 2 && obj1.Position.Y - obj1.H / 2 < obj2.Position.Y + obj2.H / 2)
            {
                if (obj1.Position.X - ((Player)obj1).speed - obj1.W / 2 < obj2.Position.X + obj2.W / 2 && obj1.Position.X + obj1.W / 2 > obj2.Position.X - obj2.W / 2) return false;
            }
            return true;
        }
        /// <summary>
        /// Rises up.
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns></returns>
        public bool RiseUp(GameObject obj1, GameObject obj2)
        {
            if (obj1.Position.X + obj1.W / 2 > obj2.Position.X - obj2.W / 2 && obj1.Position.X - obj1.W / 2 < obj2.Position.X + obj2.W / 2)
            {
                if (obj1.Position.Y - ((Player)obj1).speed - obj1.H / 2 < obj2.Position.Y + obj2.H / 2 && obj1.Position.Y + obj1.H / 2 > obj2.Position.Y - obj2.H / 2) return false;
            }
            return true;
        }
        /// <summary>
        /// Rises down.
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns></returns>
        public bool RiseDown(GameObject obj1, GameObject obj2)
        {
            if (obj1.Position.X + obj1.W / 2 > obj2.Position.X - obj2.W / 2 && obj1.Position.X - obj1.W / 2 < obj2.Position.X + obj2.W / 2)
            {
                if (obj1.Position.Y + ((Player)obj1).speed + obj1.H / 2 > obj2.Position.Y - obj2.H / 2 && obj1.Position.Y - obj1.H / 2 < obj2.Position.Y + obj2.H / 2) return false;
            }
            return true;
        }
        /// <summary>
        /// Moves the d.
        /// </summary>
        /// <returns></returns>
        public bool MoveD()
        {
            if (RiseRight(player1, player2) == false) moveD = false;
            for (int i = 0; i < side.Count; i++)
            {
                if (((Sides)side[i]).type != "Empty" && RiseRight(player1, side[i]) == false) moveD = false;
            }
            return moveD;
        }
        /// <summary>
        /// Moves a.
        /// </summary>
        /// <returns></returns>
        public bool MoveA()
        {
            if (RiseLeft(player1, player2) == false) moveA = false;
            for (int i = 0; i < side.Count; i++)
            {
                if (((Sides)side[i]).type != "Empty" && RiseLeft(player1, side[i]) == false) moveA = false;
            }
            return moveA;
        }
        /// <summary>
        /// Moves the s.
        /// </summary>
        /// <returns></returns>
        public bool MoveS()
        {
            if (RiseDown(player1, player2) == false) moveS = false;
            for (int i = 0; i < side.Count; i++)
            {
                if (((Sides)side[i]).type != "Empty" && RiseDown(player1, side[i]) == false) moveS = false;
            }
            return moveS;
        }
        /// <summary>
        /// Moves the w.
        /// </summary>
        /// <returns></returns>
        public bool MoveW()
        {
            if (RiseUp(player1, player2) == false) moveW = false;
            for (int i = 0; i < side.Count; i++)
            {
                if (((Sides)side[i]).type != "Empty" && RiseUp(player1, side[i]) == false) moveW = false;
            }
            return moveW;
        }
        /// <summary>
        /// Moves the right.
        /// </summary>
        /// <returns></returns>
        public bool MoveRight()
        {
            if (RiseRight(player2, player1) == false) moveRight = false;
            for (int i = 0; i < side.Count; i++)
            {
                if (((Sides)side[i]).type != "Empty" && RiseRight(player2, side[i]) == false) moveRight = false;
            }
            return moveRight;
        }
        /// <summary>
        /// Moves the left.
        /// </summary>
        /// <returns></returns>
        public bool MoveLeft()
        {
            if (RiseLeft(player2, player1) == false) moveLeft = false;
            for (int i = 0; i < side.Count; i++)
            {
                if (((Sides)side[i]).type != "Empty" && RiseLeft(player2, side[i]) == false) moveLeft = false;
            }
            return moveLeft;
        }
        /// <summary>
        /// Moves down.
        /// </summary>
        /// <returns></returns>
        public bool MoveDown()
        {
            if (RiseDown(player2, player1) == false) moveDown = false;
            for (int i = 0; i < side.Count; i++)
            {
                if (((Sides)side[i]).type != "Empty" && RiseDown(player2, side[i]) == false) moveDown = false;
            }
            return moveDown;
        }
        /// <summary>
        /// Moves up.
        /// </summary>
        /// <returns></returns>
        public bool MoveUp()
        {
            if (RiseUp(player2, player1) == false) moveUp = false;
            for (int i = 0; i < side.Count; i++)
            {
                if (((Sides)side[i]).type != "Empty" && RiseUp(player2, side[i]) == false) moveUp = false;
            }
            return moveUp;
        }
        /// <summary>
        /// Boosts the collision.
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns></returns>
        public bool BoostCollision(Player obj1, GameObject obj2)
        {
            if (obj1.Position.Y + obj1.H / 2 > obj2.Position.Y - obj2.H / 2 && obj1.Position.Y - obj1.H / 2 < obj2.Position.Y + obj2.H / 2)
                if (obj1.Position.X + obj1.W / 2 > obj2.Position.X - obj2.W / 2 && obj1.Position.X - obj1.W / 2 < obj2.Position.X + obj2.W / 2) return true;
            return false;
        }
        /// <summary>
        /// Determines whether [is can boosts] [the specified obj1].
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns>
        ///   <c>true</c> if [is can boosts] [the specified obj1]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsCanBoosts(Player obj1, Bonus obj2)
        {
                if (BoostCollision(obj1, obj2))
                {
                    return true;
                }
            return false;
        }
        /// <summary>
        /// Rises the right monster.
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns></returns>
        public bool RiseRightMonster(GameObject obj1, GameObject obj2)
        {
            if (obj1.Position.Y + obj1.H / 2 > obj2.Position.Y - obj2.H / 2 && obj1.Position.Y - obj1.H / 2 < obj2.Position.Y + obj2.H / 2)
            {
                if (obj1.Position.X + ((Monster)obj1).speed + obj1.W / 2 > obj2.Position.X - obj2.W / 2 && obj1.Position.X - obj1.W / 2 < obj2.Position.X + obj2.W / 2) return false;
            }
            return true;
        }
        /// <summary>
        /// Rises the left monster.
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns></returns>
        public bool RiseLeftMonster(GameObject obj1, GameObject obj2)
        {
            if (obj1.Position.Y + obj1.H / 2 > obj2.Position.Y - obj2.H / 2 && obj1.Position.Y - obj1.H / 2 < obj2.Position.Y + obj2.H / 2)
            {
                if (obj1.Position.X - ((Monster)obj1).speed - obj1.W / 2 < obj2.Position.X + obj2.W / 2 && obj1.Position.X + obj1.W / 2 > obj2.Position.X - obj2.W / 2) return false;
            }
            return true;
        }
        /// <summary>
        /// Monsters the move right.
        /// </summary>
        /// <param name="monster">The monster.</param>
        /// <returns></returns>
        public bool MonsterMoveRight(Monster monster)
        {            
            for (int i = 0; i < side.Count; i++)
            {
               if (((Sides)side[i]).type != "Empty" && RiseRightMonster(monster, side[i]) == false)  return false;
            }
            return true;
        }
        /// <summary>
        /// Monsters the move left.
        /// </summary>
        /// <param name="monster">The monster.</param>
        /// <returns></returns>
        public bool MonsterMoveLeft(Monster monster)
        {
            for (int i = 0; i < side.Count; i++)
            {
                if (((Sides)side[i]).type != "Empty" && RiseLeftMonster(monster, side[i]) == false) return false;
            }
            return true;
        }
        /// <summary>
        /// Destroys the collision.
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns></returns>
        public bool DestroyCollision(Player obj1, GameObject obj2)
        {
            if (obj1.Position.Y + obj1.speed + obj1.H / 2 > obj2.Position.Y - obj2.H / 2 && obj1.Position.Y - obj1.H / 2 < obj2.Position.Y + obj2.H / 2)
                if (obj1.Position.X + obj1.speed + obj1.W / 2 > obj2.Position.X - obj2.W / 2 && obj1.Position.X - obj1.W / 2 < obj2.Position.X + obj2.W / 2) return true;

            if (obj1.Position.Y - obj1.speed - obj1.H / 2 < obj2.Position.Y + obj2.H / 2 && obj1.Position.Y + obj1.H / 2 > obj2.Position.Y - obj2.H / 2)
                if (obj1.Position.X - obj1.speed - obj1.W / 2 < obj2.Position.X + obj2.W / 2 && obj1.Position.X + obj1.W / 2 > obj2.Position.X - obj2.W / 2) return true;

            return false;
        }

        /// <summary>
        /// Destroys the collision.
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns></returns>
        public bool DestroyCollision(ObjectBullet obj1, Sides obj2)
        {
            if (obj1.Position.Y + obj1.speed + obj1.H / 2 > obj2.Position.Y - obj2.H / 2 && obj1.Position.Y - obj1.H / 2 < obj2.Position.Y + obj2.H / 2)
                if (obj1.Position.X + obj1.speed + obj1.W / 2 > obj2.Position.X - obj2.W / 2 && obj1.Position.X - obj1.W / 2 < obj2.Position.X + obj2.W / 2) return true;

            if (obj1.Position.Y - obj1.speed - obj1.H / 2 < obj2.Position.Y + obj2.H / 2 && obj1.Position.Y + obj1.H / 2 > obj2.Position.Y - obj2.H / 2)
                if (obj1.Position.X - obj1.speed - obj1.W / 2 < obj2.Position.X + obj2.W / 2 && obj1.Position.X + obj1.W / 2 > obj2.Position.X - obj2.W / 2) return true;

            return false;
        }


        /// <summary>
        /// Destroys the collision.
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns></returns>
        public bool DestroyCollision(Monster obj1, GameObject obj2)
        {
            if (obj1.Position.Y + obj1.speed + obj1.H / 2 > obj2.Position.Y - obj2.H / 2 && obj1.Position.Y - obj1.H / 2 < obj2.Position.Y + obj2.H / 2)
                if (obj1.Position.X + obj1.speed + obj1.W / 2 > obj2.Position.X - obj2.W / 2 && obj1.Position.X - obj1.W / 2 < obj2.Position.X + obj2.W / 2) return true;

            if (obj1.Position.Y - obj1.speed - obj1.H / 2 < obj2.Position.Y + obj2.H / 2 && obj1.Position.Y + obj1.H / 2 > obj2.Position.Y - obj2.H / 2)
                if (obj1.Position.X - obj1.speed - obj1.W / 2 < obj2.Position.X + obj2.W / 2 && obj1.Position.X + obj1.W / 2 > obj2.Position.X - obj2.W / 2) return true;

            return false;
        }
    }
}

  
