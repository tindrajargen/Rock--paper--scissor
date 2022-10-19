using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projekt
{
    class Winner
    {
        Player winner;
        Player p1;
        Player p2;

        public Winner(Player p1, Player p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }

        private void getWinner()
        {
            if(p1.point.Score == 3)
            {
                this.winner = p1;
            }
            else
            {
                this.winner = p2;
            }
        }

        public string declareWinner()
        {
            getWinner();
            return $"Congratulations {winner.name}, you won the game!";
        }
    }
}