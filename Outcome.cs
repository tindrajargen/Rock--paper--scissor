using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class Outcome
    {
        int p1move;
        int p2move;

        Player p1;
        Player p2;

        public Outcome(int p1move, int p2move, Player p1, Player p2){
            this.p1move = p1move;
            this.p2move = p2move;
            this.p1 = p1;
            this.p2 = p2;
        }

        public string CheckOutcome()
        {
            if(p1move == p2move){
                Console.WriteLine(ShowPoints());
                return p1move switch{
                    1 => "You both chose rock, \n no scores are therefore given.",
                    2 => "You both chose paper, \n no scores are therefore given.", 
                    3 => "You both chose scissors, \n no scores are therefore given.",
                    _ => "Something went wrong!"
                };
            }
            else if(p1move == 1 && p2move == 2){
                AddPoints(p2);
                return $"{p1.name} chose rock and {p2.name} chose paper, \nTherefore {p2.name}" +
                $" gets 1 point.\n {ShowPoints()}";
            }
            else if(p1move == 1 && p2move == 3){
                AddPoints(p1);
                return $"{p1.name} chose rock and {p2.name} chose scissors, \nTherefore {p1.name}" +
                $" gets 1 point.\n {ShowPoints()}";
            }
            else if(p1move == 2 && p2move == 1){
                AddPoints(p1);
                return $"{p1.name} chose paper and {p2.name} chose rock, \nTherefore {p1.name}" +
                $" gets 1 point.\n {ShowPoints()}";
            }
            else if(p1move == 2 && p2move == 3){
                AddPoints(p2);
                return $"{p1.name} chose paper and {p2.name} chose scissors, \nTherefore {p2.name}" +
                $" gets 1 point. \n {ShowPoints()}";
            }
            else if(p1move == 3 && p2move == 1){
                AddPoints(p2);
                return $"{p1.name} chose scissors and {p2.name} chose rock, \nTherefore {p2.name}" +
                $" gets 1 point.\n {ShowPoints()}";
            }
            else if(p1move == 3 && p2move == 2){
                AddPoints(p1);
                return $"{p1.name} chose scissors and {p2.name} chose paper, \nTherefore {p1.name}" +
                $" gets 1 point.\n {ShowPoints()}";
            }
            else
            {
                return"Something went wrong!";
            }
            
        }
        private void AddPoints(Player winner){
            winner.point.Notify2();
        }
        private string ShowPoints(){
            p1.point.Notify();
            p2.point.Notify();
            int points1 = p1.point.Score;
            int ponits2 = p2.point.Score;

            return $"\nScore board:\n{p1.name}: {p1.point}\n{p2.name}: {p2.point}";
        }
    }
}
