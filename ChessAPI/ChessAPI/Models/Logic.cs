using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Web;


namespace ChessAPI.Models
{
    public class Logic
    {
        private ModelChessDB db;
        public Logic ()
        {
            db = new ModelChessDB();
        }
        public Game GetCurrentGame()
        {
            Game game = db
                .Games
                .Where(g => g.STATUS == "play")
                .OrderBy(g => g.ID)
                .FirstOrDefault();
            if (game == null)
                game = CreateNewGame();
            return game;
        }

        public Game MakeMove (int id, string move)
        {
            Game game = GetGame(id);
            if (game == null)
                return game;
            Chess.Chess chess = new Chess.Chess(game.FEN);
            Chess.Chess chessNext = chess.Move(move);
            
            if (chessNext.fen == game.FEN)
                return game;

            game.FEN = chessNext.fen;
            if (chessNext.IsCheck || chess.IsCheckAfterMove)
                game.STATUS = "done";
            db.Entry(game).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return game;
        }
        public Game GetGame(int id)
        {
            return db.Games.Find(id);
        }

        // done play
        private Game CreateNewGame()
        {
            Game game = new Game();
            Chess.Chess chess = new Chess.Chess(); // подключение ChessRules (добавить в референс)
            game.FEN = chess.fen;
          //  game.FEN = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1"; //начальная позиция
            game.STATUS = "play";
            db.Games.Add(game);
            db.SaveChanges();
            return game;
        }
    }
   
}