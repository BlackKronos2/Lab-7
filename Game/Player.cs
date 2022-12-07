using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Lab_7
{
    class Player : Render
    {
        int number;
        public string Name { get; set; } = "";
        public int point_number { get; set; } = 0;

        PointF shift;

        public Player(int newnumber, string newname, Image image, Size size, PointF point) {
            number = newnumber;
            Position = point;
            Name = newname;
            sprite = image;
            entity_size = size;
            point_number = 0;

            switch (number) {
                case 1: shift = new PointF(0, 10); break;
                case 2: shift = new PointF(10, 0); break;
                case 3: shift = new PointF(0, -10); break;
                case 4: shift = new PointF(0, -10); break;

                default: break;
            }
        }

        public void ShiftPosition(bool do_shift) {
            PointF new_point;
            if (do_shift)
                new_point = new PointF(Position.X + shift.X, Position.Y + shift.Y);
            else
                new_point = new PointF(Position.X - shift.X, Position.Y - shift.Y);
            Position = new_point;
        }

        public override void DrawSprite(Graphics graphics) {
            graphics.DrawImage(sprite, Position.X - (entity_size.Width / 2), Position.Y - (entity_size.Height / 2), entity_size.Width, entity_size.Height);
        }
    }
}
