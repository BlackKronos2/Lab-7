using System;
using System.Drawing;
using System.Runtime.Serialization;


namespace Lab_7
{
    [DataContract]
    public class Transform
    {
        [DataMember]
        /// <summary> Позиция обьека (Координаты) </summary>
        private PointF position;

        /// <summary> Перемещение объекта к цели с заданной скоростью </summary>
        public virtual void MoveToward(PointF target, float speed) {
            if (target != position)
            {
                double x = Math.Abs(position.X - target.X);
                double y = Math.Abs(position.Y - target.Y);


                double c = Math.Sqrt((x * x) + (y * y));

                double k = speed / c;

                float delta_x = (float)(x * k);
                float delta_y = (float)(y * k);

                position.X += (target.X > position.X) ? (delta_x) : (-delta_x);
                position.Y += (target.Y > position.Y) ? (delta_y) : (-delta_y);

                if (c < speed)
                {
                    position.X = target.X;
                    position.Y = target.Y;
                }
            }
        }

        /// <summary> Получение/Моментальное изменение координат </summary>
        public PointF Position {
            get { return position; }
            set { position = value; }
        }
    }
}
