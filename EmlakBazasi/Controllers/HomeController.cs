using EmlakBazasi.DAL;
using EmlakBazasi.Models;
using System.Web.Mvc;

namespace EmlakBazasi.Controllers
{
    public class HomeController : Controller
    {
        Methods methods = new Methods();

        public ActionResult Index(int id=0)
        {
            var model = new WebModel
            {
                view_rem_user_list = methods.filterUsers(id)
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult deactiveUser(int id_user)
        {
            bool result = methods.deactiveUser(id_user);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult blockUser(int id_user)
        {
            bool result = methods.blockUser(id_user);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult activateUser(int id_user)
        {
            bool result = methods.activateUser(id_user);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult changeAsSubscriber(int id_user)
        {
            bool result = methods.changeAsSubscriber(id_user);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult deleteUser(int id_user)
        {
            bool result = methods.deleteUser(id_user);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}