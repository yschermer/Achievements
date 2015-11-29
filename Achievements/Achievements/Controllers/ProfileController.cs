using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Achievements.Models;

namespace Achievements.Controllers
{
    public class ProfileController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        [Authorize(Roles = "Admin")]
        public ActionResult AdminsView(string searchString, string gender, string city)
        {
            var profiles = from f in db.Users
                           select f;

            if (!String.IsNullOrEmpty(searchString))
            {
                profiles = profiles.Where(s => s.Name.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(gender))
            {
                GenderEnum newgender = (GenderEnum)Enum.Parse(typeof(GenderEnum), gender);

                profiles = profiles.Where(a => a.Gender == newgender);
            }
            if (!String.IsNullOrEmpty(city))
            {
                profiles = profiles.Where(a => a.City == city);
            }

            return PartialView("_AccountsView", profiles);
        }

        //ActionResult voor Teachers, om Students op te zoeken.
        [Authorize(Roles = "Teacher, Admin")]
        public ActionResult AccountsView(string searchString, string gender, string city)
        {
            var profiles = from f in db.Users 
                    where f.Job == "Student"
                    select f;

            if (!String.IsNullOrEmpty(searchString))
            {
                profiles = profiles.Where(s => s.Name.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(gender))
            {
                GenderEnum newgender = (GenderEnum)Enum.Parse(typeof(GenderEnum), gender);

                profiles = profiles.Where(a => a.Gender == newgender);
            }
            if (!String.IsNullOrEmpty(city))
            {
                profiles = profiles.Where(a => a.City == city);
            }

            return PartialView("_AccountsView", profiles);
        }

        // GET: Profile
        //[Authorize(Roles="Teacher, Admin")]
        public ActionResult Index()
        {
            //Add all student profiles



            return View();
        }
        
        [Authorize(Roles="Student")]
        public ActionResult StudentPanel()
        {

            return View();
        }

        [Authorize(Roles="Teacher")]
        public ActionResult TeacherPanel()
        {

            return View();
        }

        [Authorize(Roles="Admin")]
        public ActionResult AdminPanel()
        {

            return View();
        }

        // GET: Profile/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // GET: Profile/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Id,OVNumber,Name,Prefix,LastName,Gender,BirthDate,BirthCity,City,Job,StudyStartYear,Study,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {


            if (ModelState.IsValid)
            {
                db.Users.Add(applicationUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(applicationUser);
        }

        // GET: Profile/Edit/5

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: Profile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OVNumber,Name,Prefix,LastName,Gender,BirthDate,BirthCity,City,Job,StudyStartYear,Study,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationUser);
        }

        // GET: Profile/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: Profile/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationUser applicationUser = db.Users.Find(id);
            db.Users.Remove(applicationUser);
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
