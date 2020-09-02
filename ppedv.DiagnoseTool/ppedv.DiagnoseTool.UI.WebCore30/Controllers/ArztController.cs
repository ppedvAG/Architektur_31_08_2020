using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ppedv.DiagnoseTool.Logik;
using ppedv.DiagnoseTool.Model;

namespace ppedv.DiagnoseTool.UI.WebCore30.Controllers
{
    public class ArztController : Controller
    {
        Core core = new Core(new Data.Ef.EfRepository());

        // GET: ArztController
        public ActionResult Index()
        {
            var arztListe = core.Repository.Query<Arzt>().OrderBy(x => x.Name).ToList();

            return View(arztListe);
        }

        // GET: ArztController/Details/5
        public ActionResult Details(int id)
        {
            return View(core.Repository.Query<Arzt>().FirstOrDefault(x => x.Id == id));
        }

        // GET: ArztController/Create
        public ActionResult Create()
        {
            return View(new Arzt() { Name = "NEU" });
        }

        // POST: ArztController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Arzt arzt)
        {
            try
            {
                core.Repository.Add(arzt);
                core.Repository.SaveAll();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArztController/Edit/5
        public ActionResult Edit(int id)
        {
            var loaded = core.Repository.Query<Arzt>().FirstOrDefault(x => x.Id == id);
            return View(loaded);
        }

        // POST: ArztController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Arzt arzt)
        {
            try
            {
                core.Repository.Update(arzt);
                core.Repository.SaveAll();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArztController/Delete/5
        public ActionResult Delete(int id)
        {
            var loaded = core.Repository.Query<Arzt>().FirstOrDefault(x => x.Id == id);
            return View(loaded);
        }

        // POST: ArztController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var loaded = core.Repository.Query<Arzt>().FirstOrDefault(x => x.Id == id);
                core.Repository.Delete(loaded);
                core.Repository.SaveAll();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
