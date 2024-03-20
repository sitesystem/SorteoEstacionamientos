using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SorteoEstacionamiento.Server.CapaDataAccess.Controllers
{
    public class TbParticipantesController : Controller
    {
        // GET: TbParticipantesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TbParticipantesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TbParticipantesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TbParticipantesController/Create
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

        // GET: TbParticipantesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TbParticipantesController/Edit/5
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

        // GET: TbParticipantesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TbParticipantesController/Delete/5
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
