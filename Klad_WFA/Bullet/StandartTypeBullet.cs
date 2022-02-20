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
    /// <seealso cref="labyrinth.Bullet.Bullet" />
    public class StandartTypeBullet : Bullet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StandartBullet"/> class.
        /// </summary>
        /// <param name="power">The power.</param>
        /// <param name="count">The count.</param>
        public StandartTypeBullet(float power, int count)
        {
            currPower = power;
            currCout = count;
        }
        //public override float Power { get; set; } = currPower;
        /// <summary>
        /// Gets the power.
        /// </summary>
        /// <value>
        /// The power.
        /// </value>
        public override float Power => currPower;

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public override int Count => currCout;

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "Standart power";
        }
    }
}
