using Board.Enums;
using Board;

namespace Chess
{
    class King : Piece
    {
        private ChessMatch match;
        public King(ChessBoard board, Color color, ChessMatch match)
      : base(board, color)
        {
            this.match = match;
        }

        private bool canTowerDoRock(Position towerPosition)
        {
            Piece piece = board.getPositionPiece(towerPosition);
            return piece != null && piece is Tower && piece.color == color && piece.movements == 0;
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

            // special movement - rock
            if (movements == 0 && !match.inCheck)
            {
                // small rock
                Position towerPositionSmall = new Position(this.position.line, this.position.column + 3);
                if (canTowerDoRock(towerPositionSmall))
                {
                    Position firstFreeHouse = new Position(this.position.line, this.position.column + 1);
                    Position secondFreeHouse = new Position(this.position.line, this.position.column + 2);
                    if (
                      board.getPositionPiece(firstFreeHouse) == null
                      && board.getPositionPiece(secondFreeHouse) == null)
                    {
                        boolBoard[this.position.line, this.position.column + 2] = true;
                    }
                }

                // big rock
                Position towerPositionBig = new Position(this.position.line, this.position.column - 4);
                if (canTowerDoRock(towerPositionBig))
                {
                    Position firstFreeHouse = new Position(this.position.line, this.position.column - 1);
                    Position secondFreeHouse = new Position(this.position.line, this.position.column - 2);
                    Position thirdFreeHouse = new Position(this.position.line, this.position.column - 3);
                    if (
                      board.getPositionPiece(firstFreeHouse) == null
                      && board.getPositionPiece(secondFreeHouse) == null
                      && board.getPositionPiece(thirdFreeHouse) == null)
                    {
                        boolBoard[this.position.line, this.position.column - 2] = true;
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
            return "K";
        }
    }
}
