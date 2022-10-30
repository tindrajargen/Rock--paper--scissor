using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class PointKeeper: IObserver
    {
        public int score;
        public GamePoint gamePoint;
        public List<Player>? playerList;

        public PointKeeper(GamePoint gamePoint)
        {
          this.gamePoint = gamePoint;
          List<Player> playerList = new List<Player>();
          this.playerList = playerList;
        }
        public void SavePlayer(Player player)
        {
          if(playerList is null)
          {
            throw new ArgumentNullException("PlayerList is null");
          }
          
          playerList.Add(player);
        }

        public void UpdatePoint(IObserver observ)
        {
          string name = "";

          if(playerList is null)
          {
            throw new ArgumentNullException("PlayerList is null");
          }

          foreach(Player p in playerList)
          {
            if(p.pointKeeper == observ)
            {
              name = p.name;
            }
          }
          gamePoint.PrintScore(this.score, name);
        }
        public int NewPoint()
        {
            return this.score++;
        }


    }
}