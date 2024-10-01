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
            if (!board.getPositionPiece(origin).canMoveTo(destination))
            {
                throw new BoardException("You can not carry out this movement");
            }
        }

        public void executePlay(Position origin, Position destination)
        {
            executeMovement(origin, destination);
            turn++;
            changePlayer();
        }

        public void executeMovement(Position origin, Position destination)
        {
            Piece piece = board.removePiece(origin);
            piece.incrementMovements();
            Piece capturedPiece = board.removePiece(destination);
            board.setPositionPiece(piece, destination);
            if (capturedPiece != null)
            {
                captured.Add(capturedPiece);
            }
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

        public void setupNewPiece(char column, int line, Piece piece)
        {
            board.setPositionPiece(piece, new PositionChess(column, line).toPosition());
            pieces.Add(piece);
        }

        private void setupPieces()
        {
            setupNewPiece('c', 1, new Tower(board, Color.White));
            setupNewPiece('d', 1, new King(board, Color.White));
            setupNewPiece('e', 1, new Tower(board, Color.White));
            setupNewPiece('c', 2, new Tower(board, Color.White));
            setupNewPiece('d', 2, new Tower(board, Color.White));
            setupNewPiece('e', 2, new Tower(board, Color.White));

            setupNewPiece('c', 8, new Tower(board, Color.Black));
            setupNewPiece('d', 8, new King(board, Color.Black));
            setupNewPiece('e', 8, new Tower(board, Color.Black));
            setupNewPiece('c', 7, new Tower(board, Color.Black));
            setupNewPiece('d', 7, new Tower(board, Color.Black));
            setupNewPiece('e', 7, new Tower(board, Color.Black));
        }
    }
}
