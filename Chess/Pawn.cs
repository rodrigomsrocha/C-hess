using Board.Enums;
using Board;

namespace Chess
{
    class Pawn : Piece
    {
        private ChessMatch match;
        public Pawn(ChessBoard board, Color color, ChessMatch match)
          : base(board, color)
        {
            this.match = match;
        }

        private bool isThereEnemy(Position position)
        {
            Piece piece = board.getPositionPiece(position);
            return piece != null && piece.color != color;
        }

        private bool isPositioFree(Position position)
        {
            return board.getPositionPiece(position) == null;
        }

        public override bool[,] possibleMovements()
        {
            bool[,] boolBoard = new bool[board.line, board.column];

            Position pos = new Position(0, 0);

            if (color == Color.White)
            {
                pos.definePosition(this.position.line - 1, this.position.column);
                if (board.isPostionValid(pos) && isPositioFree(pos))
                {
                    boolBoard[pos.line, pos.column] = true;
                }
                pos.definePosition(this.position.line - 2, this.position.column);
                Position destination = new Position(this.position.line - 1, this.position.column);
                if (board.isPostionValid(destination) && isPositioFree(destination) && board.isPostionValid(pos) && isPositioFree(pos) && movements == 0)
                {
                    boolBoard[pos.line, pos.column] = true;
                }
                pos.definePosition(this.position.line - 1, this.position.column - 1);
                if (board.isPostionValid(pos) && isThereEnemy(pos))
                {
                    boolBoard[pos.line, pos.column] = true;
                }
                pos.definePosition(this.position.line - 1, this.position.column + 1);
                if (board.isPostionValid(pos) && isThereEnemy(pos))
                {
                    boolBoard[pos.line, pos.column] = true;
                }

                // #jogadaespecial en passant
                if (this.position.line == 3)
                {
                    Position leftPosition = new Position(this.position.line, this.position.column - 1);
                    if (
                      board.isPostionValid(leftPosition)
                      && isThereEnemy(leftPosition)
                      && board.getPositionPiece(leftPosition) == match.vunerableToEnPassant)
                    {
                        boolBoard[leftPosition.line - 1, leftPosition.column] = true;
                    }
                    Position rightPosition = new Position(this.position.line, this.position.column + 1);
                    if (board.isPostionValid(rightPosition)
                      && isThereEnemy(rightPosition)
                      && board.getPositionPiece(rightPosition) == match.vunerableToEnPassant)
                    {
                        boolBoard[rightPosition.line - 1, rightPosition.column] = true;
                    }
                }
            }
            else
            {
                pos.definePosition(this.position.line + 1, this.position.column);
                if (board.isPostionValid(pos) && isPositioFree(pos))
                {
                    boolBoard[pos.line, pos.column] = true;
                }
                pos.definePosition(this.position.line + 2, this.position.column);
                Position destination = new Position(this.position.line + 1, this.position.column);
                if (board.isPostionValid(destination) && isPositioFree(destination) && board.isPostionValid(pos) && isPositioFree(pos) && movements == 0)
                {
                    boolBoard[pos.line, pos.column] = true;
                }
                pos.definePosition(this.position.line + 1, this.position.column - 1);
                if (board.isPostionValid(pos) && isThereEnemy(pos))
                {
                    boolBoard[pos.line, pos.column] = true;
                }
                pos.definePosition(this.position.line + 1, this.position.column + 1);
                if (board.isPostionValid(pos) && isThereEnemy(pos))
                {
                    boolBoard[pos.line, pos.column] = true;
                }

                // #jogadaespecial en passant
                if (this.position.line == 4)
                {
                    Position leftPosition = new Position(this.position.line, this.position.column - 1);
                    if (board.isPostionValid(leftPosition)
                      && isThereEnemy(leftPosition)
                      && board.getPositionPiece(leftPosition) == match.vunerableToEnPassant)
                    {
                        boolBoard[leftPosition.line + 1, leftPosition.column] = true;
                    }
                    Position rightPosition = new Position(this.position.line, this.position.column + 1);
                    if (board.isPostionValid(rightPosition)
                      && isThereEnemy(rightPosition)
                      && board.getPositionPiece(rightPosition) == match.vunerableToEnPassant)
                    {
                        boolBoard[rightPosition.line + 1, rightPosition.column] = true;
                    }
                }
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
            return "P";
        }
    }
}
