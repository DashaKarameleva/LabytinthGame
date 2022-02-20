﻿using OpenTK;

namespace labyrinth.bonus
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="labyrinth.Bonus" />
    public class ArmorBonus : Bonus
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string Type { get; set; } = "Armor";
        /// <summary>
        /// Initializes a new instance of the <see cref="ArmorBonus"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="filename">The filename.</param>
        /// <param name="position">The position.</param>
        public ArmorBonus(int width, int height, string filename, Vector2 position) : base(width, height, filename, position)
        {
        }
        /// <summary>
        /// Ups the player.
        /// </summary>
        /// <param name="player">The player.</param>
        public override void UpPlayer(Player player)
        {
            player.armor += 2;
        

            active = true;
            this.player = player;
        }
        /// <summary>
        /// Defalts the player.
        /// </summary>
        /// <param name="player">The player.</param>
        public override void DefaltPlayer(Player player)
        {
            player.armor = player.armor;
        }
    }
}
