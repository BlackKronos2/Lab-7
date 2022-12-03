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
        public Render render;
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 10;
            //timer1.Tick += new EventHandler(Update);
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            timer1.Interval = 10;
            //timer1.Tick += new EventHandler(Update);
            timer1.Start();
            render = new Render(Resource1.b, new Size(100, 100));
            render.position = new PointF(200, 100);
        }

        private void Update(object sender, EventArgs e) 
        {
            render.position.X += 1;
            render.sprite = Resource1.b4;

            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            render.DrawSprite(e.Graphics);
        }
    }
}
