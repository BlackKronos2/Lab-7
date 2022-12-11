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
                new PointF(209, 490),
                new PointF(264, 480),
                new PointF(316, 461),
                new PointF(368, 439),
                new PointF(414, 416),
                new PointF(467, 408),
                new PointF(512, 433),
                new PointF(513, 491),
                new PointF(485, 536),
                new PointF(438, 568),
                new PointF(386, 591),
                new PointF(329, 603),
                new PointF(278, 593),
                new PointF(226, 570),
                new PointF(169, 549),
                new PointF(106, 543),
                new PointF(56, 569),
                new PointF(35, 624),
                new PointF(64, 681),
                new PointF(111, 719),
                new PointF(173, 754),
                new PointF(242, 766),
                new PointF(308, 759),
                new PointF(365, 742),
                new PointF(421, 714),
                new PointF(471, 680),
                new PointF(510, 638),
                new PointF(539, 588),
                new PointF(560, 532),
                new PointF(567, 475),
                new PointF(560, 415),
                new PointF(544, 363),
                new PointF(517, 310),
                new PointF(485, 264),
                new PointF(462, 205),
                new PointF(457, 150),
                new PointF(475, 94),
                new PointF(519, 50),
                new PointF(573, 33),
                new PointF(633, 31),
                new PointF(690, 47),
                new PointF(743, 72),
                new PointF(795, 80),
                new PointF(854, 67),
                new PointF(906, 43),
                new PointF(970, 46),
                new PointF(1015, 84),
                new PointF(1037, 142),
                new PointF(1018, 198),
                new PointF(963, 221),
                new PointF(909, 221),
                new PointF(855, 203),
                new PointF(801, 181),
                new PointF(744, 159),
                new PointF(693, 146),
                new PointF(638, 157),
                new PointF(593, 191),
                new PointF(577, 250),
                new PointF(587, 308),
                new PointF(622, 354),
                new PointF(670, 387),
                new PointF(721, 406),
                new PointF(781, 412),
                new PointF(839, 400),
                new PointF(893, 392),
                new PointF(949, 403),
                new PointF(993, 435),
                new PointF(1001, 499),
                new PointF(952, 539),
                new PointF(892, 533),
                new PointF(831, 520),
                new PointF(768, 512),
                new PointF(711, 515),
                new PointF(654, 534),
                new PointF(609, 570),
                new PointF(589, 633),
                new PointF(608, 694),
                new PointF(655, 739),
                new PointF(716, 757),
                new PointF(776, 761),
                new PointF(834, 759),
                new PointF(892, 741),
                new PointF(942, 705),
                new PointF(985, 668),
                new PointF(1032, 601)

            };

            gameManager = new GameManager(points, 4);

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
                    gameManager.TriggerCheking();
                }


            Statistic();
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

            if (_dices.Animation)
                timer = 1000;
            else
                timer = 50;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            gameManager.Draw(graphics);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            _dices.Animation = !checkBox1.Checked;
        }

        private void Statistic() {
            richTextBox1.Text = gameManager.PlayersStatistics();
        }
    }
}
