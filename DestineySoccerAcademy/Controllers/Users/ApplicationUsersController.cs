using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using DestineySoccerAcademy.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace DestineySoccerAcademy.Controllers.Users
{
    //[Authorize(Roles = RoleName.CMSP), Authorize(Roles = RoleName.CMP)]
    public class ApplicationUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //public ActionResult GetPlayers()
        //{
        //    //var usersWithRoles = (from user in db.Users
        //    //                      from userRole in user.Roles
        //    //                      join role in db.Roles on userRole.RoleId equals
        //    //                      "24d83418-4f4e-4a25-bc8a-99dd1f9f9389"
        //    //                      select new ApplicationUser()
        //    //                      {
        //    //                          RoleName = role.Name
        //    //                      });

        //    //return View("List", db.Roles.Where(r => r.Name == "Players").ToList());
        //    //return View("List", db.Users.Where(r => r.Roles.Where(n => n.RoleId.All(r.Roles.id == "24d83418-4f4e-4a25-bc8a-99dd1f9f9389")));
        //}

        // GET: ApplicationUsers
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CMSP))
                return View("List", db.Users.ToList());
            else if (User.IsInRole(RoleName.CMP))
            {
                return View("ReadOnlyList", db.Users.ToList());
                //GetPlayers();
            }
            else
                ViewBag.Message = string.Format("You don't have the Admin previlage for this");
                return View();
        }

        // GET: ApplicationUsers/Details/5
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

        // GET: ApplicationUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicationUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,MobilePhone,Address,State,Country," +
            "Birthdate,Create_date,ProfilePhoto,Email,EmailConfirmed,PasswordHash," +
            "SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled," +
            "LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(applicationUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(applicationUser);
        }

        // GET: ApplicationUsers/Edit/5
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

        // POST: ApplicationUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,MobilePhone,Address,State,Country," +
            "Birthdate,Create_date,ProfilePhoto,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber," +
            "PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Delete/5
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

        // POST: ApplicationUsers/Delete/5
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
