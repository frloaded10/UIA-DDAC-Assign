using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Webddac2017.Models;

namespace Webddac2017.Controllers
{
    public class UserLoginController : Controller
    {
        // GET: UserLogin
        public ActionResult UserLoginWeb()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherize(Webddac2017.Models.UserLogin userValiMod)
        {
            using (UserRtDb db = new UserRtDb())
            {
                var userInfo = db.Users.Where(b => b.Username == userValiMod.Username && b.Password == userValiMod.Password).FirstOrDefault();
                if (userValiMod.Username == "admin" && userValiMod.Password == "12345")
                {
                    //Session["username"] = userInfo.UserID;
                    Session["userName"] = userValiMod.Username;
                    //FormsAuthentication.SetAuthCookie(userValiMod.Username, false);
                    return RedirectToAction("UserBooking", "UserFlightBk"); // ("View URL","Controller URL")
                }
                else if (userInfo == null)
                {
                    userValiMod.ErrorMessageLogin = "Username or Password is Wrong. Enter Again.";
                    return View("UserLoginWeb", userValiMod);
                }
                else
                {
                    Session["username"] = userInfo.UserID;
                    Session["userName"] = userInfo.Username;
                    return RedirectToAction("UserBookingV", "UserFlightBk");
                }
            }
                
        }
        public ActionResult Logout()
        {
            string userName = (string)Session["username"];
            Session.Abandon();
            return RedirectToAction("UserLoginWeb","UserLogin");
        }
    }
}