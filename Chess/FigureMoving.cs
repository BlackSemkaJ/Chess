using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    class FigureMoving //Движение фигуры
    {
        public Figure figure { get; private set;} //Какая именно фигура
        public Square from { get; private set; } // Где находится
        public Square to { get; private set; } // От куда идёт
        public Figure promotion { get; private set; } //Привращение в какую фигуру

        public FigureMoving (FigureOnSquare fs, Square to, Figure promotion = Figure.none)
        {
            this.figure = fs.figure;
            this.from = fs.square;
            this.to = to;
            this.promotion = promotion;
        }

        public FigureMoving (string move)//Pe2e4 Pe7e8Q //Парсер
        {                                //01234 012345
            this.figure = (Figure)move[0];
            this.from = new Square(move.Substring(1, 2));
            this.to = new Square(move.Substring(3, 2));
            this.promotion = (move.Length == 6) ? (Figure)move[5] : Figure.none;
        }
    }
}
