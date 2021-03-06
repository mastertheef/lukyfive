﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Luckyfive.Service.Abstraction;

namespace Luckyfive.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IAdvertismentService advService;

        public HomeController(IAdvertismentService advService)
        {
            this.advService = advService;
        }

        public async Task<ActionResult> Index()
        {
            var foundTop = await this.advService.GetAdvertismentsForHomePage();
            if (foundTop.Any())
            {
                foundTop.Add(foundTop.First()); // just to make at least 3 of them
                
            }
            return View(foundTop);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View("Error");
        }
    }
}