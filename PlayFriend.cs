using static Projekt.IPlay;

namespace Projekt
{
    class PlayFriend : IPlay
    {
        Player player1;
        Player player2;

        public PlayFriend(Player player1, Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }
        public void RunningGame()
        {
            Turn turn = new Turn();

            while(turn.CheckPoints(player1, player2) < 3)
            {
                MakeMove(turn);
                turn.ChangeTurn();
            }
            Winner winner = new Winner(player1, player2);
            Console.WriteLine(winner.declareWinner());


        }
                private string MakingMove(Player p){
            Console.WriteLine($"\n{p.name} it is your turn, what move do you want to make?" +
            $"\n1.Rock\n2.Paper\n3.Scissors");
            string move = Console.ReadLine();
            return move;
        }
        private int SaveMove(string move, Player p){
            Console.WriteLine($"\n{p.name}, you have made your move.");
                int intMove = int.Parse(move);
                Move pMove = new Move(intMove);
                int madeMove = pMove.getMove(pMove);
                return madeMove;   
        }
        private void MakeMove(Turn turn){
            int p1Move = 0;
            int p2Move = 0;

            if(turn.CheckTurn(player1, player2) == player1){
                string move = MakingMove(player1);
                switch(move){
                    case "1":
                p1Move = SaveMove(move, player1);
                    break;

                    case "2":
                p1Move = SaveMove(move, player1);
                    break;

                    case "3":
                p1Move = SaveMove(move, player1);
                    break;

                    default:
                    Console.WriteLine("That is not a possible move.");
                    break;
                }
                move = MakingMove(player2);
                switch(move){
                    case "1":
                p2Move = SaveMove(move, player1);
                    break;

                    case "2":
                p2Move = SaveMove(move, player1);
                    break;

                    case "3":
                p2Move = SaveMove(move, player1);
                    break;

                    default:
                    Console.WriteLine("\nThat is not a possible move.");
                    break;
                }
            }
            else{
                string move = MakingMove(player2);
                switch(move){
                    case "1":
                p2Move = SaveMove(move, player1);

                    break;

                    case "2":
                p2Move = SaveMove(move, player1);
                    break;

                    case "3":
                p2Move = SaveMove(move, player1);
                    break;

                    default:
                    Console.WriteLine("That is not a possible move.");
                    break;
                }
                move = MakingMove(player1);
                switch(move){
                    case "1":
                p1Move = SaveMove(move, player1);
                    break;

                    case "2":
                p1Move = SaveMove(move, player1);
                    break;

                    case "3":
                p1Move = SaveMove(move, player1);
                    break;

                    default:
                    Console.WriteLine("That is not a possible move.");
                    break;
                }
                
            }
            Outcome outcome = new Outcome(p1Move, p2Move, player1, player2);
            Console.WriteLine(outcome.CheckOutcome());

        }

    }
}