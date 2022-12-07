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
    public partial class GameScence : Form
    {
        Dices _dices;
        PointF[] points;

        int timer;
        GameManager gameManager;

        public GameScence()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            timer1.Interval = 50;
            timer1.Tick += new EventHandler(Update);
            timer1.Start();

            _dices = new Dices(new PointF(1200, 80), new PointF(1300, 80), new Size(50, 50), timer1.Interval);
            _dices.Animation = true;


            points = new PointF[] {
                new PointF(110, 82),
                new PointF(183, 45),
                new PointF(242, 47),
                new PointF(301, 65),
                new PointF(348, 98),
                new PointF(369, 148),
                new PointF(347, 205),
                new PointF(295, 238),
                new PointF(238, 255),
                new PointF(175, 262),
                new PointF(113, 276),
                new PointF(65, 308),
                new PointF(37, 356),
                new PointF(29, 419),
                new PointF(57, 463),
                new PointF(103, 484),
                new PointF(155, 493),
            };



            gameManager = new GameManager(points);

            timer = 0;
        }

        private void GameScence_Load(object sender, EventArgs e)
        {
            this.Text = "Игра";
        }
        private void Update(object sender, EventArgs e)
        {
            button1.Enabled = !_dices.Button;

            _dices.Dice_Update();
            gameManager.GameTic();

            if (_dices.Button)
                if (timer > 0)
                    timer -= timer1.Interval;
                else
                {
                    gameManager.Move_steps += (_dices.Values / 10 + _dices.Values % 10);
                    gameManager.ActivePlayerNumber += 1;
                }

            Invalidate(); 
            pictureBox1.Invalidate();
        }

        private void GameScence_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;


            graphics.DrawImage(Resource1.DiceHolst, new PointF(1070, 0));
            _dices.DrawDices(graphics);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _dices.Button = true;
            timer = 1000;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            gameManager.Draw(graphics);
        }
    }
}
