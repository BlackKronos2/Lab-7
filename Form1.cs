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
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            render1 = new Render(Resource1.b, new Size(100, 100));
            render2 = new Render(Resource1.b, new Size(100, 100));

            render1.position = new PointF(50, 50);
            render2.position = new PointF(200, 50);
        }

        private void Mixing()
        {
            int value1 = random1.Next(1, 7); //получение случайного числа от 1 до 6 
            int value2 = random2.Next(1, 7); //получение случайного числа от 1 до 6 
            Image[] image = new Image[6] { Resource1.b, Resource1.b2, Resource1.b3, Resource1.b4, Resource1.b5, Resource1.b6 };
            render1.sprite = image[value1 - 1];
            render2.sprite = image[value2 - 1];
        }

        //private int Sum()
        //{
        //    return (value1 + value2);
        //}

        private void Update(object sender, EventArgs e) 
        {
            if (button)
            {
                if (!checkBox1.Checked)
                {
                    if (tics <= 1000)
                    {
                        tics += timer1.Interval;
                        button1.Enabled = false;
                        Mixing();
                    }
                    else
                    {
                        button1.Enabled = true;
                        tics = 0;
                        button = false;
                    }
                    Invalidate();
                }
                if (checkBox1.Checked)
                {
                    if (tics < timer1.Interval)
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button = true;
        }
    }
}
