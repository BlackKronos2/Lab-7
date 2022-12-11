using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab_7
{
    class TriggersManager: GameStatistics
    {
        private int activeplayernumber;
        private int[] yellow_points = new int[]{ 
            6,
            48,
            64,
            84,
            89
        };

        private int[] green_points = new int[] { 
            10,
            52,
            71,
            76
        };

        bool green_flag;

        private int skip_number = -5;

        public int ActivePlayerNumber
        {
            get { return activeplayernumber; }
            set
            {
                activeplayernumber = value % _players.Length;
            }
        }


        public void TriggerCheking() {
            green_flag = false;

            for (int i = 0; i < green_points.Length; i++)
                if (_players[(activeplayernumber == -1) ? (0):(activeplayernumber)].point_number == green_points[i])
                {
                    green_flag = true;
                    break;
                }

            for (int i = 0; i < yellow_points.Length; i++)
                if (_players[(activeplayernumber == -1) ? (0) : (activeplayernumber)].point_number == yellow_points[i])
                {
                    skip_number = ActivePlayerNumber;
                    break;
                }


            if (!green_flag)
                if ((ActivePlayerNumber + 1) % _players.Length == skip_number)
                {
                    ActivePlayerNumber += 2;
                    skip_number = -5;
                }
                else
                    ActivePlayerNumber += 1;
            else
                green_flag = false;
        }
    }
}
