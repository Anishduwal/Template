using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace Template.Services
{
    public class ImageResizeHelper
    {
        public static void ResizeImage(HttpPostedFileBase oldFile, string path, int width, int height)
        {
            WebImage ResizedImg = new WebImage(oldFile.InputStream);
            if (ResizedImg.Width > width || ResizedImg.Height > height)
            {
                ResizedImg.Resize(width, height, true, true);
            }
            ResizedImg.Save(path);
        }

        public static void ResizeImage(string path, int width, int height)
        {
            WebImage ResizedImg = new WebImage(path);
            if (ResizedImg.Width > width || ResizedImg.Height > height)
            {
                ResizedImg.Resize(width, height, true, true);
            }
            ResizedImg.Save(path);
        }
    }
}