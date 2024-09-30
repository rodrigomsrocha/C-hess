using System.Drawing;
using Board;
using View;

namespace Chess
{
  class Program
  {
    public static void Main(string[] args)
    {
      ChessBoard board = new ChessBoard(8, 8);
      try
      {
        board.setPositionPiece(new Tower(board, Color.White), new Position(0, 0));
        board.setPositionPiece(new Tower(board, Color.Black), new Position(1, 4));
        board.setPositionPiece(new King(board, Color.Black), new Position(2, 4));
        Screen.printBoard(board);
      }
      catch (BoardException e)
      {
        Console.WriteLine(e.Message);
      }
    }
  }
}