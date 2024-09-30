using Board.Enums;
using Board;
using View;

namespace Chess
{
  class Program
  {
    public static void Main(string[] args)
    {
      ChessMatch match = new ChessMatch();

      while (!match.over)
      {
        Console.Clear();
        Screen.printBoard(match.board);

        Console.WriteLine();
        Console.Write("Origem: ");
        Position origin = Screen.readChessPosition().toPosition();

        bool [,] possibleMovements = match.board.getPositionPiece(origin).possibleMovements();
        Console.Clear();
        Screen.printBoard(match.board, possibleMovements);
        Console.WriteLine();

        Console.Write("Destino: ");
        Position destination = Screen.readChessPosition().toPosition();

        match.executeMovement(origin, destination);
      }
    }
  }
}