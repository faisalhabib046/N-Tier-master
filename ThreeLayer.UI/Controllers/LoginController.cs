using System.Threading.Tasks;
using System.Web.Mvc;
using ThreeLayer.BAL;
using ThreeLayer.DAL.Entities;

namespace ThreeLayer.UI.Controllers
{
  public class LoginController : Controller
  {
    private readonly UserService _userService;

    public LoginController()
    {
      _userService = new UserService();
    }

    // GET: Login
    public ActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Index(User user)
    {
      if (ModelState.IsValid)
      {
        var authenticateUser = await _userService.AuthenticateUser(user.Username, user.Password);
        if (authenticateUser != null)
        {
          Session["User"] = user;
          return RedirectToAction("Index", "User");
        }

        return View("Error", authenticateUser);
      }

      ModelState.AddModelError("Invalid", "Some Error Occured!");

      return View(user);
    }
  }
}
