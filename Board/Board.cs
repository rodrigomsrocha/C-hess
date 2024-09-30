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

    public void setPositionPiece(Piece piece, Position position)
    {
      pieces[position.line, position.column] = piece;
      piece.position = position;
    }
  }
}