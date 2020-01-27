using EmlakBazasi.DAL;
using EmlakBazasi.Models;
using System;
using System.Collections.Generic;
using System.Net;
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

        [HttpPost]
        public ActionResult addNote(Rem_user_note item)
        {
            item.is_deleted = 0;
            item.IP = GetIPAddress();
            item.date = DateTime.Now;
            bool result = methods.addNote(item);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult showNote(int id_user)
        {
            List<Rem_user_note> result = methods.showNote(id_user);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult showAllNote()
        {
            List<All_user_note> result = methods.showAllNote();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult addReminder(Rem_user_reminder item)
        {
            item.is_deleted = 0;
            item.IP = GetIPAddress();
            item.date = DateTime.Now;
            bool result = methods.addReminder(item);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult deleteReminder(int id_user)
        {
            bool result = methods.deleteReminder(id_user);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult addPayment(Rem_user_payment item)
        {
            item.id_deleted = 0;
            item.IP = GetIPAddress();
            item.date = DateTime.Now;
            bool result = methods.addPayment(item);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult showPayment(int id_user)
        {
            List<Rem_user_payment> result = methods.showPayment(id_user);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult showAllPayment()
        {
            List<All_user_payment> result = methods.showAllPayment();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult changeTag(int id_user)
        {
            bool result = methods.changeTag(id_user);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult clearTag(int id_user)
        {
            bool result = methods.clearTag(id_user);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult clearAllTags()
        {
            bool result = methods.clearAllTags();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult getInfoForAddUser()
        {
            var result = new WebModel
            {
                user_type_list=methods.getAllUserType(),
                message_list=methods.getAllMessageType(),
                user =methods.getUserForAddUser()
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult addUser(Rem_user item)
        {
            item.is_deleted = 0;
            item.is_active = 1;
            item.tag = 0;
            item.subscriber_tag = 0;
            item.MAC = "";
            item.last_IP = GetIPAddress();
            item.last_request_result = 0;
            bool result = methods.addUser(item);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult getUserInfoForUpdateUser(int id_user)
        {
            Rem_user result = methods.getUserInfoForUpdateUser(id_user);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult getUserTypeAndMessageTypeForUpdateUser()
        {
            var result = new WebModel
            {
                user_type_list = methods.getAllUserType(),
                message_list = methods.getAllMessageType(),
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult updateUser(Rem_user item)
        {
            //item.is_deleted = 0;
            //item.is_active = 1;
            //item.tag = 0;
            //item.subscriber_tag = 0;
            //item.MAC = "";
            //item.last_IP = GetIPAddress();
            //item.last_request_result = 0;
            bool result = methods.updateUser(item);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public string GetIPAddress()
        {
            string IPAddress = "";
            IPHostEntry Host = default(IPHostEntry);
            string Hostname = null;
            Hostname = Environment.MachineName;
            Host = Dns.GetHostEntry(Hostname);
            foreach (IPAddress IP in Host.AddressList)
            {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    IPAddress = Convert.ToString(IP);
                }
            }
            return IPAddress;
        }
    }
}