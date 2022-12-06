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
        private PointF[] points;
        private int players_numbers;

        private Render[] players = new Render[3];

        private int[] players_positions = new int[3];

        public GameManager(PointF[] map_points) {
            for (int i = 0; i < players_positions.Length; i++)
                players_positions[i] = 0;
            for (int i = 0; i < players.Length; i++)
                players[i].Position = points[0];

        }

        public void PlayerMove(int player_number, int distance) {
            players_positions[players_numbers] += distance;
            players[players_numbers].MoveToward(points[players_positions[players_numbers]], 1);
        }
    }
}
