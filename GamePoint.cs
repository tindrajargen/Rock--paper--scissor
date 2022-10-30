using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class GamePoint: IObservable 
    {
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
             observ.UpdatePoint(observ);
          }
        }
        public void NewPoint(Player winner)
        {
            foreach(IObserver observ in this.Observer)
            {
              if(observ == winner.pointKeeper)
              {
                  observ.NewPoint();
              }
            }
        }

        public void PrintScore(int score, string name)
        {
          Console.WriteLine($"{name}: {score}");
        }


    }
}
