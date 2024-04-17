using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SorteoEstacionamiento.Server.CapaDataAccess.Controllers
{
    public class TbGanadoresController : Controller
    {
        // GET: TbGanadoresController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TbGanadoresController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TbGanadoresController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TbGanadoresController/Create
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

        // GET: TbGanadoresController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TbGanadoresController/Edit/5
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

        // GET: TbGanadoresController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TbGanadoresController/Delete/5
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
