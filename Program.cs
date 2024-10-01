using Board.Enums;
using Board;
using View;
using System.Security;

namespace Chess
{
    class Program
    {
        public static void Main(string[] args)
        {

            try
            {
                ChessMatch match = new ChessMatch();
                while (!match.over)
                {
                    try
                    {
                        Console.Clear();
                        Screen.printMatch(match);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Position origin = Screen.readChessPosition().toPosition();
                        match.validateOriginPosition(origin);

                        bool[,] possibleMovements = match.board.getPositionPiece(origin).possibleMovements();
                        Console.Clear();
                        Screen.printBoard(match.board, possibleMovements);
                        Console.WriteLine();

                        Console.Write("Destino: ");
                        Position destination = Screen.readChessPosition().toPosition();
                        match.validateDestinationPosition(origin, destination);

                        match.executePlay(origin, destination);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
