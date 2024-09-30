using System.Drawing;
using Board;

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
          if (board.getPositionPiece(i, j) == null)
          {
            Console.Write("- ");
          }
          else
          {
            printPiece(board.getPositionPiece(i, j));
            Console.Write(" ");
          }
        }
        Console.WriteLine();
      }
      Console.WriteLine("  a b c d e f g h");
    }

    public static void printPiece(Piece piece)
    {
      if (piece.color == Color.White)
      {
        Console.Write(piece);
      }
      else
      {
        ConsoleColor aux = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(piece);
        Console.ForegroundColor = aux;
      }
    }
  }
}