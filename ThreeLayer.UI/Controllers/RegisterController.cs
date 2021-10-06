using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ThreeLayer.BAL;
using ThreeLayer.DAL.Entities;

namespace ThreeLayer.UI.Controllers
{
  public class RegisterController : Controller
  {
    private readonly UserService _userService;

    public RegisterController()
    {
      _userService = new UserService();
    }

    // GET: Register
    public ActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Index(User user)
    {
      if (ModelState.IsValid)
      {
        var isUserCreated = await _userService.AddUser(user);
        if (isUserCreated)
        {
          return RedirectToAction("Index", "User");
        }

        View("Error", user);
      }

      ModelState.AddModelError("Invalid", "User creation failed.");

      return View(user);
    }
  }
}
