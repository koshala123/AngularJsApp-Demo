using AngularJsApp.BuisnessLogic;
using AngularJsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularJsApp.Controllers
{
    public class HomeController : Controller
    {
        private IRegistration _registration;
       
        public HomeController(IRegistration registration)
        {
            _registration = registration;
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Show_data()
        {
            return View();
        }
        public ActionResult Update_data(int id)
        {
            return View();
        }
        
        public JsonResult Update_record(tbl_registration registration)
        {
            _registration.UpdateUser(registration);
            string res = "Updated";
            return Json(res,JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_dataById(int Id)
        {
            var user = _registration.GetRegistration(Id);
            return Json(user, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add_record(tbl_registration registration)
        {
            _registration.CreateUser(registration);
            string res = "Inserted";
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_data()
        {
            var users = _registration.GetRegistrations();
            return Json(users,JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete_record(int id)
        {
            _registration.DeleteUser(id);
            string res = "Successfully Deleted";
            return Json(res,JsonRequestBehavior.AllowGet);
        }

    }
}