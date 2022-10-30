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
        public PointKeeper pointKeeper;

        public Player(string name, GamePoint point, PointKeeper pointKeeper)
        {
            this.name = name;
            this.point = point;
            this.pointKeeper = pointKeeper;

        }
        public void PrintRoundWinnerMessage()
        {
            Console.WriteLine($"{this.name} gets 1 point");
        }

    }
}
