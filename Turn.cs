using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class Turn
    {
        bool isPlayer1 = true;

        public Turn(){

        }

        public Player CheckTurn(Player p1, Player p2){
            return (this.isPlayer1 ? p1:p2 );
        }

        public void ChangeTurn(){
            this.isPlayer1 = !isPlayer1;
        }
        
        public int CheckPoints(Player p1, Player p2){
            p1.point.Notify();
            p2.point.Notify();
            int p1Points = p1.point.Score;
            int p2Points = p2.point.Score;

            if(p1Points > p2Points)
            {
                return p1Points;
            }
            else
            {
                return p2Points;
            }
        }
    }
}
