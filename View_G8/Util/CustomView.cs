using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace View_G8.Util
{
    public class CustomView:IView
    {
        public string Path { get; set; }
        public CustomView(string viewPath)
        {
            Path = viewPath;
        }
        public async Task RenderAsync(ViewContext context)
        {
            string content = String.Empty;
            using (FileStream viewStream = new FileStream(Path, FileMode.Open))
            {
                using (StreamReader viewReader = new StreamReader(viewStream))
                {
                    content = viewReader.ReadToEnd();
                }
            }
            await context.Writer.WriteAsync(content);
        }
    }
}
