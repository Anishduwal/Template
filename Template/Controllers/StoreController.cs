using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Template.Models;

namespace Template.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        ProjectEntities db = new ProjectEntities();
        public ActionResult Index()
        {
            var list = db.Restaurants.FirstOrDefault(x => x.id == 16);
            var check = db.Store_hours.FirstOrDefault(x => x.id == 13);
            var future_order = db.Store_Infoes.FirstOrDefault(x => x.id == 4);
            var time_only = DateTime.Now.TimeOfDay;

            if (time_only >= check.From_time && time_only <= check.To_time)
            {
                return View(list);
            }
            else if (future_order.Enable_future_order == true)
            {
                return View(list);
            }
            
            return View("error");
        }

        public ActionResult Error()
        {
            var check = db.Store_hours.FirstOrDefault(x => x.id == 13);
            return View(check);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(StoreModel model)
        {
            var store = new Store_Info();
            store.Name = model.Name;
            store.Street_address = model.Street_address;
            store.State = model.State;
            store.City = model.City;
            store.Zip_code = model.Zip_code;
            store.phone_number = model.phone_number;
            store.Enable_future_order = model.Enable_future_order;

            var info = new Store_hour();
            info.Day = model.Day;
            info.From_time = model.From_time.TimeOfDay;
            info.To_time = model.To_time.TimeOfDay;
            info.Open_time = model.Open_time;

            db.Store_Infoes.Add(store);
            db.Store_hours.Add(info);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}