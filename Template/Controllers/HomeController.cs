using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Template.Models;
using Template.Services;

namespace Template.Controllers
{
    public class HomeController : Controller
    {
        ProjectEntities db = new ProjectEntities();
        public ActionResult Index()
        {
            var data = db.Restaurants.FirstOrDefault(x=>x.id == 16);
            return View(data);
        }

        public ActionResult Read()
        {
            var list = db.Restaurants.ToList();
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Restaurant model, List<Images> Images)
        {

            var data = new Restaurant();
            data.title = model.title;
            data.subtitle = model.subtitle;
            data.address = model.address;
            data.description = model.description;
            data.DisplayReservationbutton = model.DisplayReservationbutton;

            string imgtype = ".jpg,.bmp,.gif,.png,.jpeg,.webp";
            string[] AllowedExt = imgtype.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            string path = "~/uploads/ProductIconImages/";

            var support = UploadHelper.UploadFile(model.supportname, path, AllowedExt);
            if (support.Status)
            {
                // save image name and path here 
                data.support_logo_name = support.FileName;
                data.support_logo_path = path;
                //path mathi ko string path huncha

            }
            data.support_number = model.support_number;
            db.Restaurants.Add(data);

            if (Images != null)
            {
                foreach (var item in Images)
                {
                    var temp = UploadHelper.UploadFile(item.ImageFile, path, AllowedExt);
                    if (temp.Status)
                    {
                        // save image name and path here 
                        var img = new Image()
                        {
                            image_name = temp.FileName,
                            image_path = path,
                            title = item.title,
                        };
                        data.Images.Add(img);
                    }
                }
            }
            
            db.SaveChanges();
            return RedirectToAction("Read");
        }

        //public ActionResult SaveImage(Image model)
        //{
        //    var data = new Image();
        //    data.title = model.title;
        //    data.image_name = model.image_name;
        //    data.image_path = model.image_path;

        //    string imgtype = ".jpg,.bmp,.gif,.png,.jpeg,.webp";
        //    string[] AllowedExt = imgtype.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
        //    string path = "~/uploads/ProductIconImages/";

        //    var res = UploadHelper.UploadFile(model.toppick, path, AllowedExt);
        //    if (res.Status)
        //    {
        //        // save image name and path here 
        //        data.image_name = res.FileName;
        //        data.image_path = path;

        //        //path mathi ko string path huncha

        //    }
        //    return RedirectToAction("Index");
        //}

        public ActionResult Delete(int id)
        {
            var del = db.Restaurants.Find(id);
            db.Restaurants.Remove(del);
            db.SaveChanges();
            return RedirectToAction("Read");
        }

        public ActionResult Update(int id)
        {
            var upd = db.Restaurants.Find(id);
            return View(upd);
        }

        [HttpPost]
        public ActionResult Update(Restaurant model, List<Images> Images)
        {
            var upd = db.Restaurants.Find(model.id);
            db.Images.RemoveRange(upd.Images);

            if (upd != null)
            {
                upd.title = model.title;
                upd.subtitle = model.subtitle;
                upd.address = model.address;
                upd.description = model.description;
                upd.DisplayReservationbutton = model.DisplayReservationbutton;

                string imgtype = ".jpg,.bmp,.gif,.png,.jpeg,.webp";
                string[] AllowedExt = imgtype.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                string path = "~/uploads/ProductIconImages/";
                //var res = UploadHelper.UploadFile(model.supportname, path, AllowedExt);
                //if (res.Status)
                //{
                //    save image name and path here
                //    upd.toppick1_imgname = res.FileName;
                //    upd.toppick1_imgpath = path;

                //    path mathi ko string path huncha

                //}
                //var res2 = UploadHelper.UploadFile(model.toppick2, path, AllowedExt);
                //if (res2.Status)
                //{
                //    // save image name and path here 
                //    upd.toppick2_imgname = res2.FileName;
                //    upd.toppick2_imgpath = path;
                //    //path mathi ko string path huncha

                //}

                //var res3 = UploadHelper.UploadFile(model.toppick3, path, AllowedExt);
                //if (res3.Status)
                //{
                //    // save image name and path here 
                //    upd.toppick3_imgname = res3.FileName;
                //    upd.toppick3_imgpath = path;
                //    //path mathi ko string path huncha

                //}

                var support = UploadHelper.UploadFile(model.supportname, path, AllowedExt);
                if (support.Status)
                {
                    // save image name and path here 
                    upd.support_logo_name = support.FileName;
                    upd.support_logo_path = path;
                    //path mathi ko string path huncha

                }

                upd.support_number = model.support_number;

                foreach (var item in Images)
                {
                    if (Images != null)
                    {
                        var temp = UploadHelper.UploadFile(item.ImageFile, path, AllowedExt);
                        if (temp.Status)
                        {
                            // save image name and path here 
                            var img = new Image()
                            {
                                image_name = temp.FileName,
                                image_path = path,
                                title = item.title,
                            };
                            upd.Images.Add(img);
                        }
                    }
                }
                db.Entry(upd).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                string message = "Data is updated successfully";
                ViewBag.Message = message;

                return RedirectToAction("Read");
            }
            else
            {
                return View();
            }
        }
    }
}