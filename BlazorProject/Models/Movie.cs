namespace BlazorProject.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Poster { get; set; }

        public override string ToString()
        {
            return $"{Title} ({Year})";
        }
    }
}
