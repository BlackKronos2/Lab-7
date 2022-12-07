using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    public class Transform
    {
        private PointF position;

        public bool MoveToward(PointF target, float speed) {
            if (position.X != target.X)
                if (Math.Abs(position.X - target.X) < speed && speed != 1)
                {
                    speed = 1;
                    position.X += (position.X < target.X) ? (speed) : (-speed);
                }
                else
                    position.X += (position.X < target.X) ? (speed) : (-speed);
            else
            if (position.Y != target.Y)
                if (Math.Abs(position.Y - target.Y) < speed && speed != 1)
                {
                    speed = 1;
                    position.Y += (position.Y < target.Y) ? (speed) : (-speed);
                }
                else
                    position.Y += (position.Y < target.Y) ? (speed) : (-speed);

            if (position == target)
                return true;
            else
                return false;
        }

        public PointF Position {
            get { return position; }
            set { position = value; }
        }
    }
}
