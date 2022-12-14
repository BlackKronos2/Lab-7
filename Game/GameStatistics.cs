using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;


namespace Lab_7
{
    [DataContract]
    public abstract class GameStatistics
    {
        [DataMember]
        public List<Player> _players;
        [DataMember]
        public List<Player> players_finish;

        public string PlayersStatistics() {
            string statistics = string.Empty;

            int[] players = new int[_players.Count];

            for (int i = 0; i < _players.Count; i++) players[i] = i;

            for (int i = 0; i < _players.Count; i++)
                for (int j = i + 1; j < _players.Count; j++)
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
