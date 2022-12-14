﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Lab_7
{
    [DataContract]
    public class SerializeProp
    {
        [DataMember]
        public Dices dices { get; set; }
        [DataMember]
        public int timer { get; set; }
        [DataMember]
        GameManager gameManager;

        internal SerializeProp(Dices dices, int timer, GameManager gameManager) {
            this.dices = dices;
            this.timer = timer;
            this.gameManager = gameManager;
        }

        internal GameManager GetGameManager() {
            return gameManager;
        }
    }
}
