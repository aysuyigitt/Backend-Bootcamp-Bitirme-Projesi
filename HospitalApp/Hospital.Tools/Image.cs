using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Hospital.Tools
{
    public class Image
    {
        IWebHostEnvironment _env;

        public Image(IWebHostEnvironment env)
        {
            _env = env;
        }
        public string ImageUpload(IFormFile file)
        {
            string fileName = null;
            if(file!=null)
            {
                string fileFrom = Path.Combine(_env.WebRootPath, "Images");
                fileName = Guid.NewGuid() + "-" + file.FileName;
                string filePath = Path.Combine(fileFrom, fileName);
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyToAsync(fs);
                }

            }
            return fileName;
        }
    }
}
