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
            position = new PointF(100, 100);
            entity_size = size;

            sprite = Resource1.TestSprite;
        }

        public void DrawSprite(Graphics graphics) {
            graphics.DrawImage(sprite, position.X, position.Y, entity_size.Width, entity_size.Height);
        }
    }
}
