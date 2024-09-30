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

    public ChessMatch()
    {
      board = new ChessBoard(8, 8);
      turn = 1;
      currentPlayer = Color.White;
      over = false;
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
      if(!board.getPositionPiece(origin).canMoveTo(destination))
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