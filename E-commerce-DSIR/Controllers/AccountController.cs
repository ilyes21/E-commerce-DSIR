using Microsoft.AspNetCore.Mvc;

namespace E_commerce_DSIR.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
