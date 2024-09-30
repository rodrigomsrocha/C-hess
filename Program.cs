using Board;
using View;

namespace Chess
{
  class Program
  {
    public static void Main(string[] args)
    {
      ChessBoard board = new ChessBoard(8, 8);
      Screen.printBoard(board);
    }
  }
}