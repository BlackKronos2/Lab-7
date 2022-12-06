using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    public class Render: Transform
    {
        public Image sprite;
        public Size entity_size;

        public Render(Size size) {
            Position = new PointF(100, 100);
            entity_size = size;

            sprite = Resource1.TestSprite;
        }
        public Render(Image image, Size size)
        {
            Position = new PointF(100, 100);
            entity_size = size;

            sprite = image;
        }

        public void DrawSprite(Graphics graphics) {
            graphics.DrawImage(sprite, Position.X, Position.Y, entity_size.Width, entity_size.Height);
        }
    }
}
