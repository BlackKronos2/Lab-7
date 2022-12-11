﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    class GameManager: TriggersManager
    {
        PointF[] points;
        PointF[] next_point;

        private int move_steps;

        private int firstmoveflag = 0;

        public GameManager(PointF[] map_points, int player_count) {
            points = map_points;

            next_point = new PointF[4] { 
                map_points[0],
                map_points[0],
                map_points[0],
                map_points[0],
            };

            Player[] players = new Player[4] { 
                new Player(1, "Player1", Resource1.Red, new Size(50, 70), points[0]),
                new Player(2, "Player2", Resource1.Blue, new Size(50, 70), points[0]),
                new Player(3, "Player3", Resource1.Green, new Size(50, 70), points[0]),
                new Player(4, "Player4", Resource1.Yellow, new Size(50, 70), points[0])
            };


            _players = players;

            move_steps = 0;
            ActivePlayerNumber = -1;
        }

        public void Draw(Graphics graphics)
        {
            //Для отображения точек по которым ходят игроки
            for (int i = 0; i < points.Length; i++)
                graphics.DrawRectangle(Pens.Red, points[i].X, points[i].Y, 2, 2); 


            for(int i = 0; i < _players.Length;i++)
                _players[i].DrawSprite(graphics);
        }

        public void GameTic() {
            var number = ActivePlayerNumber;

            if (move_steps > 0)
            if (_players[number].Position != next_point[number])
            {
                    _players[number].MoveToward(next_point[number], 10);
            }
            else {
                if (_players[number].point_number == points.Length - 1)
                        _players[number].point_number = 0;
                next_point[number] = points[++_players[number].point_number];

                if (firstmoveflag == number && firstmoveflag <= _players.Length)
                {
                    move_steps++;
                    firstmoveflag++;
                }
                move_steps--;
            }

            CheckPositions();
        }

        public int Move_steps {
            get { return move_steps; }
            set { move_steps = value; }
        }

        private void CheckPositions()
        {
            for (int i = 0; i < _players.Length; i++)
                for (int j = 0; j < _players.Length; j++)
                {
                    if ((_players[i].Name != _players[j].Name) && (_players[i].point_number == _players[j].point_number))
                        _players[i].Shift = _players[j].Shift = true;
                    else
                        _players[i].Shift = _players[j].Shift = false;
                }
        }
    }
}
