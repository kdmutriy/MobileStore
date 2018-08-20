using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MobileStore.Util
{
    public class HtmlResult : IActionResult
    {
        string htmlCode;
        public HtmlResult(string html)
        {
            htmlCode = html;
        }
        public async Task ExecuteResultAsync(ActionContext context)
        {
            string fullHtmlCode = "<!DOCTYPE html><html><head>";
            fullHtmlCode += "<title>Главная страница</title>";
            fullHtmlCode += "<meta charset=utf-8 />";
            fullHtmlCode += "</head> <body>";
            fullHtmlCode += htmlCode;
            fullHtmlCode += "</body></html>";
            await context.HttpContext.Response.WriteAsync(fullHtmlCode);
        }
    }
}
