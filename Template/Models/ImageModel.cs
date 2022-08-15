using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Template.Models
{
    //public class ImageModel
    //{
    //    public ImageModel()
    //    {
    //        Image = new List<Images>();
    //    }
    //    public long id { get; set; }
    //    public string title { get; set; }
    //    public string subtitle { get; set; }
    //    public string address { get; set; }
    //    public string description { get; set; }
    //    public string DisplayReservationbutton { get; set; }
    //    public string support_logo_name { get; set; }
    //    public string support_logo_path { get; set; }
    //    public string support_number { get; set; }
    //    public IList<Images> Image { get; set; }
    //}

    public class Images
    {
    //    public string image_name { get; set; }
        public string title { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

    }
}