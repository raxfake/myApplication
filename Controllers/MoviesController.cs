using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Linq;
using System.Collections.ObjectModel;
using System.Web.Routing;

namespace WebApplication1.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movies = (new List<Movie> { new Movie { Id = 1, Name = "DDLJ" },
            new Movie { Id = 2, Name = "JANAM" }, new Movie { Id = 3, Name = "MUGHLE" }}).AsReadOnly();
            this.EditData(movies);
            //return View(month);
            return new EmptyResult();
            //return Content("DDLJ", "ddlj");
            //return HttpNotFound("ddlg");
            //return RedirectToAction("Edit", "Movies", new { id = 1 });
        }

                public ActionResult EditData(ReadOnlyCollection<Movie> list) 
        {
            var id = 1;

            var dList = list;

            for (int i = 0; i < dList.Count; i++)
            {
                if (dList[i].Id == 2)
                {
                    dList[i].Name = null;
                    
                }
            }

            //foreach (var data in list)
            //{
            //    //var dData = data;
            //    //var dName = data.Name;
            //    if (data.Id == 2)
            //    {
            //        data.Name = null;
            //    }
            //}

            return Content("id = " + id);
        }

        public ActionResult Edit(int id)
        {
            return Content("id = " + id);
        }

        public ActionResult Index(int? pageNumber, string sortBy)
        {
            if (!pageNumber.HasValue)
                pageNumber = 1;

            if (string.IsNullOrEmpty(sortBy))
                sortBy = "Name";
            return Content(string.Format("page number = {0} sort by = {1}", pageNumber, sortBy));
        }

        [Route("movies/released/{year:regex(\\d{4}):max(2020):min(2010)}/{month:regex(\\d{2}):range(1,12)}/{date:regex(\\d{2}):range(01,31)}")]
        //[Route("movies/released/{year}/{month}/{date}")]
        public ActionResult ReleasedInfo(int year, int month, int date)
        {
            return this.Content(year + "/" + month + "/"+date);
        }

        [Route("user/{comment}")]
        public ActionResult ReviewByUser(string comment)
        {
            return Content(comment+" 1");
        }

        [Route("critics/{comment}")]
        public ActionResult ReviewByCritics(string comment)
        {
            return Content(comment + " 2");
        }

        public ActionResult Critics(int wah)
        {
            return Content(wah + " 3");
        }

        [Route("movies/list")]
        public ActionResult MovieList()
        {
            var movieList = new List<Movie> {new Movie {Name = "Wall-E"}, new Movie {Name = "Bad Boys"}};

            return View();
        }
    }
}