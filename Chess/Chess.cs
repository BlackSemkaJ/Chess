using System;

namespace Chess
{
    public class Chess
    {
        public string fen { get; private set; }
        Board board;

        public Chess (string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1") //Начальная позиция шахматной партии
   
        {
            this.fen = fen;
            board = new Board(fen);
        }

        Chess (Board board)
        {
            this.board = board;
            this.fen = board.fen;
        }

        public Chess Move (string move) // Метод хода
        {
            FigureMoving fm = new FigureMoving(move);
            Board nextBoard = board.Move(fm);
            Chess nextChess = new Chess(nextBoard);
            return nextChess;
        }

        public char GetFigureAt (int x, int y) // Метод который знает где какая фигура находится
        {
            Square square = new Square(x, y);
            Figure f = board.GetFigureAt(square);
            return f == Figure.none ? '.' : (char)f;
        }

    }
}
