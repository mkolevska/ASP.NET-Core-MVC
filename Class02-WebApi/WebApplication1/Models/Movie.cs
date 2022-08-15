using WebApplication1.Enum;

namespace WebApplication1.Models
{
    public class Movie 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Genrecs genre { get; set; }
        public int Rating { get; set; }
        public int Year { get; set; }
    }
}
