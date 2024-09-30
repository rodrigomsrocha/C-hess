using Board.Enums;
using Board;
using Chess;

namespace View
{
  class Screen
  {
    public static void printBoard(ChessBoard board)
    {
      for (int i = 0; i < board.line; i++)
      {
        Console.Write(8 - i + " ");
        for (int j = 0; j < board.column; j++)
        {
          printPiece(board.getPositionPiece(i, j));
        }
        Console.WriteLine();
      }
      Console.WriteLine("  a b c d e f g h");
    }

    public static void printBoard(ChessBoard board, bool[,] possibleMovements)
    {
      ConsoleColor originalBackground = Console.BackgroundColor;
      ConsoleColor alteredBackground = ConsoleColor.DarkGray;

      for (int i = 0; i < board.line; i++)
      {
        Console.Write(8 - i + " ");
        for (int j = 0; j < board.column; j++)
        {
          if (possibleMovements[i, j])
          {
            Console.BackgroundColor = alteredBackground;
          }
          else
          {
            Console.BackgroundColor = originalBackground;
          }
          printPiece(board.getPositionPiece(i, j));
          Console.BackgroundColor = originalBackground;
        }
        Console.WriteLine();
      }
      Console.WriteLine("  a b c d e f g h");
      Console.BackgroundColor = originalBackground;
    }

    public static void printPiece(Piece piece)
    {
      if (piece == null)
      {
        Console.Write("- ");
      }
      else
      {
        if (piece.color == Color.White)
        {
          Console.Write(piece);
          Console.Write(" ");
        }
        else
        {
          ConsoleColor aux = Console.ForegroundColor;
          Console.ForegroundColor = ConsoleColor.Yellow;
          Console.Write(piece);
          Console.ForegroundColor = aux;
          Console.Write(" ");
        }
      }
    }

    public static PositionChess readChessPosition()
    {
      string postionString = Console.ReadLine() ?? "";
      char column = postionString[0];
      int line = int.Parse(postionString[1] + "");
      return new PositionChess(column, line);
    }
  }
}