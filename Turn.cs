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


        public Player CheckTurn(Player p1, Player p2){
            return (this.isPlayer1 ? p1:p2 );
        }

        public void ChangeTurn(){
            this.isPlayer1 = !isPlayer1;
        }
        
        public List<int> ReturnPoints(Player p1, Player p2){
            int p1Points = p1.pointKeeper.score;
            int p2Points = p2.pointKeeper.score;
            
            List<int> returnList = new List<int>();
            returnList.Add(p1Points);
            returnList.Add(p2Points);

            return returnList;
        }
    }
}
