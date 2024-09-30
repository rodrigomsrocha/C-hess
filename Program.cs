using System.Drawing;
using Board;
using View;

namespace Chess
{
  class Program
  {
    public static void Main(string[] args)
    {
      PositionChess positionChess = new PositionChess('a', 1);
      Console.WriteLine(positionChess);
      Console.WriteLine(positionChess.toPosition());
    }
  }
}