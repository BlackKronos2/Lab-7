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
        public PointF position;

        public bool MoveToward(PointF target, float speed)
        {

            if (position.X != target.X)
                position.X += (position.X < target.X) ? (speed) : (-speed);

            if (position.Y != target.Y)
                position.Y += (position.Y < target.Y) ? (speed) : (-speed);

            if (position == target)
                return true;
            else
                return false;
        }
    }
}