using Board.Enums;
using Board;

namespace Chess
{
  class King : Piece
  {
    public King(ChessBoard board, Color color)
      : base(board, color)
    {
    }

    public override bool[,] possibleMovements()
    {
      bool[,] boolBoard = new bool[board.line, board.column];

      Position position = new Position(0, 0);

      // up
      position.definePosition(this.position.line - 1, this.position.column);
      if (board.isPostionValid(position) && canMove(position))
      {
        boolBoard[position.line, position.column] = true;
      }

      // up right
      position.definePosition(this.position.line - 1, this.position.column + 1);
      if (board.isPostionValid(position) && canMove(position))
      {
        boolBoard[position.line, position.column] = true;
      }

      // right
      position.definePosition(this.position.line, this.position.column + 1);
      if (board.isPostionValid(position) && canMove(position))
      {
        boolBoard[position.line, position.column] = true;
      }

      // down right
      position.definePosition(this.position.line + 1, this.position.column + 1);
      if (board.isPostionValid(position) && canMove(position))
      {
        boolBoard[position.line, position.column] = true;
      }

      // down
      position.definePosition(this.position.line + 1, this.position.column);
      if (board.isPostionValid(position) && canMove(position))
      {
        boolBoard[position.line, position.column] = true;
      }

      // down left
      position.definePosition(this.position.line + 1, this.position.column - 1);
      if (board.isPostionValid(position) && canMove(position))
      {
        boolBoard[position.line, position.column] = true;
      }

      // left
      position.definePosition(this.position.line, this.position.column - 1);
      if (board.isPostionValid(position) && canMove(position))
      {
        boolBoard[position.line, position.column] = true;
      }

      // up left
      position.definePosition(this.position.line - 1, this.position.column - 1);
      if (board.isPostionValid(position) && canMove(position))
      {
        boolBoard[position.line, position.column] = true;
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
      return "K";
    }
  }
}