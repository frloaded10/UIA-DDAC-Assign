using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webddac2017.Models;

namespace Webddac2017.Controllers
{
    public class UserRtController : Controller
    {
        // GET: UserRt
        [HttpGet]
        public ActionResult UserAddEdit(int id=0) // For HTTP Get Request
        {
            User userMod = new Models.User();
            return View(userMod);
        }
        [HttpPost]
        public ActionResult UserAddEdit(User userMod)
        {
            using (UserRtDb userdbmod = new UserRtDb())
            {
                if (userdbmod.Users.Any(a => a.Username == userMod.Username))
                {
                    ViewBag.DulplicateMessage = "Existing Username. Please Re-enter.";
                    return View("UserAddEdit", userMod);
                }
                userdbmod.Users.Add(userMod);
                userdbmod.SaveChanges();

            }
            ModelState.Clear();
            ViewBag.SuccessfulMessage = "Successful Registration."; // Success Message Method
            return View("UserAddEdit", new User());
        }
    }
}