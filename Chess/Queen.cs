using Board.Enums;
using Board;

namespace Chess
{
    class Queen : Piece
    {
        public Queen(ChessBoard board, Color color)
          : base(board, color)
        {
        }

        public override bool[,] possibleMovements()
        {
            bool[,] boolBoard = new bool[board.line, board.column];

            Position position = new Position(0, 0);

            // esquerda
            position.definePosition(this.position.line, this.position.column - 1);
            while (board.isPostionValid(position) && canMove(position))
            {
                boolBoard[position.line, position.column] = true;
                if (board.getPositionPiece(position) != null && board.getPositionPiece(position).color != color)
                {
                    break;
                }
                position.definePosition(position.line, position.column - 1);
            }

            // direita
            position.definePosition(this.position.line, this.position.column + 1);
            while (board.isPostionValid(position) && canMove(position))
            {
                boolBoard[position.line, position.column] = true;
                if (board.getPositionPiece(position) != null && board.getPositionPiece(position).color != color)
                {
                    break;
                }
                position.definePosition(position.line, position.column + 1);
            }

            // acima
            position.definePosition(this.position.line - 1, this.position.column);
            while (board.isPostionValid(position) && canMove(position))
            {
                boolBoard[position.line, position.column] = true;
                if (board.getPositionPiece(position) != null && board.getPositionPiece(position).color != color)
                {
                    break;
                }
                position.definePosition(position.line - 1, position.column);
            }

            // abaixo
            position.definePosition(this.position.line + 1, this.position.column);
            while (board.isPostionValid(position) && canMove(position))
            {
                boolBoard[position.line, position.column] = true;
                if (board.getPositionPiece(position) != null && board.getPositionPiece(position).color != color)
                {
                    break;
                }
                position.definePosition(position.line + 1, position.column);
            }

            // NO
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

            // NE
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

            // SE
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

            // SO
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
            return "Q";
        }
    }
}
