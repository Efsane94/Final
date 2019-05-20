using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Final_Code_Project.Extensions
{
    public static class FileExtension
    {
        public static bool IsImage(this HttpPostedFileBase file)
        {
            return file.ContentType == "image/jpg" ||
                   file.ContentType == "image/jpeg" ||
                   file.ContentType == "image/png" ||
                   file.ContentType == "image.gif";
        }

        public static string SaveImage(this HttpPostedFileBase image, string subfolder, string root)
        {
            string newFilename = subfolder + "/" + Guid.NewGuid().ToString() + Path.GetFileName(image.FileName);


            string fullPath = Path.Combine(HttpContext.Current.Server.MapPath(root), newFilename);

            image.SaveAs(fullPath);

            return newFilename;
        }
    }
}