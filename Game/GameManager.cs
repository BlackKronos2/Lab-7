using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    class GameManager
    {
        PointF[] points;
        PointF[] next_point;

        public int active_player;
        Player[] player;

        private int move_steps;
        private int activeplayernumber;

        public GameManager(PointF[] map_points) {
            points = map_points;
            next_point = new PointF[3] { 
                map_points[0],
                map_points[0],
                map_points[0]
            };

            player = new Player[3] { 
                new Player(1, "Player1", Resource1.Red, new Size(50, 70), points[0]),
                new Player(2, "Player2", Resource1.Blue, new Size(50, 70), points[0]),
                new Player(3, "Player3", Resource1.Green, new Size(50, 70), points[0])
            };

            move_steps = 0;
            ActivePlayerNumber = player.Length;
        }

        public void Draw(Graphics graphics)
        {
            for (int i = 0; i < points.Length; i++)
                graphics.DrawRectangle(Pens.Red, points[i].X, points[i].Y, 2, 2); 


            for(int i = 0; i < player.Length;i++)
                player[i].DrawSprite(graphics);
        }

        public void GameTic() {
            var number = ActivePlayerNumber - 1;

            if (move_steps > 0)
            if (player[number].Position != next_point[number])
            {
                    player[number].MoveToward(next_point[number], 10);
            }
            else {
                if (player[number].point_number == points.Length - 1)
                        player[number].point_number = 0;
                next_point[number] = points[++player[number].point_number];
                move_steps--;
            }

            CheckPositions();
        }

        public int Move_steps {
            get { return move_steps; }
            set { move_steps = value; }
        }

        private void CheckPositions() {
            for (int i = 0; i < player.Length; i++)
                for (int j = 0; j < player.Length; j++) {
                    if ((player[i].Name != player[j].Name) && (player[i].point_number == player[j].point_number))
                        player[i].Shift = true;
                    else
                        player[i].Shift = false;
                }
        }

        public int ActivePlayerNumber {
            get { return activeplayernumber; }
            set {
                if (value <= player.Length)
                    activeplayernumber = value;
                else
                    activeplayernumber = value - player.Length;
            }
        }
    }
}
