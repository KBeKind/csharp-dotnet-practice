using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CustomerController : Controller
    {
        public static List<Customer> customers = new List<Customer>()
        {
            new Customer() { Id = 1, Name="Duder", Amount= 12000}
            , new Customer() { Id = 2, Name="Dudette", Amount= 12000}
        };

        public IActionResult Index()
        {
            ViewBag.Message = "Customer Management System";
            ViewBag.CustomerCount = customers.Count();
            ViewBag.Customers = customers;
            return View();
        }


        public IActionResult Details()
        {

            ViewData["Message"] = "Customer Details Message";
            ViewData["CustomerCount"] = customers.Count();
            ViewData["CustomerList"] = customers;

            ViewBag.Customers = customers;


            return View();
        }

        public IActionResult Message()
        {
            return View();
        }



        public IActionResult Method()
        {
            TempData["Message"] = "Method 1 Message";
            //TempData["CustomerCount"] = customers.Count();
            //TempData["CustomerList"] = customers;


            return View();
        }


        public IActionResult MethodTwo()
        {

            if (TempData["Message"] == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Message"] = TempData["Message"];
             
                //TempData.Clear(); // clear the tempdata after use. 
                //                  // this is to prevent the same data from being used again. 
             
                return View();
            }
          
        }


    }
}
