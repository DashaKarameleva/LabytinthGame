//using OpenTK;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Klad_WFA.maze
//{
//    abstract class SidesDecorator : Sides
//    {
//        protected Sides sides;
//        protected Player player;

//        public bool IsDecorate { get; protected set; }
//        public int TimeSetMinutes { get; set; } = DateTime.Now.Minute;
//        public int TimeSetSeconds { get; set; } = DateTime.Now.Second;
//        public int duration { get; set; }

//        public SidesDecorator(Sides sides, Player player) : base()
//        {
//            this.sides = sides;
//            this.player = player;
//            IsDecorate = true;
//            duration = 5;
//            if (TimeSetSeconds + duration >= 60)
//            {
//                TimeSetMinutes += 1;
//                TimeSetSeconds = TimeSetSeconds + duration - 60;
//            }
//            else
//            {
//                TimeSetSeconds += duration;
//            }
//            Decorate();
//        }

//        public override string type { get => sides.type; set => sides.type = value; }
//        public override Texture texture { get => sides.texture; set => sides.texture = value; }
//        public override Vector2 Position { get => sides.Position; set => sides.Position = value; }
//        public override int W { get => sides.W; set => sides.W = value; }
//        public override int H { get => sides.H; set => sides.H = value; }
//        public override void Draw()
//        {
//            sides.Draw();
//        }
//        public override void Dispose()
//        {
//            sides.Dispose();
//        }

//        protected abstract void Decorate();
//        protected abstract void UnDecorate();

//        public virtual Sides GetOldSides()
//        {
//            UnDecorate();
//            return sides;
//        }
//    }
//}
