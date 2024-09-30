using Board;

namespace View
{
  class Screen
  {
    public static void printBoard(ChessBoard board)
    {
      for (int i = 0; i < board.line; i++)
      {
        for (int j = 0; j < board.column; j++)
        {
          if (board.getPositionPiece(i, j) == null)
          {
            Console.Write("- ");
          }
          else
          {
            Console.Write(board.getPositionPiece(i, j) + " ");
          }
        }
        Console.WriteLine();
      }
    }
  }
}