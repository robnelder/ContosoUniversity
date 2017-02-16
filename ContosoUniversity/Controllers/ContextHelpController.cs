using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContosoUniversity.DAL;
using ContosoUniversity.Models;
using ContosoUniversity.ViewModels;

namespace ContosoUniversity.Controllers
{
    public class ContextHelpController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: ContextHelp
        public ActionResult Index()
        {
            var orderedContextHelps = db.ContextHelps
                                        .OrderBy(ch => ch.Controller)
                                        .ThenBy(ch => ch.Action)
                                        .ThenBy(ch => ch.Property);
            return View(GetViewModel(orderedContextHelps));
        }

        // GET: ContextHelp/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContextHelp contextHelp = db.ContextHelps.Find(id);
            if (contextHelp == null)
            {
                return HttpNotFound();
            }
            return View(GetViewModel(contextHelp));
        }

        // GET: ContextHelp/Create
        public ActionResult Create(string cont = null, string act = null, string prop = null)
        {
            var contextHelp = new ContextHelp();
            contextHelp.Controller = cont;
            contextHelp.Action = act;
            contextHelp.Property = prop;
            return View(GetViewModel(contextHelp));
        }

        // POST: ContextHelp/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContextHelpID,Controller,Action,Property,ToolTip,HelpText")] ContextHelp contextHelp)
        {
            if (ModelState.IsValid)
            {
                db.ContextHelps.Add(contextHelp);
                db.SaveChanges();
                return RedirectToAction("Index", contextHelp.Controller);
            }

            return View(GetViewModel(contextHelp));
        }

        // GET: ContextHelp/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContextHelp contextHelp = db.ContextHelps.Find(id);
            if (contextHelp == null)
            {
                return HttpNotFound();
            }
            return View(GetViewModel(contextHelp));
        }

        // POST: ContextHelp/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContextHelpID,Controller,Action,Property,ToolTip,HelpText")] ContextHelp contextHelp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contextHelp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", contextHelp.Controller);
            }
            return View(GetViewModel(contextHelp));
        }

        // GET: ContextHelp/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContextHelp contextHelp = db.ContextHelps.Find(id);
            if (contextHelp == null)
            {
                return HttpNotFound();
            }
            return View(GetViewModel(contextHelp));
        }

        // POST: ContextHelp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContextHelp contextHelp = db.ContextHelps.Find(id);
            db.ContextHelps.Remove(contextHelp);
            db.SaveChanges();
            return RedirectToAction("Index", contextHelp.Controller);
        }

        private ContextHelpWithHelp GetViewModel(IEnumerable<ContextHelp> contextHelpList)
        {
            var viewModel = GetViewModel();
            viewModel.ContextHelpList = contextHelpList.ToList();
            return viewModel;
        }
        private ContextHelpWithHelp GetViewModel(ContextHelp contextHelp)
        {
            var viewModel = GetViewModel();
            viewModel.ContextHelp = contextHelp;
            return viewModel;
        }
        private ContextHelpWithHelp GetViewModel()
        {
            var viewModel = new ContextHelpWithHelp();
            viewModel.ContextHelps = db.ContextHelps.Where(c => c.Controller == nameof(ContextHelp)).ToList();
            return viewModel;
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
