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
    public partial class GameForm : Form
    {
        Dices _dices;
        PointF[] points;

        public GameForm()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            timer1.Interval = 50;
            timer1.Tick += new EventHandler(Update);
            timer1.Start();

            _dices = new Dices(new PointF(100, 80), new PointF(250, 80), new Size(50, 50), timer1.Interval);
            _dices.Animation = true;


            points = new PointF[] {
                new PointF()
            };

        }

        private void Game_Load(object sender, EventArgs e)
        {
            this.Text = "Игра";
        }

        private void Game_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            graphics.DrawImage(Resource1.Dice_holst, new PointF(0, 0));
            _dices.DrawDices(graphics);
        }
        private void Update(object sender, EventArgs e)
        {
            button1.Enabled = !_dices.Button;

            _dices.Dice_Update();
            Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _dices.Button = true;

        }
    }
}
