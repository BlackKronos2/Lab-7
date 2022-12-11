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
        public bool Shift { get; set; } = true;
        PointF delta;

        public Player(int newnumber, string newname, Image image, Size size, PointF point) {
            number = newnumber;
            Position = point;
            Name = newname;
            sprite = image;
            entity_size = size;
            point_number = 0;

            switch (newnumber) {
                case 1: shift = new PointF(0, -10f); break;
                case 2: shift = new PointF(-10f, 0); break;
                case 3: shift = new PointF(0, 10f); break;
                case 4: shift = new PointF(10f, 0); break;

                default: break;
            }

            delta = new PointF(entity_size.Width / 2 + 25 , 90);
        }

        public override void DrawSprite(Graphics graphics) {
            float renderx = Position.X - (delta.X / 2) + ((Shift) ? (shift.X): (0));
            float rendery = Position.Y - (delta.Y / 2) + ((Shift) ? (shift.Y) : (0));

            graphics.DrawImage(sprite, renderx, rendery, entity_size.Width, entity_size.Height);
        }
    }
}
