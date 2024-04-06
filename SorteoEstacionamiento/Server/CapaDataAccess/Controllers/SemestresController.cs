using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SorteoEstacionamiento.Server.CapaDataAccess.Controllers
{
    public class SemestresController : Controller
    {
        // GET: SemestresController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SemestresController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SemestresController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SemestresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SemestresController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SemestresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SemestresController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SemestresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
