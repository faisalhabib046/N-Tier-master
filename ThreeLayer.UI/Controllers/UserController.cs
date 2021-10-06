using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using ThreeLayer.BAL;
using ThreeLayer.DAL.Entities;

namespace ThreeLayer.UI.Controllers
{
  public class UserController : Controller
  {
    private readonly UserService _userService;

    public UserController()
    {
      _userService = new UserService();
    }

    // GET: User
    public async Task<ActionResult> Index()
    {
      var isUserLoggedIn = Session["User"];
      if (isUserLoggedIn == null)
      {
        return RedirectToAction("Index", "Login");
      }

      var users = await _userService.ListUsers();

      return View(users);
    }

    public async Task<ActionResult> Delete(int id)
    {
      var isDeleted = await _userService.DeleteUser(id);
      if (isDeleted)
      {
        return RedirectToAction("Index", "User");
      }

      return View("Error");
    }

    public async Task<ActionResult> Edit(int id)
    {
      var user = await _userService.GetUserById(id);
      return View(user);
    }

    [HttpPost]
    public async Task<ActionResult> Edit(User user)
    {
      if (ModelState.IsValid)
      {
        var isUpdated = await _userService.UpdateUser(user);
        return RedirectToAction("Index", "User");
      }
      
      return View(user);
    }
  }
}
