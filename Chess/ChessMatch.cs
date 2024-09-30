using Board.Enums;
using Board;

namespace Chess
{
  class ChessMatch
  {
    public ChessBoard board { get; set; }
    private int turn;
    private Color currentPlayer;
    public bool over { get; private set; }

    public ChessMatch()
    {
      board = new ChessBoard(8, 8);
      turn = 1;
      currentPlayer = Color.White;
      over = false;
      setupPieces();
    }

    public void executeMovement(Position origin, Position destination)
    {
      Piece piece = board.removePiece(origin);
      piece.incrementMovements();
      Piece capturedPiece = board.removePiece(destination);
      board.setPositionPiece(piece, destination);
    }

    private void setupPieces()
    {
      board.setPositionPiece(new Tower(board, Color.White), new PositionChess('c', 1).toPosition());
      board.setPositionPiece(new King(board, Color.White), new PositionChess('d', 1).toPosition());
      board.setPositionPiece(new Tower(board, Color.White), new PositionChess('e', 1).toPosition());
      board.setPositionPiece(new Tower(board, Color.White), new PositionChess('c', 2).toPosition());
      board.setPositionPiece(new Tower(board, Color.White), new PositionChess('d', 2).toPosition());
      board.setPositionPiece(new Tower(board, Color.White), new PositionChess('e', 2).toPosition());

      board.setPositionPiece(new Tower(board, Color.Black), new PositionChess('c', 8).toPosition());
      board.setPositionPiece(new King(board, Color.Black), new PositionChess('d', 8).toPosition());
      board.setPositionPiece(new Tower(board, Color.Black), new PositionChess('e', 8).toPosition());
      board.setPositionPiece(new Tower(board, Color.Black), new PositionChess('c', 7).toPosition());
      board.setPositionPiece(new Tower(board, Color.Black), new PositionChess('d', 7).toPosition());
      board.setPositionPiece(new Tower(board, Color.Black), new PositionChess('e', 7).toPosition());
    }
  }
}