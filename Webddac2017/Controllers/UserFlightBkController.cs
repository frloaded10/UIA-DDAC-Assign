using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webddac2017.Models;

namespace Webddac2017.Controllers
{
    public class UserFlightBkController : Controller
    {
        // GET: UserFlightBk
        public ActionResult UserBooking()
        {
            using (UserBkDb userbkModel = new UserBkDb())
            {

                return View(userbkModel.Flightbookings.ToList());
            }   
        }

        public ActionResult UserBookingV()
        {
            using (UserBkDb userbkModel = new UserBkDb())
            {

                return View(userbkModel.Flightbookings.ToList());
            }
        }

        // GET: UserFlightBk/Details/5
        public ActionResult Details(int id)
        {
            using (UserBkDb userbkModel = new UserBkDb())
            {

                return View(userbkModel.Flightbookings.Where(c => c.Id ==id).FirstOrDefault());
            } 
        }

        public ActionResult UserDetails(int id)
        {
            using (UserBkDb userbkModel = new UserBkDb())
            {

                return View(userbkModel.Flightbookings.Where(c => c.Id == id).FirstOrDefault());
            }
        }
        public ActionResult UserCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserCreate(Flightbooking userbk)
        {
            try
            {

                using (UserBkDb userbkModel = new UserBkDb())
                {
                    if (userbkModel.Flightbookings.Any(n => n.Seat == userbk.Seat))
                    {
                        ViewBag.DulplicateMessage = "Seat Taken. Please Choose Another.";
                        return View("UserCreate", userbk);
                    }
                    userbkModel.Flightbookings.Add(userbk);
                    userbkModel.SaveChanges();
                }
                ModelState.Clear();
                return RedirectToAction("UserBookingV");


            }
            catch
            {
                return View();
            }
        }

        // GET: UserFlightBk/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserFlightBk/Create
        [HttpPost]
        public ActionResult Create(Flightbooking userbk)
        {
            try
            {
                using (UserBkDb userbkModel = new UserBkDb())
                {
                    if (userbkModel.Flightbookings.Any(a => a.Seat == userbk.Seat))
                    {
                        ViewBag.DulplicateMessage = "Seat Taken. Please Choose Another.";
                        return View("Create", userbk);
                    }
                    userbkModel.Flightbookings.Add(userbk);
                    userbkModel.SaveChanges();
                }
                ModelState.Clear();
                return RedirectToAction("UserBooking");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserFlightBk/Edit/5
        public ActionResult Edit(int id)
        {
            using (UserBkDb userbkModel = new UserBkDb())
            {

                return View(userbkModel.Flightbookings.Where(c => c.Id == id).FirstOrDefault());
            }
        }

        // POST: UserFlightBk/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Flightbooking userbk)
        {
            try
            {
                using (UserBkDb userbkModel = new UserBkDb())
                {
                    userbkModel.Entry(userbk).State = EntityState.Modified;
                    userbkModel.SaveChanges();
                }

                    // TODO: Add update logic here

                    return RedirectToAction("UserBooking");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserFlightBk/Delete/5
        public ActionResult Delete(int id)
        {
            using (UserBkDb userbkModel = new UserBkDb())
            {

                return View(userbkModel.Flightbookings.Where(c => c.Id == id).FirstOrDefault());
            }
        }

        // POST: UserFlightBk/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (UserBkDb userbkModel = new UserBkDb())
                {
                    Flightbooking userbk = userbkModel.Flightbookings.Where(c => c.Id == id).FirstOrDefault();
                    userbkModel.Flightbookings.Remove(userbk);
                    userbkModel.SaveChanges();
                }
                return RedirectToAction("UserBooking");
            }
            catch
            {
                return View();
            }
        }
    }
}
