using Board.Enums;

namespace Board
{
    abstract class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int movements { get; protected set; }
        public ChessBoard board { get; protected set; }

        public Piece(ChessBoard board, Color color)
        {
            this.position = null;
            this.board = board;
            this.color = color;
            this.movements = 0;
        }

        public void incrementMovements()
        {
            movements++;
        }

        public void decrementMovements()
        {
            movements--;
        }

        public bool canMoveTo(Position destination)
        {
            return possibleMovements()[destination.line, destination.column];
        }

        public bool isTherePossibleMovements()
        {
            bool[,] possibleMovementsMatriz = possibleMovements();
            for (int i = 0; i < board.line; i++)
            {
                for (int j = 0; j < board.column; j++)
                {
                    if (possibleMovementsMatriz[i, j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public abstract bool[,] possibleMovements();
    }
}
