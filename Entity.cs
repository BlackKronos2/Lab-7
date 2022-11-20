using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    public class Entity
    {
        public Image sprite;
        public PointF position;
        public Size entity_size;

        public Entity(Size size) {
            position = new PointF(100, 100);
            entity_size = size;

            sprite = Resource1.TestSprite;
        }
    }
}
