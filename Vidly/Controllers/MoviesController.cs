﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : BaseController
    {
        // GET: movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };

            var customers = new List<Customer>
            {
                new Customer{Name="Customer 1"},
                new Customer{Name="Customer 2"}
            };

            var viewModel = new RandomMovieViewModel { Movie = movie, Customers = customers };
            //ViewData["Movie"] = movie;
            return View(viewModel);
        }

        // GET: movies/Edit
        public ActionResult Edit(int id)
        {
            return Content("Id is " + id);
        }

        // GET: movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2})}")]
        public ActionResult ByReleasedDate(int year, int month)
        {
            return Content(string.Format("year={0}&month={1}", year, month));
        }

        public ActionResult Test(string lang)
        {
            ViewData["lang"] = lang;
            return View();
        }
    }
}