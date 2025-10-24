using AutoMapper;
using E_commerce_DSIR.ViewModels.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_DSIR.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _roleMapper;
        public RoleController(RoleManager<IdentityRole> roleManager, IMapper roleMapper)
        {
            this._roleManager = roleManager;
            this._roleMapper = roleMapper;
        }
        [HttpGet]

        public ActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            var result = _roleMapper.Map<List<GetRolesViewModel>>(roles);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(GetRolesViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };
                IdentityResult result = await _roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);

        }
    }
}
