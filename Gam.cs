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

        int timer;
        GameManager gameManager;
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
                new PointF(100, 500),
                new PointF(200, 500),
                new PointF(300, 500),
                new PointF(400, 500),
                new PointF(500, 500),
                new PointF(600, 500),
                new PointF(700, 500),
                new PointF(800, 500),
                new PointF(900, 500),

                new PointF(900, 400),
                new PointF(800, 400),
                new PointF(700, 400),
                new PointF(600, 400),
                new PointF(500, 400),

            };



            gameManager = new GameManager(points);

            timer = 0;
        }

        private void Game_Load(object sender, EventArgs e)
        {
            this.Text = "Игра";
        }

        private void Game_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            gameManager.Draw(graphics);
            graphics.DrawImage(Resource1.DiceHolst, new PointF(0, 0));
            _dices.DrawDices(graphics);
        }
        private void Update(object sender, EventArgs e)
        {
            button1.Enabled = !_dices.Button;

            _dices.Dice_Update();
            gameManager.GameTic();

            if(_dices.Button)
            if (timer > 0)
                timer -= timer1.Interval;
            else
            {
                gameManager.move_steps += (_dices.Values / 10 + _dices.Values % 10);
            }
            Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _dices.Button = true;
            timer = 1000;
        }
    }
}
