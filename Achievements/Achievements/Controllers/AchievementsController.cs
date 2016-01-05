using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Achievements.Models;
using Microsoft.AspNet.Identity;


namespace Achievements.Controllers
{
    public class AchievementsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Achievements
        [Authorize(Roles= "Admin, Teacher")]
        public ActionResult Index(string searchString, string status)
        {
            var Achievement = from f in db.Achievements
                           select f;


            if (!String.IsNullOrEmpty(searchString))
            {
                Achievement = Achievement.Where(s => s.Name.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(status))
            {
                Achievements.Models.Achievement.statusEnum newstatus = (Achievements.Models.Achievement.statusEnum)Enum.Parse(typeof(GenderEnum), status);

                Achievement = Achievement.Where(a => a.AchievementStatus == newstatus);
            }


            return View(Achievement);
        }

        // GET: Achievements/Details/5

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Achievement achievement = db.Achievements.Find(id);
            if (achievement == null)
            {
                return HttpNotFound();
            }
            return View(achievement);
        }

        // GET: Achievements/Create
        [Authorize(Roles = "Admin, Teacher")]
        public ActionResult Create()
        {
            
            return View();
        }
        
        // POST: Achievements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Teacher")]
        public ActionResult Create([Bind(Include = "AchievementId,Userid,Name,AchievementName,AchievementStatus,AchievementDescription")] Achievement achievement)
        {
            
            if (ModelState.IsValid)
            {
                //Haalt het id op van de student via de URL
                var url = Url.RequestContext.RouteData.Values["id"];

                //Voegt toe in de UserId
                achievement.UserId = (string)url;
                db.Achievements.Add(achievement);
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(achievement);
        }

        // GET: Achievements/Edit/5
        [Authorize(Roles = "Admin, Teacher")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Achievement achievement = db.Achievements.Find(id);
            if (achievement == null)
            {
                return HttpNotFound();
            }
            return View(achievement);
        }

        // POST: Achievements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Teacher")]
        public ActionResult Edit([Bind(Include = "AchievementId,AchievementName,AchievementStatus,AchievementDescription")] Achievement achievement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(achievement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(achievement);
        }

        // GET: Achievements/Delete/5
        [Authorize(Roles = "Admin, Teacher")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Achievement achievement = db.Achievements.Find(id);
            if (achievement == null)
            {
                return HttpNotFound();
            }
            return View(achievement);
        }

        // POST: Achievements/Delete/5
        [Authorize(Roles = "Admin, Teacher")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Achievement achievement = db.Achievements.Find(id);
            db.Achievements.Remove(achievement);
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
