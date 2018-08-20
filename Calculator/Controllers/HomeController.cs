using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Calculator.Models;

namespace Calculator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About(int x, int y, string d)
        {
            string dk = "";
            //string sX = Request.Form.FirstOrDefault(p => p.Key == "x").Value;
            //int x = Int32.Parse(sX);

            //string sY = Request.Form.FirstOrDefault(p => p.Key == "y").Value;
            //int y = Int32.Parse(sY);

            //string sD = Request.Form.FirstOrDefault(p => p.Key == "d").Value;
            
            double rez = 0;
            
            switch (d)
            {
                case "+":rez = x + y; break;
                case "-": rez = x - y; break;
                case "*": rez = x * y; break;
                case "/": rez = x / y; break;
            }
            return Content( $"{rez}");
        }

       
    }
}
