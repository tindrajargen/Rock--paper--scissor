using static Projekt.IPlay;

namespace Projekt
{
    class PlayComputer : IPlay
    {
        Player player1;
        Player computer;

        public PlayComputer(Player player1)
        {
            this.player1 = player1;
        }

        public void RunningGame()
        {
            Turn turn = new Turn();
            Player computer = new Player("Computer");
            this.computer = computer;

            while(turn.CheckPoints(player1, computer) < 3)
            {
                MakeMove(turn);
                turn.ChangeTurn();
            }
            Winner winner = new Winner(player1, computer);
            Console.WriteLine(winner.declareWinner());
        }
        private string MakingMove(Player p){
            Console.WriteLine($"\n{p.name} it is your turn, what move do you want to make?" +
            $"\n1.Rock\n2.Paper\n3.Scissors\n");
            string move = Console.ReadLine();
            return move;
        }
        private string ComputerMove(Player computer)
        {
            Random random = new Random();
            int intMove = random.Next(1, 4);
            string move = intMove.ToString();
            return move;
        }
        private int SaveMove(string move, Player p){
            Console.WriteLine($"\n{p.name}, you have made your move.\n");
                int intMove = int.Parse(move);
                Move pMove = new Move(intMove);
                int madeMove = pMove.getMove(pMove);
                return madeMove;   
        }
        private void MakeMove(Turn turn){
            int p1Move = 0;
            int comMove = 0;

            if(turn.CheckTurn(player1, computer) == player1){
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
                move = ComputerMove(computer);
                switch(move){
                    case "1":
                comMove = SaveMove(move, computer);
                    break;

                    case "2":
                comMove = SaveMove(move, computer);
                    break;

                    case "3":
                comMove = SaveMove(move, computer);
                    break;

                    default:
                    Console.WriteLine("\nThat is not a possible move.");
                    break;
                }
            }
            else{
                string move = ComputerMove(computer);
                switch(move){
                    case "1":
                comMove = SaveMove(move, computer);

                    break;

                    case "2":
                comMove = SaveMove(move, computer);
                    break;

                    case "3":
                comMove = SaveMove(move, computer);
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
            Outcome outcome = new Outcome(p1Move, comMove, player1, computer);
            Console.WriteLine(outcome.CheckOutcome());

        }
    }
}