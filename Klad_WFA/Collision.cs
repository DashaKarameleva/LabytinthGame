using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labyrinth
{
    class Collision
    {
        bool moveD = true;
        bool moveA = true;
        bool moveS = true;
        bool moveW = true;
        bool moveRight = true;
        bool moveLeft = true;
        bool moveDown = true;
        bool moveUp = true;

        private readonly GameObject player1, player2;
        readonly List<GameObject> side = new List<GameObject>();

        public Collision(Player Player1, Player Player2, List<Sides> sides, List<Sides> createSides)
        {
            player1 = Player1;
            player2 = Player2;

            side = new List<GameObject>();
            foreach (Sides item in sides)
            {
                side.Add(item);
            }
            foreach (Sides item in createSides)
            {
                side.Add(item);
            }
        }
        public bool RiseRight(GameObject obj1, GameObject obj2)
        {
            if (obj1.Position.Y + obj1.H / 2 > obj2.Position.Y - obj2.H / 2 && obj1.Position.Y - obj1.H / 2 < obj2.Position.Y + obj2.H / 2)
            {
                if (obj1.Position.X + ((Player)obj1).speed + obj1.W / 2 > obj2.Position.X - obj2.W / 2 && obj1.Position.X - obj1.W / 2 < obj2.Position.X + obj2.W / 2) return false;
            }
            return true;
        }
        public bool RiseLeft(GameObject obj1, GameObject obj2)
        {
            if (obj1.Position.Y + obj1.H / 2 > obj2.Position.Y - obj2.H / 2 && obj1.Position.Y - obj1.H / 2 < obj2.Position.Y + obj2.H / 2)
            {
                if (obj1.Position.X - ((Player)obj1).speed - obj1.W / 2 < obj2.Position.X + obj2.W / 2 && obj1.Position.X + obj1.W / 2 > obj2.Position.X - obj2.W / 2) return false;
            }
            return true;
        }
        public bool RiseUp(GameObject obj1, GameObject obj2)
        {
            if (obj1.Position.X + obj1.W / 2 > obj2.Position.X - obj2.W / 2 && obj1.Position.X - obj1.W / 2 < obj2.Position.X + obj2.W / 2)
            {
                if (obj1.Position.Y - ((Player)obj1).speed - obj1.H / 2 < obj2.Position.Y + obj2.H / 2 && obj1.Position.Y + obj1.H / 2 > obj2.Position.Y - obj2.H / 2) return false;
            }
            return true;
        }
        public bool RiseDown(GameObject obj1, GameObject obj2)
        {
            if (obj1.Position.X + obj1.W / 2 > obj2.Position.X - obj2.W / 2 && obj1.Position.X - obj1.W / 2 < obj2.Position.X + obj2.W / 2)
            {
                if (obj1.Position.Y + ((Player)obj1).speed + obj1.H / 2 > obj2.Position.Y - obj2.H / 2 && obj1.Position.Y - obj1.H / 2 < obj2.Position.Y + obj2.H / 2) return false;
            }
            return true;
        }






        //FIRST PLAYER
        public bool MoveD()
        {
            if (RiseRight(player1, player2) == false) moveD = false;
            for (int i = 0; i < side.Count; i++)
            {
                if (((Sides)side[i]).type != "Empty" && RiseRight(player1, side[i]) == false) moveD = false;
            }

            return moveD;
        }
        public bool MoveA()
        {
            if (RiseLeft(player1, player2) == false) moveA = false;
            for (int i = 0; i < side.Count; i++)
            {
                if (((Sides)side[i]).type != "Empty" && RiseLeft(player1, side[i]) == false) moveA = false;
            }

            return moveA;
        }
        public bool MoveS()
        {
            if (RiseDown(player1, player2) == false) moveS = false;
            for (int i = 0; i < side.Count; i++)
            {
                if (((Sides)side[i]).type != "Empty" && RiseDown(player1, side[i]) == false) moveS = false;
            }

            return moveS;
        }
        public bool MoveW()
        {
            if (RiseUp(player1, player2) == false) moveW = false;
            for (int i = 0; i < side.Count; i++)
            {
                if (((Sides)side[i]).type != "Empty" && RiseUp(player1, side[i]) == false) moveW = false;
            }

            return moveW;
        }



        // SECOND PLAYER
        public bool MoveRight()
        {
            if (RiseRight(player2, player1) == false) moveRight = false;
            for (int i = 0; i < side.Count; i++)
            {
                if (((Sides)side[i]).type != "Empty" && RiseRight(player2, side[i]) == false) moveRight = false;
            }

            return moveRight;
        }
        public bool MoveLeft()
        {
            if (RiseLeft(player2, player1) == false) moveLeft = false;
            for (int i = 0; i < side.Count; i++)
            {
                if (((Sides)side[i]).type != "Empty" && RiseLeft(player2, side[i]) == false) moveLeft = false;
            }

            return moveLeft;
        }
        public bool MoveDown()
        {
            if (RiseDown(player2, player1) == false) moveDown = false;
            for (int i = 0; i < side.Count; i++)
            {
                if (((Sides)side[i]).type != "Empty" && RiseDown(player2, side[i]) == false) moveDown = false;
            }

            return moveDown;
        }
        public bool MoveUp()
        {
            if (RiseUp(player2, player1) == false) moveUp = false;
            for (int i = 0; i < side.Count; i++)
            {
                if (((Sides)side[i]).type != "Empty" && RiseUp(player2, side[i]) == false) moveUp = false;
            }

            return moveUp;
        }


        // BOOSTS
        public bool BoostCollision(Player obj1, GameObject obj2)
        {
            if (obj1.Position.Y + obj1.H / 2 > obj2.Position.Y - obj2.H / 2 && obj1.Position.Y - obj1.H / 2 < obj2.Position.Y + obj2.H / 2)
                if (obj1.Position.X + obj1.W / 2 > obj2.Position.X - obj2.W / 2 && obj1.Position.X - obj1.W / 2 < obj2.Position.X + obj2.W / 2) return true;
            return false;
        }
        public bool IsCanBoosts(Player obj1, Bonus obj2)
        {
                if (BoostCollision(obj1, obj2))
                {
                    return true;
                }
            return false;
        }

        // DESTROY
        public bool DestroyCollision(Player obj1, GameObject obj2)
        {
            if (obj1.Position.Y + obj1.speed + obj1.H / 2 > obj2.Position.Y - obj2.H / 2 && obj1.Position.Y - obj1.H / 2 < obj2.Position.Y + obj2.H / 2)
                if (obj1.Position.X + obj1.speed + obj1.W / 2 > obj2.Position.X - obj2.W / 2 && obj1.Position.X - obj1.W / 2 < obj2.Position.X + obj2.W / 2) return true;

            if (obj1.Position.Y - obj1.speed - obj1.H / 2 < obj2.Position.Y + obj2.H / 2 && obj1.Position.Y + obj1.H / 2 > obj2.Position.Y - obj2.H / 2)
                if (obj1.Position.X - obj1.speed - obj1.W / 2 < obj2.Position.X + obj2.W / 2 && obj1.Position.X + obj1.W / 2 > obj2.Position.X - obj2.W / 2) return true;

            return false;
        }

        public bool CreateCollision(GameObject obj1, GameObject obj2)
        {
            if (obj1.Position.Y + obj1.H / 2 > obj2.Position.Y - obj2.H / 2 && obj1.Position.Y - obj1.H / 2 < obj2.Position.Y + obj2.H / 2)
                if (obj1.Position.X + obj1.W / 2 > obj2.Position.X - obj2.W / 2 && obj1.Position.X - obj1.W / 2 < obj2.Position.X + obj2.W / 2) return true;

            if (obj1.Position.Y - obj1.H / 2 < obj2.Position.Y + obj2.H / 2 && obj1.Position.Y + obj1.H / 2 > obj2.Position.Y - obj2.H / 2)
                if (obj1.Position.X - obj1.W / 2 < obj2.Position.X + obj2.W / 2 && obj1.Position.X + obj1.W / 2 > obj2.Position.X - obj2.W / 2) return true;

            return false;
        }


    }
}

  
