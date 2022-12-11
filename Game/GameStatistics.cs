using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    abstract class GameStatistics
    {
        public Player[] _players;

        public string PlayersStatistics() {
            string statistics = string.Empty;

            int[] players = new int[_players.Length];

            for (int i = 0; i < _players.Length; i++) players[i] = i;

            for (int i = 0; i < _players.Length; i++)
                for (int j = i + 1; j < _players.Length; j++)
                    if (_players[i].point_number < _players[j].point_number)
                    {
                        int k = players[i];
                        players[i] = players[j];
                        players[j] = k;
                    }

            int num;

            for (int i = 0; i < players.Length; i++) {
                num = players[i];
                statistics += $"{i + 1}. {_players[num].Name} \n";
            }

            return statistics;
        }
    }
}
