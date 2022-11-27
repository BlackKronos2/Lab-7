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
        public PointF point1;

        public Form1()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                

            timer1.Interval = 10;
            timer1.Tick += new EventHandler(Update);
            timer1.Start();

            entity = new Render(new Size(100, 100));
            point1 = new PointF(300, 60);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Update(object sender, EventArgs e) {
            entity.MoveToward(point1, 5);

            Invalidate();

        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            entity.DrawSprite(graphics);
        }
    }
}
