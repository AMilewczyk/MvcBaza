using System.ComponentModel.DataAnnotations;

namespace MvcBaza.Models
{
    public class Cat
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        //[DataType(DataType.Date)]
        public int Years { get; set; }
        public string? Genre { get; set; }
        public string Behawior { get; set; }
    }
}
