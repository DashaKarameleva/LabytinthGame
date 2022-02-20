namespace labyrinth
{
    /// <summary>
    /// 
    /// </summary>
    public class GameEvents
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="health1">The health1.</param>
        /// <param name="health2">The health2.</param>
        public delegate void HealthPlayer(int health1, int health2);
        /// <summary>
        /// Gets or sets the change health player.
        /// </summary>
        /// <value>
        /// The change health player.
        /// </value>
        public static HealthPlayer ChangeHealthPlayer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="armor1">The armor1.</param>
        /// <param name="armor2">The armor2.</param>
        public delegate void ArmorPlayer(int armor1, int armor2);
        /// <summary>
        /// Gets or sets the change armor.
        /// </summary>
        /// <value>
        /// The change armor.
        /// </value>
        public static ArmorPlayer ChangeArmor{ get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patron1">The patron1.</param>
        /// <param name="patron2">The patron2.</param>
        public delegate void PatronPlayer(int patron1, int patron2);
        /// <summary>
        /// Gets or sets the change patron count.
        /// </summary>
        /// <value>
        /// The change patron count.
        /// </value>
        public static PatronPlayer ChangePatronCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patron1">The patron1.</param>
        /// <param name="patron2">The patron2.</param>
        public delegate void PointsPlayer(int patron1, int patron2);
        /// <summary>
        /// Gets or sets the change player points.
        /// </summary>
        /// <value>
        /// The change player points.
        /// </value>
        public static PointsPlayer ChangePlayerPoints { get; set; }
    }
}
