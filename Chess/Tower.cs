using Board.Enums;
using Board;

namespace Chess
{
  class Tower : Piece
  {
    public Tower(ChessBoard board, Color color)
      : base(board, color)
    {
    }

    public override bool[,] possibleMovements()
    {
      bool[,] boolBoard = new bool[board.line, board.column];

      Position position = new Position(0, 0);

      // up
      position.definePosition(this.position.line - 1, this.position.column);
      while (board.isPostionValid(position) && canMove(position))
      {
        boolBoard[position.line, position.column] = true;
        if(board.getPositionPiece(position) != null && board.getPositionPiece(position).color != color)
        {
          break;
        }
        position.line--;
      }

      // down
      position.definePosition(this.position.line + 1, this.position.column);
      while (board.isPostionValid(position) && canMove(position))
      {
        boolBoard[position.line, position.column] = true;
        if(board.getPositionPiece(position) != null && board.getPositionPiece(position).color != color)
        {
          break;
        }
        position.line++;
      }

      // rihht
      position.definePosition(this.position.line, this.position.column + 1);
      while (board.isPostionValid(position) && canMove(position))
      {
        boolBoard[position.line, position.column] = true;
        if(board.getPositionPiece(position) != null && board.getPositionPiece(position).color != color)
        {
          break;
        }
        position.column++;
      }

      // left
      position.definePosition(this.position.line, this.position.column - 1);
      while (board.isPostionValid(position) && canMove(position))
      {
        boolBoard[position.line, position.column] = true;
        if(board.getPositionPiece(position) != null && board.getPositionPiece(position).color != color)
        {
          break;
        }
        position.column--;
      }

      return boolBoard;
    }

    private bool canMove(Position position)
    {
      Piece piece = board.getPositionPiece(position);
      return piece == null || piece.color != color;
    }


    public override string ToString()
    {
      return "T";
    }
  }
}