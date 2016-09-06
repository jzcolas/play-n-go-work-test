using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GameStore.Models;

namespace GameStore.Controllers
{
    public class GamesController : Controller
    {
        private GameDBContext db = new GameDBContext();

        // GET: /Games/
        public ActionResult Index(string gameRating, string searchString)
        {
            var RatingList = new List<string>();

            var RatingQuery = from d in db.Games
                              orderby d.Rating
                              select d.Rating;

            RatingList.AddRange(RatingQuery.Distinct());

            ViewBag.Message = "Check our list.";
            ViewBag.gameRating = new SelectList(RatingList);

            var games = from g in db.Games
                        select g;

            if (!String.IsNullOrEmpty(searchString))
            {
                games = games.Where(s => s.Title.Contains(searchString)).OrderByDescending(s => s.ReleaseDate);
            }
            else
            {
                games = games.OrderByDescending(s => s.ReleaseDate);
            }

            if (!string.IsNullOrEmpty(gameRating))
            {
                games = games.Where(x => x.Rating == gameRating).OrderByDescending(x => x.ReleaseDate);
            }

            return View(games);
        }

        // GET: /Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Game game = db.Games.Find(id);

            if (game == null)
            {
                return HttpNotFound();
            }

            ViewBag.Message = game.Title;

            return View(game);
        }

        // GET: /Games/Create
        public ActionResult Create()
        {
            ViewBag.Message = "Add data to your new game.";

            return View();
        }

        // POST: /Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,ReleaseDate,Rating,Platform,Price")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(game);
        }

        // GET: /Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Game game = db.Games.Find(id);

            if (game == null)
            {
                return HttpNotFound();
            }

            ViewBag.Message = "This will change the data for " + game.Title + ".";

            return View(game);
        }

        // POST: /Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ReleaseDate,Rating,Platform,Price")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(game);
        }

        // GET: /Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }

            ViewBag.Message = "Are you sure you want to delete "  + game.Title + "?";

            return View(game);
        }

        // POST: /Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
