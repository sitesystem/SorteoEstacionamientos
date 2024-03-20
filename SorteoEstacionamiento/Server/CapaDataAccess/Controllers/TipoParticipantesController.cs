using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SorteoEstacionamiento.Server.CapaDataAccess.Controllers
{
    public class TipoParticipantesController : Controller
    {
        // GET: TipoParticipantesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TipoParticipantesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoParticipantesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoParticipantesController/Create
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

        // GET: TipoParticipantesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoParticipantesController/Edit/5
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

        // GET: TipoParticipantesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipoParticipantesController/Delete/5
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
