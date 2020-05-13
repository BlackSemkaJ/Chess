using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ChessAPI.Models;

namespace ChessAPI.Controllers
{
    public class GamesController : ApiController
    {
        private ModelChessDB db = new ModelChessDB();

        // GET: api/Games
        public Game GetGames()
        {
            Logic logic = new Logic();
            Game game = logic.GetCurrentGame();
            return game;
        }

        public Game GetMove(int id, string move)
        {
            Logic logic = new Logic();
            Game game = logic.MakeMove(id, move);
            game.FEN = move;
            return game;
        }
        public Game GetGame(int id)
        {
            Logic logic = new Logic();
            Game game = logic.GetGame(id);
            return game;
        }

        //// PUT: api/Games/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutGame(int id, Game game)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != game.ID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(game).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!GameExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Games
        //[ResponseType(typeof(Game))]
        //public IHttpActionResult PostGame(Game game)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Games.Add(game);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = game.ID }, game);
        //}

        //// DELETE: api/Games/5
        //[ResponseType(typeof(Game))]
        //public IHttpActionResult DeleteGame(int id)
        //{
        //    Game game = db.Games.Find(id);
        //    if (game == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Games.Remove(game);
        //    db.SaveChanges();

        //    return Ok(game);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GameExists(int id)
        {
            return db.Games.Count(e => e.ID == id) > 0;
        }
    }
}