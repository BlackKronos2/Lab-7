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
        public Render entity;

        public PointF[] points;
        public int index = 0;
        public Form1()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);


            timer1.Interval = 10;
            timer1.Tick += new EventHandler(Update);
            timer1.Start();

            entity = new Render(new Size(100, 100));
            points = new PointF[] {
                new PointF(300, 60),
                new PointF(280, 40),
                new PointF(250, 70),
            };
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Update(object sender, EventArgs e) {
            if(index < points.Length)
            if (entity.MoveToward(points[index], 1))
                index++;
            Invalidate();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            entity.DrawSprite(graphics);
        }
    }
}
