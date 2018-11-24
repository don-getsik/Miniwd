using Miniwd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Miniwd.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ViewResult Index()
        {
            ViewBag.isCheck = false;
            return View();
        }

        [HttpPost]
        public ViewResult Index (Flat flat)
        {
            if (ModelState.IsValid)
            {
                // TODO: Dodanie obsługi zgłoszenia
                return View("Result", flat);
            }
            else
            {
                ViewBag.isCheck = true;
                return View();
            }
        }
    }
}