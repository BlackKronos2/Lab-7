using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;


namespace Lab_7
{
    [DataContract]
    public class Dices
    {
        [DataMember]
        /// <summary> Таймер для анимации </summary>
        int tics;
        [DataMember]
        /// <summary> Длина анимации </summary>
        private int timer_interval;
        [DataMember]
        /// <summary> Значение кубика 1 (от 1 до 6) </summary>
        private int value1;
        [DataMember]
        /// <summary> Значение кубика 2 (от 1 до 6) </summary>
        private int value2;
        [DataMember]
        /// <summary> Нажатие на кнопку </summary>
        public bool Button { get; set; }
        [DataMember]
        /// <summary> Будет ли анимация перемешивания кубиков </summary>
        public bool Animation { get; set; }

        //Датчики случайных величин
        static Random random1 = new Random((int)DateTime.Now.Ticks + 600);
        static Random random2 = new Random((int)DateTime.Now.Ticks);

        [DataMember]
        /// <summary> Куб 1 </summary>
        public Render render1;
        [DataMember]
        /// <summary> Куб 2 </summary>
        public Render render2;

        /// <summary> Изображения кубиков </summary>
        static Image[] image = new Image[6] {
                Resource1.Dice_1,
                Resource1.Dice_2,
                Resource1.Dice_3,
                Resource1.Dice_4,
                Resource1.Dice_5,
                Resource1.Dice_6
        };

        /// <summary> Конструктор </summary>
        public Dices(PointF point1, PointF point2, Size size, int update_Interval) {
            render1 = new Render(Resource1.Dice_1, size);
            render1.Position = point1;

            render2 = new Render(Resource1.Dice_1, size);
            render2.Position = point2;

            timer_interval = update_Interval;

            value1 = value2 = 1;

            Button = false;
            Animation = true;

            tics = 0;

        }

        /// <summary> Смена значения и изображения (перемешивание кубов) </summary>
        private void Mixing()
        {
            value1 = random1.Next(1, 7); //получение случайного числа от 1 до 6 
            value2 = random2.Next(1, 7); //получение случайного числа от 1 до 6 

            render1.sprite = image[value1 - 1];
            render2.sprite = image[value2 - 1];
        }

        /// <summary> События по фиксирванному таймеру </summary>
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
                    if(tics == 0)
                        Mixing();

                    if (tics <= 50)
                    {
                        tics += timer_interval;
                    }
                    else
                    {
                        Button = false;
                        tics = 0;
                    }
                }
        }

        /// <summary> Получение значений кубиков </summary>
        public int Values {
            get { return value1 * 10 + value2; }
        }

        /// <summary> Отрисовка кубиков </summary>
        public void DrawDices(Graphics graphics) 
        {
            if (render1.sprite == null || render2.sprite == null) {
                render1.sprite = image[value1 - 1];
                render2.sprite = image[value2 - 1];
            }

            render1.DrawSprite(graphics);
            render2.DrawSprite(graphics);
        }
    }
}
