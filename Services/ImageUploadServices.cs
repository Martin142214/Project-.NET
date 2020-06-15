using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.ViewModels;

namespace WebApplication1.Services
{
    public class ImageUploadServices
    {
        public string UploadImage(ProductCreateViewModel model)
        {
            string fileName = model.Photo.FileName;
            string targetFolder = Path.GetFullPath("~/images");
            string targetPath = Path.Combine(targetFolder, fileName);
            using (FileStream stream = new FileStream(targetPath, FileMode.Create))
            {
                model.Photo.CopyTo(stream);
            }
            return fileName;
        }
    }
}
