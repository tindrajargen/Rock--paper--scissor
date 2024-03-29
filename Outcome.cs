﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class Outcome : ICompare<ICompareRPS>
    {

        Player p1;
        Player p2;

        public Outcome(Player p1, Player p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }

        public int CheckOutcome(ICompareRPS m1, ICompareRPS m2)
        {
            int p1move = m1.GetMove();
            int p2move = m2.GetMove();
            if (p1move == 1 && p2move == 2)
            {
                AddPoints(p2);
                ShowPoints();
                return 2;
            }
            else if (p1move == 1 && p2move == 3)
            {
                AddPoints(p1);
                ShowPoints();
                return 1;
            }
            else if (p1move == 2 && p2move == 1)
            {
                AddPoints(p1);
                ShowPoints();
                return 1;
            }
            else if (p1move == 2 && p2move == 3)
            {
                AddPoints(p2);
                ShowPoints();
                return 2;
            }
            else if (p1move == 3 && p2move == 1)
            {
                AddPoints(p2);
                ShowPoints();
                return 2;
            }
            else if (p1move == 3 && p2move == 2)
            {
                AddPoints(p1);
                ShowPoints();
                return 1;
            }
            else if (p1move == p2move)
            {
                ShowPoints();
                return 0;
            }
            else if (p1move != 1 && p1move != 2 && p1move != 3)
            {
                AddPoints(p2);
                ShowPoints();
                PrintErrorMessage(p1);
                return 2;
            }
            else
            {
                AddPoints(p1);
                ShowPoints();
                PrintErrorMessage(p2);
                return 1;
            }

        }

        public void AddPoints(Player winner)
        {
            winner.point.NewPoint(winner);
        }
        private void ShowPoints()
        {
            List<int> pointList = new List<int>();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Scoreboard:");
            p1.point.Notify();
            Console.WriteLine();
            Console.ResetColor();
        }
        private void PrintErrorMessage(Player player)
        {
           Console.WriteLine($"{player.name} you made an invalid move, therefore the other player gets 1 point.");
        }

    }
}
