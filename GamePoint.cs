using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class GamePoint: IObservable 
    {
        public int Score;
        public GamePoint()
        {

        }
        List<IObserver> Observer = new List<IObserver>();
        public void Add(IObserver observ)
        {
          this.Observer.Add(observ);

        }
        public void Remove(IObserver observ)
        {
          this.Observer.Remove(observ);
        }

        public void Notify()
        {
          foreach(IObserver observ in this.Observer)
          {
             observ.UpdatePoint();
          }
        }
        public void Notify2()
        {
          foreach(IObserver observ in this.Observer)
          {
             observ.NewPoint();
          }
        }

        public int GetPoint()
        {
            return this.Score;
        }

        public int AddPoint()
        {
          return this.Score++;
        }
    }
}
