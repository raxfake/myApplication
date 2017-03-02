using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class MovieFormViewModel
    {
        public List<Genre> GenreList { get; set; }
        public Movie Movie { get; set; }
    }
}