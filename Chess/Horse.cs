using Board.Enums;
using Board;

namespace Chess
{
    class Horse : Piece
    {
        public Horse(ChessBoard board, Color color)
          : base(board, color)
        {
        }

        public override bool[,] possibleMovements()
        {
            bool[,] boolBoard = new bool[board.line, board.column];

            Position position = new Position(0, 0);

            position.definePosition(this.position.line - 1, this.position.column - 2);
            if (board.isPostionValid(position) && canMove(position))
            {
                boolBoard[position.line, position.column] = true;
            }
            position.definePosition(this.position.line - 2, this.position.column - 1);
            if (board.isPostionValid(position) && canMove(position))
            {
                boolBoard[position.line, position.column] = true;
            }
            position.definePosition(this.position.line - 2, this.position.column + 1);
            if (board.isPostionValid(position) && canMove(position))
            {
                boolBoard[position.line, position.column] = true;
            }
            position.definePosition(this.position.line - 1, this.position.column + 2);
            if (board.isPostionValid(position) && canMove(position))
            {
                boolBoard[position.line, position.column] = true;
            }
            position.definePosition(this.position.line + 1, this.position.column + 2);
            if (board.isPostionValid(position) && canMove(position))
            {
                boolBoard[position.line, position.column] = true;
            }
            position.definePosition(this.position.line + 2, this.position.column + 1);
            if (board.isPostionValid(position) && canMove(position))
            {
                boolBoard[position.line, position.column] = true;
            }
            position.definePosition(this.position.line + 2, this.position.column - 1);
            if (board.isPostionValid(position) && canMove(position))
            {
                boolBoard[position.line, position.column] = true;
            }
            position.definePosition(this.position.line + 1, this.position.column - 2);
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
            return "H";
        }
    }
}
