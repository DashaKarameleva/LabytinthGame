namespace labyrinth.Bullet
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="labyrinth.Bullet.Bullet" />
    public class BulletDecorator : Bullet
    {
        /// <summary>
        /// The bullet
        /// </summary>
        protected Bullet bullet;
        /// <summary>
        /// Initializes a new instance of the <see cref="BulletDecorator"/> class.
        /// </summary>
        /// <param name="bullet">The bullet.</param>
        public BulletDecorator(Bullet bullet)
        {
            this.bullet = bullet;
        }
        /// <summary>
        /// Gets the power.
        /// </summary>
        /// <value>
        /// The power.
        /// </value>
        public override float Power { get => bullet.Power*2; }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public override int Count { get => bullet.Count; }

        /// <summary>
        /// Adds the specified count.
        /// </summary>
        /// <param name="count">The count.</param>
        public override void Add(int count)
        {
            bullet.Add(count);
        }
        /// <summary>
        /// Shots this instance.
        /// </summary>
        /// <returns></returns>
        public override bool Shot()
        {
            return bullet.Shot();
        }
    }
}
