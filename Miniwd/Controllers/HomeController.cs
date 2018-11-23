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
            return View("Index");
        }

        [HttpPost]
        public ViewResult Index (Flat flat)
        {
            // TODO: Dodanie obsługi zgłoszenia
            return View ("Result", flat);
        }
    }
}