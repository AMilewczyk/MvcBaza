using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcBaza.Models
{
    public class CatGenreViewModel
    {
        public List<Cat>? Cats { get; set; }
        public SelectList? Genres { get; set; }
        public string? CatGenre { get; set; }
        public string? SearchString { get; set; }



    }
}
