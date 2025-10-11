using E_commerce_DSIR.Models;
using E_commerce_DSIR.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_DSIR.Controllers
{
    public class CategoryController : Controller
    {
        readonly ICategorieRepository _categorieRepository;
        public CategoryController(ICategorieRepository categorieRepository)
        {
            _categorieRepository = categorieRepository;
        }
        // GET: CategoryController
        public ActionResult Index()
        {
            var categories = _categorieRepository.GetAll();
            return View(categories);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var category = _categorieRepository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category c)
        {
            if (ModelState.IsValid)
            {
                _categorieRepository.Add(c);
                TempData["SuccessMessage"] = "✅ Enregistrement avec succès !";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(c);
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var category = _categorieRepository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category Ucategory)
        {
            if (ModelState.IsValid)
            {
                _categorieRepository.Update(Ucategory);
                TempData["SuccessMessage"] = "✅ Modification avec succès !";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(Ucategory);
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var category = _categorieRepository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Category Scategory)
        {
            var category = _categorieRepository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            _categorieRepository.Delete(id);
            TempData["SuccessMessage"] = "✅ Suppression avec succès !";
            return RedirectToAction(nameof(Index));

        }
    }
}
