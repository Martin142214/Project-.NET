using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.ViewModels;

namespace WebApplication1.Services
{
    public class ImageUploadServices
    {
        public string UploadImage(ProductCreateViewModel model)
        {
            string fileName = model.Photo.FileName;

            var name = fileName.Remove(0, 38);

            string targetPath = Path.Combine("/images/", name);
            using (FileStream stream = new FileStream(targetPath, FileMode.Create))
            {
                model.Photo.CopyTo(stream);
            }
            return name;
        }
    }
}
