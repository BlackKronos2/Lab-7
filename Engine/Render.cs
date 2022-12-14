using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;


namespace Lab_7
{
    [DataContract]
    public class Render : Transform
    {
        public Image sprite { get; set; }
        [DataMember]
        public Size entity_size { get; set; }

        public Render(Size size) {
            Position = new PointF(100, 100);
            entity_size = size;

            sprite = Resource1.missing_texture;
        }
        public Render(Image image, Size size)
        {
            Position = new PointF(100, 100);
            entity_size = size;

            sprite = image;
        }

        public Render() {
            sprite = Resource1.missing_texture;
        }

        public virtual void DrawSprite(Graphics graphics) {
            if (sprite == null)
                sprite = Resource1.missing_texture;

            graphics.DrawImage(sprite, Position.X, Position.Y, entity_size.Width, entity_size.Height);
        }
    }
}
