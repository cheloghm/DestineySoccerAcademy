﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DestineySoccerAcademy.Models;

namespace DestineySoccerAcademy.Controllers.Activity
{
    //[Authorize(Roles = "CanManagePlayersStaffACtivitiesBlogs, CanManagePlayersACtivitiesBlogs")]
    public class ActivitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Activities
        public ActionResult Index()
        {
            if (User.IsInRole("CanManagePlayersStaffACtivitiesBlogs") || User.IsInRole("CanManagePlayersACtivitiesBlogs"))
                return View(db.Activities.ToList());
            else
                return View("Blog", db.Activities.ToList());
            
        }

        // GET: Activities/Details/5
        [Authorize(Roles = "CanManagePlayersStaffACtivitiesBlogs, CanManagePlayersACtivitiesBlogs")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activities activities = db.Activities.Find(id);
            if (activities == null)
            {
                return HttpNotFound();
            }
            return View(activities);
        }

        // GET: Activities/Create
        [Authorize(Roles = "CanManagePlayersStaffACtivitiesBlogs, CanManagePlayersACtivitiesBlogs")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Activities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "CanManagePlayersStaffACtivitiesBlogs, CanManagePlayersACtivitiesBlogs")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Content,CreateTime")] Activities activities)
        {
            if (ModelState.IsValid)
            {
                db.Activities.Add(activities);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(activities);
        }

        // GET: Activities/Edit/5
        [Authorize(Roles = "CanManagePlayersStaffACtivitiesBlogs, CanManagePlayersACtivitiesBlogs")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activities activities = db.Activities.Find(id);
            if (activities == null)
            {
                return HttpNotFound();
            }
            return View(activities);
        }

        // POST: Activities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "CanManagePlayersStaffACtivitiesBlogs, CanManagePlayersACtivitiesBlogs")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Content,CreateTime")] Activities activities)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activities).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(activities);
        }

        // GET: Activities/Delete/5
        [Authorize(Roles = "CanManagePlayersStaffACtivitiesBlogs, CanManagePlayersACtivitiesBlogs")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activities activities = db.Activities.Find(id);
            if (activities == null)
            {
                return HttpNotFound();
            }
            return View(activities);
        }

        // POST: Activities/Delete/5
        [Authorize(Roles = "CanManagePlayersStaffACtivitiesBlogs, CanManagePlayersACtivitiesBlogs")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Activities activities = db.Activities.Find(id);
            db.Activities.Remove(activities);
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
