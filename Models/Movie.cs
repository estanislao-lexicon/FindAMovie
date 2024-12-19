using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FindAMovie.Models
{
    public class Movie 
    {        
        public int Id { get; set; }
        public string Poster_Link { get; set; }
        public string Series_Title { get; set; }
        public int Released_Year { get; set; }
        public string Certificate { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public decimal IMDB_Rating { get; set; }
        public string Overview { get; set; }
        public int? Meta_score { get; set; }
        public string Director { get; set; }
        public string Star1 { get; set; }
        public string Star2 { get; set; }
        public string Star3 { get; set; }
        public string Star4 { get; set; }
        public int No_of_Votes { get; set; }
        public int? Gross { get; set; }
    }
}
