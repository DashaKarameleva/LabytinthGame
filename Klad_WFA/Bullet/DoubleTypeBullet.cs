using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labyrinth.Bullet
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="labyrinth.Bullet.BulletDecorator" />
    public class DoubleTypeBullet : BulletDecorator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleBullet"/> class.
        /// </summary>
        /// <param name="bullet">The bullet.</param>
        public DoubleTypeBullet(Bullet bullet) : base(bullet)
        {

        }
        /// <summary>
        /// Gets the power.
        /// </summary>
        /// <value>
        /// The power.
        /// </value>
        public override float Power { get => bullet.Power * 2; }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "Double power";
        }
    }
}
