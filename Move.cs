using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Projekt.IMove;

namespace Projekt
{
     class Move: IMove
    {
        private int move;

        public Move(int move){
            this.move = move;
        }

        public int getMove(Move wantedMove)
        {
            return wantedMove.move;
        }
    }
}
