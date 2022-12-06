using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab_7
{
    class Dices
    {
        int tics = 0;
        private int timer_interval;
        private int value1;
        private int value2;
        public bool Button { get; set; } = false;
        public bool Animation { get; set; } = true;

        static Random random1 = new Random((int)DateTime.Now.Ticks + 600);
        static Random random2 = new Random((int)DateTime.Now.Ticks);

        public Render render1;
        public Render render2;

        public Dices(PointF point1, PointF point2, Size size, int update_Interval) {
            render1 = new Render(Resource1.Dice_1, size);
            render1.Position = point1;
            render2 = new Render(Resource1.Dice_1, size);
            render2.Position = point2;

            timer_interval = update_Interval;

            value1 = value2 = 1;
        }

        private void Mixing()
        {
            value1 = random1.Next(1, 7); //получение случайного числа от 1 до 6 
            value2 = random2.Next(1, 7); //получение случайного числа от 1 до 6 
            Image[] image = new Image[6] { 
                Resource1.Dice_1, 
                Resource1.Dice_2, 
                Resource1.Dice_3,
                Resource1.Dice_4,
                Resource1.Dice_5,
                Resource1.Dice_6 
            };
            render1.sprite = image[value1 - 1];
            render2.sprite = image[value2 - 1];
        }

        public void Dice_Update()
        {
            if (Button)
                if (Animation)
                {
                    if (tics <= 1000)
                    {
                        tics += timer_interval;
                        Mixing();
                    }
                    else
                    {
                        tics = 0;
                        Button = false;
                    }
                }
                else {
                    Mixing();
                    Button = false;
                }
        }

        public int Values {
            get { return value1 * 10 + value2; }
        }
    }
}
