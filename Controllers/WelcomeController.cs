using Microsoft.AspNetCore.Mvc;

namespace WebCar.Controllers
{
    public class WelcomeController : Controller
	{
		public IActionResult WelcomeAuthUser()
		{
			return View();
		}
	}
}
