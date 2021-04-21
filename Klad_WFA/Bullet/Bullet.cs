using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labyrinth.Bullet
{
   public abstract  class Bullet : GameObject
    {
        public abstract float Power { get; }
        public abstract int Count { get; }
        protected float currPower;
        protected int currCout;

        public virtual void Add(int count)
        {
            currCout += count;
        }
        public virtual bool Shot()
        {
            if (currCout > 0)
            {
                currCout--;
                return true;
            }

            return false;
        }
    }
}
