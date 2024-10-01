using Board.Enums;
using Board;

namespace Chess
{
    class ChessMatch
    {
        public ChessBoard board { get; set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool over { get; private set; }
        public bool inCheck { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;

        public ChessMatch()
        {
            board = new ChessBoard(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            over = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            setupPieces();
        }

        public void validateOriginPosition(Position origin)
        {
            if (board.getPositionPiece(origin) == null)
            {
                throw new BoardException("There isn't any pieces at this position");
            }

            if (currentPlayer != board.getPositionPiece(origin).color)
            {
                throw new BoardException("This piece isn't yours");
            }

            if (!board.getPositionPiece(origin).isTherePossibleMovements())
            {
                throw new BoardException("There's no possible movements for this piece");
            }
        }


        public void validateDestinationPosition(Position origin, Position destination)
        {
            if (!board.getPositionPiece(origin).isAPossibleMovement(destination))
            {
                throw new BoardException("You can not carry out this movement");
            }
        }

        public void unmakePlay(Position origin, Position destination, Piece capturedPiece)
        {
            Piece piece = board.removePiece(destination);
            piece.decrementMovements();
            if (capturedPiece != null)
            {
                board.setPositionPiece(capturedPiece, destination);
                captured.Remove(capturedPiece);
            }
            board.setPositionPiece(piece, origin);

            // speial play - small rock
            if (piece is King && destination.column == origin.column + 2)
            {
                Position towerOrigin = new Position(origin.line, origin.column + 3);
                Position towerDestination = new Position(origin.line, origin.column + 1);
                Piece tower = board.removePiece(towerDestination);
                tower.decrementMovements();
                board.setPositionPiece(tower, towerOrigin);
            }

            // speial play - big rock
            if (piece is King && destination.column == origin.column - 2)
            {
                Position towerOrigin = new Position(origin.line, origin.column - 4);
                Position towerDestination = new Position(origin.line, origin.column - 1);
                Piece tower = board.removePiece(towerDestination);
                tower.decrementMovements();
                board.setPositionPiece(tower, towerOrigin);
            }
        }

        public void executePlay(Position origin, Position destination)
        {
            Piece capturedPiece = executeMovement(origin, destination);

            if (isKingInCheck(currentPlayer))
            {
                unmakePlay(origin, destination, capturedPiece);
                throw new BoardException("You cannot put yourself in check");
            }

            if (isKingInCheck(adversary(currentPlayer)))
            {
                inCheck = true;
            }
            else
            {
                inCheck = false;
            }

            if (isKingInCheckmate(adversary(currentPlayer)))
            {
                over = true;
            }
            else
            {
                turn++;
                changePlayer();
            }

        }

        public Piece executeMovement(Position origin, Position destination)
        {
            Piece piece = board.removePiece(origin);
            piece.incrementMovements();
            Piece capturedPiece = board.removePiece(destination);
            board.setPositionPiece(piece, destination);
            if (capturedPiece != null)
            {
                captured.Add(capturedPiece);
            }

            // speial play - small rock
            if (piece is King && destination.column == origin.column + 2)
            {
                Position towerOrigin = new Position(origin.line, origin.column + 3);
                Position towerDestination = new Position(origin.line, origin.column + 1);
                Piece tower = board.removePiece(towerOrigin);
                tower.incrementMovements();
                board.setPositionPiece(tower, towerDestination);
            }

            // speial play - big rock
            if (piece is King && destination.column == origin.column - 2)
            {
                Position towerOrigin = new Position(origin.line, origin.column - 4);
                Position towerDestination = new Position(origin.line, origin.column - 1);
                Piece tower = board.removePiece(towerOrigin);
                tower.incrementMovements();
                board.setPositionPiece(tower, towerDestination);
            }

            return capturedPiece;
        }

        private void changePlayer()
        {
            if (currentPlayer == Color.Black)
            {
                currentPlayer = Color.White;
            }
            else
            {
                currentPlayer = Color.Black;
            }
        }

        public HashSet<Piece> capturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece piece in captured)
            {
                if (piece.color == color)
                {
                    aux.Add(piece);
                }
            }

            return aux;
        }

        public HashSet<Piece> piecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece piece in pieces)
            {
                if (piece.color == color)
                {
                    aux.Add(piece);
                }
            }

            aux.ExceptWith(capturedPieces(color));
            return aux;
        }

        private Color adversary(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece getKing(Color color)
        {
            foreach (Piece piece in piecesInGame(color))
            {
                if (piece is King)
                {
                    return piece;
                }
            }

            return null;
        }

        public bool isKingInCheck(Color color)
        {
            Piece king = getKing(color);
            foreach (Piece piece in piecesInGame(adversary(color)))
            {
                bool[,] adversaryPossibleMovements = piece.possibleMovements();
                if (adversaryPossibleMovements[king.position.line, king.position.column] == true)
                {
                    return true;
                }
            }
            return false;
        }

        public bool isKingInCheckmate(Color color)
        {
            if (!isKingInCheck(color))
            {
                return false;
            }

            foreach (Piece piece in piecesInGame(color))
            {
                bool[,] currentPlayerPossibleMovements = piece.possibleMovements();
                for (int i = 0; i < board.line; i++)
                {
                    for (int j = 0; j < board.column; j++)
                    {
                        if (currentPlayerPossibleMovements[i, j])
                        {
                            Position origin = piece.position;
                            Position destination = new Position(i, j);
                            Piece capturedPiece = executeMovement(origin, destination);
                            bool stillInCheck = isKingInCheck(color);
                            unmakePlay(origin, destination, capturedPiece);
                            if (!stillInCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void setupNewPiece(char column, int line, Piece piece)
        {
            board.setPositionPiece(piece, new PositionChess(column, line).toPosition());
            pieces.Add(piece);
        }

        private void setupPieces()
        {
            setupNewPiece('a', 1, new Tower(board, Color.White));
            setupNewPiece('b', 1, new Horse(board, Color.White));
            setupNewPiece('c', 1, new Bishop(board, Color.White));
            setupNewPiece('d', 1, new Queen(board, Color.White));
            setupNewPiece('e', 1, new King(board, Color.White, this));
            setupNewPiece('f', 1, new Bishop(board, Color.White));
            setupNewPiece('g', 1, new Horse(board, Color.White));
            setupNewPiece('h', 1, new Tower(board, Color.White));
            for (int i = 0; i < board.column; i++)
            {
                setupNewPiece((char)('a' + i), 2, new Pawn(board, Color.White));
            }

            setupNewPiece('a', 8, new Tower(board, Color.Black));
            setupNewPiece('b', 8, new Horse(board, Color.Black));
            setupNewPiece('c', 8, new Bishop(board, Color.Black));
            setupNewPiece('d', 8, new Queen(board, Color.Black));
            setupNewPiece('e', 8, new King(board, Color.Black, this));
            setupNewPiece('f', 8, new Bishop(board, Color.Black));
            setupNewPiece('g', 8, new Horse(board, Color.Black));
            setupNewPiece('h', 8, new Tower(board, Color.Black));
            for (int i = 0; i < board.column; i++)
            {
                setupNewPiece((char)('a' + i), 7, new Pawn(board, Color.Black));
            }
        }
    }
}
