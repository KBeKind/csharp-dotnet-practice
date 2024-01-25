using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult WeaklyTypedLogin()
		{
			return View();
		}

		[HttpPost]
		public IActionResult LoginPost(String username, String password)
		{

			ViewBag.Username = username;

			return View();
		}


		public IActionResult StronglyTypedLogin()
		{
			return View();
		}


		[HttpPost]
		public IActionResult LoginSuccess(LoginViewModel login)
		{
			if(login.Username != null && login.Password != null)
			{
				if(login.Username.Equals("admin") && login.Password.Equals("admin"))
				{
					ViewBag.Message = "Login Successful";
					return View();
				}
			}
			ViewBag.Message = "Login Failed";

			return View();
		}


		public IActionResult UserDetail()
		{

			var user = new LoginViewModel()
			{
				Username = "Duder",
				Password = "11111"
			};
			return View(user);
		}

		public IActionResult UserList()
		{

			var users = new List<LoginViewModel>()
			{


				new LoginViewModel()
				{
					Username = "Duder",
					Password = "11111"
				},
				new LoginViewModel()
				{
					Username = "Duder2",
					Password = "2222"
				},

			};

			return View(users);

		}


		public IActionResult GetAccount()
		{
			return View();
		}


		[HttpPost]
		public IActionResult PostAccount(Account account)
		{
			if (ModelState.IsValid)
			{
				return View("Success");
			}

			return RedirectToAction("GetAccount");
		}

	}

}

