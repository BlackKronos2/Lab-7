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
        PointF next_point;

        public int active_player { get; set; } = 1;
        Player[] player;

        public int move_steps { get; set; }
        public GameManager(PointF[] map_points) {
            points = map_points;
            next_point = map_points[0];
            player[0] = new Player(1, "Player", Resource1.Red, new Size(50, 70), points[0]);

            move_steps = 1;
        }

        public void Draw(Graphics graphics)
        {
            for (int i = 0; i < points.Length; i++)
                graphics.DrawRectangle(Pens.Red, points[i].X, points[i].Y, 2, 2); //красная точка
            player[0].DrawSprite(graphics);
        }

        public void GameTic() {
            if(move_steps > 0)
            if (player[0].Position != next_point)
            {
                    player[0].MoveToward(next_point, 10);
            }
            else {
                if (player[0].point_number == points.Length - 1)
                        player[0].point_number = -1;
                next_point = points[++player[0].point_number];
                move_steps--;
            }
        }
    }
}
