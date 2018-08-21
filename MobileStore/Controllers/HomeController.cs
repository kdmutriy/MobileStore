using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MobileStore.Models;
using MobileStore.Util;

namespace MobileStore.Controllers
{
    public class HomeController : Controller
    {
        MobileContext db;
        private readonly IHostingEnvironment _appEnvironment;
        public HomeController(MobileContext context, IHostingEnvironment appEnvironment)
        {
            db = context;
            _appEnvironment = appEnvironment;
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
        #region Отправка файлов
        
        public IActionResult GetFile()
        {
            // Путь к файлу
            string file_path = Path.Combine(_appEnvironment.ContentRootPath, "Files/book.pdf");
            // Тип файла - content-type
            string file_type = "application/pdf";
            // Имя файла - необязательно
            string file_name = "book.pdf";
            return PhysicalFile(file_path, file_type, file_name);
        }
        // Отправка массива байтов
        public FileResult GetBytes()
        {
            string path = Path.Combine(_appEnvironment.ContentRootPath, "Files/book.pdf");

            byte[] mas = System.IO.File.ReadAllBytes(path);
            string file_type = "application/pdf";
            string file_name = "book2.pdf";
            return File(mas, file_type, file_name);
        }
        // Отправка потока
        public FileResult GetStream()
        {
            string path = Path.Combine(_appEnvironment.ContentRootPath, "Files/book.pdf");
            FileStream fs = new FileStream(path, FileMode.Open);
            string file_type = "application/pdf";
            string file_name = "book3.pdf";
            return File(fs, file_type, file_name);
        }
        public VirtualFileResult GetVirtualFile()
        {
            var filepath = Path.Combine("~/Files", "hello.doc");
            return File(filepath, "application/octet-stream", "hello.doc");
        }
        #endregion
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
