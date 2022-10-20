using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Projekt.IMove;

namespace Projekt
{
     class Move: ICompareRPS
    {
        private int move;

        public Move(int move){
            this.move = move;
        }

        public int GetMove()
        {
            return this.move;
        }
    }
}
