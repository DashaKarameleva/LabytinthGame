namespace labyrinth.Bullet
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="labyrinth.GameObject" />
    public abstract  class Bullet
    {
        /// <summary>
        /// Gets the power.
        /// </summary>
        /// <value>
        /// The power.
        /// </value>
        public abstract float Power { get; }
        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public abstract int Count { get; }
        /// <summary>
        /// The curr power
        /// </summary>
        protected float currPower;
        /// <summary>
        /// The curr cout
        /// </summary>
        protected int currCout;

        /// <summary>
        /// Adds the specified count.
        /// </summary>
        /// <param name="count">The count.</param>
        public virtual void Add(int count)
        {
            currCout += count;
        }
        /// <summary>
        /// Shots this instance.
        /// </summary>
        /// <returns></returns>
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
