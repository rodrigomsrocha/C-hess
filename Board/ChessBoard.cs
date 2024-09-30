namespace Board
{
  class ChessBoard
  {
    public int line { get; set; }
    public int column { get; set; }
    private Piece[,] pieces { get; set; }

    public ChessBoard(int line, int column)
    {
      this.line = line;
      this.column = column;
      this.pieces = new Piece[line, column];
    }

    public Piece getPositionPiece(int line, int column)
    {
      return pieces[line, column];
    }
    public Piece getPositionPiece(Position position)
    {
      return pieces[position.line, position.column];
    }

    public void setPositionPiece(Piece piece, Position position)
    {
      if (pieceExists(position))
      {
        throw new BoardException("There is already a piece in that position");
      }
      pieces[position.line, position.column] = piece;
      piece.position = position;
    }

    public Piece removePiece(Position position)
    {
      if (getPositionPiece(position) == null) return null;
      Piece aux = getPositionPiece(position);
      aux.position = null;
      pieces[position.line, position.column] = null;

      return aux;
    }

    public bool pieceExists(Position position)
    {
      validatePosition(position);
      return getPositionPiece(position) != null;
    }

    public bool isPostionValid(Position position)
    {
      if (position.line < 0 || position.line >= line || position.column < 0 || position.column >= column)
      {
        return false;
      }

      return true;
    }

    public void validatePosition(Position position)
    {
      if (!isPostionValid(position))
      {
        throw new BoardException("Invalid position");
      }
    }
  }
}