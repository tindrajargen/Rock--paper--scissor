using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class VisualScoreBoard: IObserver
    {
        GamePoint point;
        public VisualScoreBoard(GamePoint point)
        {
          this.point = point;
        }
        public void UpdatePoint()
        {
          this.point.GetPoint();
        }
        public void NewPoint()
        {
            this.point.AddPoint();
        }


    }
}