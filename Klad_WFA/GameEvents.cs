using labyrinth.Bullet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labyrinth
{
   public class GameEvents
    {
        public delegate void HealthPlayer(int health1, int health2);
        public static HealthPlayer ChangeHealthPlayer { get; set; }

        public delegate void ArmorPlayer(int armor1, int armor2);
        public static ArmorPlayer ChangeArmor{ get; set; }

        public delegate void PatronPlayer(int patron1, int patron2);
        public static PatronPlayer ChangePatronCount { get; set; }

        public delegate void PointsPlayer(int patron1, int patron2);
        public static PointsPlayer ChangePlayerPoints { get; set; }
    }
}
