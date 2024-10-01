using Board.Enums;
using Board;

namespace Chess
{
    class Bishop : Piece
    {
        public Bishop(ChessBoard board, Color color)
          : base(board, color)
        {
        }

        public override bool[,] possibleMovements()
        {
            bool[,] boolBoard = new bool[board.line, board.column];

            Position position = new Position(0, 0);

            // up left
            position.definePosition(this.position.line - 1, this.position.column - 1);
            while (board.isPostionValid(position) && canMove(position))
            {
                boolBoard[position.line, position.column] = true;
                if (board.getPositionPiece(position) != null && board.getPositionPiece(position).color != color)
                {
                    break;
                }
                position.definePosition(position.line - 1, position.column - 1);
            }

            // up right
            position.definePosition(this.position.line - 1, this.position.column + 1);
            while (board.isPostionValid(position) && canMove(position))
            {
                boolBoard[position.line, position.column] = true;
                if (board.getPositionPiece(position) != null && board.getPositionPiece(position).color != color)
                {
                    break;
                }
                position.definePosition(position.line - 1, position.column + 1);
            }

            // down right
            position.definePosition(this.position.line + 1, this.position.column + 1);
            while (board.isPostionValid(position) && canMove(position))
            {
                boolBoard[position.line, position.column] = true;
                if (board.getPositionPiece(position) != null && board.getPositionPiece(position).color != color)
                {
                    break;
                }
                position.definePosition(position.line + 1, position.column + 1);
            }

            // down left
            position.definePosition(this.position.line + 1, this.position.column - 1);
            while (board.isPostionValid(position) && canMove(position))
            {
                boolBoard[position.line, position.column] = true;
                if (board.getPositionPiece(position) != null && board.getPositionPiece(position).color != color)
                {
                    break;
                }
                position.definePosition(position.line + 1, position.column - 1);
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
            return "B";
        }
    }
}
