using OpenTK;
namespace labyrinth
{
    /// <summary>
    /// 
    /// </summary>
    enum Walls
    {
        /// <summary>
        /// The empty
        /// </summary>
        Empty,
        /// <summary>
        /// The created
        /// </summary>
        Created
    }
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="labyrinth.GameObject" />
    public class Sides : GameObject
    {
        /// <summary>
        /// The types
        /// </summary>
        Walls types;
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public virtual string type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Sides"/> class.
        /// </summary>
        protected Sides() : base() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Sides"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="filename">The filename.</param>
        /// <param name="position">The position.</param>
        /// <param name="id">The identifier.</param>
        public Sides(int width, int height, string filename, Vector2 position, int id)
            : base(width, height, filename, position)
        {
            types = (Walls)id;
            type = types.ToString();
        }
    }
}
