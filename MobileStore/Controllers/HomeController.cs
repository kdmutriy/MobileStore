using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MobileStore.Models;
using MobileStore.Util;

namespace MobileStore.Controllers
{
    public class HomeController : Controller
    {
        MobileContext db;
        public HomeController(MobileContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.Phones.ToList());
        }

        [HttpGet]
        public IActionResult Buy(int id)
        {
            ViewBag.PhoneId = id;
            return View();
        }

        [HttpPost]
        public string Buy(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return "Спасибо, " + order.User + ", за покупку!";
        }
        #region свой класс результата действий HtmlResult
        public HtmlResult GetHtml()
        {
            return new HtmlResult("<h2>Привет ASP.NET Core</h2>");
        }
        #endregion
        #region Получение данных из контекста запроса
        //Request.Query
        //[HttpGet]
        //public string Square()
        //{
        //    string altitudeString = Request.Query.FirstOrDefault(p => p.Key == "altitude").Value;
        //    int altitude = Int32.Parse(altitudeString);

        //    string heightString = Request.Query.FirstOrDefault(p => p.Key == "height").Value;
        //    int height = Int32.Parse(heightString);

        //    double square = altitude * height / 2;
        //    return $"Площадь треугольника с основанием {altitude} и высотой {height} равна {square}";
        //}
        //Request.Form
        //[HttpPost]
        //public string Square()
        //{
        //    string altitudeString = Request.Form.FirstOrDefault(p => p.Key == "altitude").Value;
        //    int altitude = Int32.Parse(altitudeString);

        //    string heightString = Request.Form.FirstOrDefault(p => p.Key == "height").Value;
        //    int height = Int32.Parse(heightString);

        //    double square = altitude * height / 2;
        //    return $"Площадь треугольника с основанием {altitude} и высотой {height} равна {square}";
        //}
        #endregion
    }

    #region Сложные объекты в пераметрах
    //public class Geometry
    //{
    //    public int Altitude { get; set; }//osnovanie
    //    public int Height { get; set; } //visota
    //    public double GetSquare()
    //    {
    //        return Altitude * Height / 2;
    //    }
    //}
    #endregion
}
