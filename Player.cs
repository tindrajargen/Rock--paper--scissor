using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    internal class Player
    {
        public string name;
        public GamePoint point;

        public Player(string name, GamePoint point)
        {
            this.name = name;
            this.point = point;

        }

    }
}
