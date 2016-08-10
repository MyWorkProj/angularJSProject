using MvcProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProj.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        Service.User userService = new Service.User();
        public ActionResult Index()
        {
            UserModel model = new UserModel();

            var list = userService.GetAllUser();
            //var list = userService.GetAllUserModel();

            if (Request.IsAjaxRequest())
            {
                return PartialView("_ListItem", list);
            }
            return View(list);
        }

        //
        // GET: /User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /User/Create
        public ActionResult Create()
        {

            return View();
        }

        //
        // POST: /User/Create
        [HttpPost]
        public ActionResult Create(userinfotb model)
        {
            try
            {
                // TODO: Add insert logic here
                userService.Add(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Edit/5
        public ActionResult Edit(int id)
        {
            UserModel user = userService.GetUser(id);
            return View(user);
        }

        //
        // POST: /User/Edit/5
        [HttpPost]
        public ActionResult Edit(UserModel model)
        {
            try
            {
                userinfotb u = new userinfotb
                {
                    id = (int)model.id,
                    adress = model.adress,
                    age = model.age,
                    name = model.name,
                    phone = model.phone
                };
                userService.Edit(u);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                userinfotb user = new userinfotb();
                user.id = id;
                userService.Delete(user);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /User/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here
        //        userinfotb user = new userinfotb();
        //        user.id = id;
        //        userService.Delete(user);
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
