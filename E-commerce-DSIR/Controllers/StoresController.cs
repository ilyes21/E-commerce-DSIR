using E_commerce_DSIR.Models;
using E_commerce_DSIR.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_DSIR.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class StoresController : Controller
    {
        readonly IStoreRepository _storeRepository;
        public StoresController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }
        [AllowAnonymous]
        // GET: StoresController
        public ActionResult Index()
        {
            var stores = _storeRepository.GetAll();
            return View(stores);
        }

        // GET: StoresController/Details/5
        public ActionResult Details(int id)
        {
            var stores = _storeRepository.GetById(id);
            if (stores == null)
            {
                return NotFound();
            }
            return View(stores);
        }

        // GET: StoresController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Store S)
        {
            if (ModelState.IsValid)
            {
                _storeRepository.Add(S);
                TempData["SuccessMessage"] = "✅ Enregistrement avec succès !";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(S);
            }
        }

        // GET: StoresController/Edit/5
        public ActionResult Edit(int id)
        {
            var stores = _storeRepository.GetById(id);
            if (stores == null)
            {
                return NotFound();
            }
            return View(stores);
        }

        // POST: StoresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Store SU)
        {
            if (ModelState.IsValid)
            {
                _storeRepository.Update(SU);
                TempData["SuccessMessage"] = "✅ Modification avec succès !";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(SU);
            }
        }

        // GET: StoresController/Delete/5
        public ActionResult Delete(int id)
        {
            var stores = _storeRepository.GetById(id);
            if (stores == null)
            {
                return NotFound();
            }
            return View(stores);
        }

        // POST: StoresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var store = _storeRepository.GetById(id);
            if (store == null)
            {
                return NotFound();
            }
            _storeRepository.Delete(id);
            TempData["SuccessMessage"] = "✅ Suppression avec succès !";
            return RedirectToAction(nameof(Index));
        }
    }
}
