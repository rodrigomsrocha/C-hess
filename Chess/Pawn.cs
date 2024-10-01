using Board.Enums;
using Board;

namespace Chess
{
    class Pawn : Piece
    {
        public Pawn(ChessBoard board, Color color)
          : base(board, color)
        {
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
                    Position esquerda = new Position(this.position.line, this.position.column - 1);
                    if (board.isPostionValid(esquerda) && isThereEnemy(esquerda))
                    {
                        boolBoard[esquerda.line - 1, esquerda.column] = true;
                    }
                    Position direita = new Position(this.position.line, this.position.column + 1);
                    if (board.isPostionValid(direita) && isThereEnemy(direita))
                    {
                        boolBoard[direita.line - 1, direita.column] = true;
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
                    Position esquerda = new Position(this.position.line, this.position.column - 1);
                    if (board.isPostionValid(esquerda) && isThereEnemy(esquerda))
                    {
                        boolBoard[esquerda.line + 1, esquerda.column] = true;
                    }
                    Position direita = new Position(this.position.line, this.position.column + 1);
                    if (board.isPostionValid(direita) && isThereEnemy(direita))
                    {
                        boolBoard[direita.line + 1, direita.column] = true;
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
