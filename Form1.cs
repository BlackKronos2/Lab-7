using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_7
{
    public partial class Form1 : Form
    {
        int tics = 0;
        bool button = false; 
        static Random random1 = new Random((int)DateTime.Now.Ticks + 600);
        static Random random2 = new Random((int)DateTime.Now.Ticks);

        public Render render1;
        public Render render2;

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 50;
            //timer1.Tick += new EventHandler(Update);
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            render1 = new Render(Resource1.b, new Size(100, 100));
            render2 = new Render(Resource1.b, new Size(100, 100));

            render1.position = new PointF(250, 100);
            render2.position = new PointF(400, 100);
        }

        //private void mixing1()
        //{

        //    const int N = 6;

        //    int value = 1;
        //    int value1 = random1.Next(1, 6); //получение случайного числа от 1 до 6 
        //    switch (value1)
        //    {
        //        case 1:
        //            render11.position = new PointF(250, 100);
        //            break;
        //        case 2:
        //            render12.position = new PointF(250, 100);
        //            break;
        //        case 3:
        //            render13.position = new PointF(250, 100);
        //            break;
        //        case 4:
        //            render14.position = new PointF(250, 100);
        //            break;
        //        case 5:
        //            render15.position = new PointF(250, 100);
        //            break;
        //        case 6:
        //            render16.position = new PointF(250, 100);
        //            break;
        //        default:
        //            break;
        //    }
        //}

        //private void mixing2()
        //{
        //    int value2 = random2.Next(1, 6); //получение случайного числа от 1 до 6 
        //    switch (value2)
        //    {
        //        case 1:
        //            render21.position = new PointF(400, 100);
        //            break;
        //        case 2:
        //            render22.position = new PointF(400, 100);
        //            break;
        //        case 3:
        //            render23.position = new PointF(400, 100);
        //            break;
        //        case 4:
        //            render24.position = new PointF(400, 100);
        //            break;
        //        case 5:
        //            render25.position = new PointF(400, 100);
        //            break;
        //        case 6:
        //            render26.position = new PointF(400, 100);
        //            break;
        //        default:
        //            break;
        //    }
        //}
        private void Mixing()
        {
            int value1 = random1.Next(1, 7); //получение случайного числа от 1 до 6 
            int value2 = random2.Next(1, 7); 
            Image[] image = new Image[6] { Resource1.b, Resource1.b2, Resource1.b3, Resource1.b4, Resource1.b5, Resource1.b6 };
            render1.sprite = image[value1 - 1];
            render2.sprite = image[value2 - 1];
        }

        

        private void Update(object sender, EventArgs e) 
        {
            if (button)
            {
                if (!checkBox1.Checked)
                {
                    if (tics <= 1000)
                    {
                        tics += timer1.Interval;
                        Mixing();
                    }
                    else
                    {
                        tics = 0;
                        button = false;
                    }
                    Invalidate();

                }
                if (checkBox1.Checked)
                {
                    if (tics < 50)
                    {
                        tics += timer1.Interval;
                        Mixing();
                    }
                    else
                    {
                        tics = 0;
                        button = false;
                    }
                    Invalidate();
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            render1.DrawSprite(e.Graphics);
            render2.DrawSprite(e.Graphics);

            //render11.DrawSprite(e.Graphics);
            //render12.DrawSprite(e.Graphics);
            //render13.DrawSprite(e.Graphics);
            //render14.DrawSprite(e.Graphics);
            //render15.DrawSprite(e.Graphics);
            //render16.DrawSprite(e.Graphics);

            //render21.DrawSprite(e.Graphics);
            //render22.DrawSprite(e.Graphics);
            //render23.DrawSprite(e.Graphics);
            //render24.DrawSprite(e.Graphics);
            //render25.DrawSprite(e.Graphics);
            //render26.DrawSprite(e.Graphics);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //По нажатию вызывается метод "перемешать"
            button = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {

            }
        }
    }
}
