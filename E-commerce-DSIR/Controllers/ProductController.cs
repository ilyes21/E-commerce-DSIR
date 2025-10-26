using E_commerce_DSIR.Models;
using E_commerce_DSIR.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace E_commerce_DSIR.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class ProductController : Controller
    {
        readonly IProductRepository _productRepository;
        readonly ICategorieRepository _CategRepository;
        readonly IHostingEnvironment _host;
        public ProductController(IProductRepository productRepository, ICategorieRepository categRepository, IHostingEnvironment host)
        {
            _productRepository = productRepository;
            _CategRepository = categRepository;
            _host = host;
        }
        public void createSelectList(int selectId = 1)
        {
            ViewBag.CategoryList = new SelectList(_CategRepository.GetAll(), "CategoryId", "CategoryName");
            //var categories = _CategRepository.GetAll();
            //SelectList listcategories = new SelectList(categories, "Id", "Name", selectId);
            //ViewBag.CategotyList = listcategories;
        }
        // GET: ProductController
        [AllowAnonymous]
        public ActionResult Index()
        {
            var products = _productRepository.GetAll();
            return View(products);
        }
        // GET: ProductController
        public ActionResult Search(String val)
        {
            var products = _productRepository.FindByName(val);
            return View("Index", products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var Product = _productRepository.GetById(id);
            if (Product == null) 
            {
                return NotFound();
            }
            return View(Product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            createSelectList();
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            

            if (ModelState.IsValid)
            {
                string fileName = string.Empty;
                if (product.clientFile != null)
                {
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + product.clientFile.FileName;
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        product.clientFile.CopyTo(fileStream);
                    }
                    product.Image = uniqueFileName;
                }
                else
                {
                    product.Image = "noimage.png";
                }

                _productRepository.Add(product);
                TempData["SuccessMessage"] = "✅ Enregistrement avec succès !";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                createSelectList();
                return View(product);
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            createSelectList();
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product)
        {
            if (ModelState.IsValid)
            {
                string fileName = string.Empty;
                if (product.clientFile != null)
                {
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + product.clientFile.FileName;
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        product.clientFile.CopyTo(fileStream);
                    }
                    product.Image = uniqueFileName;
                }
                else
                {
                    product.Image = "noimage.png";
                }
                _productRepository.Update(product);
                TempData["SuccessMessage"] = "✅ Modification avec succès !";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                createSelectList();
                return View(product);
            }


        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var prd = _productRepository.GetById(id);
            if (prd == null)
            {
                return NotFound();
            }
            return View(prd);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product produit)
        {
            var pr = _productRepository.GetById(id);
            if (pr == null)
            {
                return NotFound();
            }
            _productRepository.Delete(id);
            TempData["SuccessMessage"] = "✅ Suppression avec succès !";
            return RedirectToAction(nameof(Index));
        }
    }
}
