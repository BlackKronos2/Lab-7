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
    public class SerializeGame
    {
        [DataMember]
        internal Dices dices { get; set; }
        [DataMember]
        public int timer { get; set; }
        [DataMember]
        internal GameManager gameManager { get; set; }

        internal SerializeGame(Dices _dices, int _timer, GameManager _gameManager) {
            dices = _dices;
            timer = _timer;
            gameManager = _gameManager;
        }
    }
}
