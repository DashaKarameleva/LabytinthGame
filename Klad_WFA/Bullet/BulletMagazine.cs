using System.Collections.Generic;
namespace labyrinth.Bullet
{
    /// <summary>
    /// 
    /// </summary>
    public class BulletMagazine
    {
        /// <summary>
        /// Gets or sets the bullet.
        /// </summary>
        /// <value>
        /// The bullet.
        /// </value>
        public Bullet Bullet {get; private set; }

        /// <summary>
        /// The index bullet
        /// </summary>
        int indexBullet;

        /// <summary>
        /// The bullets
        /// </summary>
        public List<Bullet> Bullets;

        /// <summary>
        /// Initializes a new instance of the <see cref="BulletMagazine"/> class.
        /// </summary>
        public BulletMagazine()
        {
            Bullets = new List<Bullet>();
            indexBullet = 0;
        }

        /// <summary>
        /// Gets the count patrons.
        /// </summary>
        /// <value>
        /// The count patrons.
        /// </value>
        public int CountPatrons { get => this.Bullet.Count; }

        /// <summary>
        /// Adds the specified bullet.
        /// </summary>
        /// <param name="bullet">The bullet.</param>
        public void Add(Bullet bullet)
        {
            foreach (var bull in Bullets)
            {
                if (bull.GetType() == bullet.GetType())
                {
                    Bullets[Bullets.IndexOf(bull)].Add(bullet.Count);

                    return;
                }
            }

            if (Bullet == null)
                Bullet = bullet;

            Bullets.Add(bullet);
        }

        /// <summary>
        /// Deletes the specified bullet.
        /// </summary>
        /// <param name="bullet">The bullet.</param>
        public void Del(Bullet bullet)
        {
            Bullets.Remove(bullet);
        }

        /// <summary>
        /// Switches this instance.
        /// </summary>
        public void Switch()
        {
            if (Bullets.Count != 0)
            {
                if (indexBullet != Bullets.Count - 1)
                {
                    indexBullet++;
                    Bullet = Bullets[indexBullet];
                }
                else
                {
                    indexBullet = 0;
                    Bullet = Bullets[indexBullet];
                }
            }
            /// <summary>
            /// Sets the specified index.
            /// </summary>
            /// <param name="index">The index.</param>
        }
    }
}
