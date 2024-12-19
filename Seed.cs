using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using FindAMovie.Data;
using FindAMovie.Models;



namespace FindAMovie
{
    public class Seed
    {
        private readonly ApplicationDbContext dataContext;

        public Seed(ApplicationDbContext context)
        {
            this.dataContext = context;
        }
        public void SeedApplicationDbContext()
        {
            string filePath = "Data/imdb_top_1000.csv";

            var movies = new List<Movie>();
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null,  // Disable header validation
                MissingFieldFound = null // Disable missing field validation
            };
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                movies = csv.GetRecords<Movie>().ToList();
            }

            if (!dataContext.Movies.Any())
            {
                dataContext.Movies.AddRange(movies);
                dataContext.SaveChanges();
                Console.WriteLine("Database seeded successfully!");
            }
            else
            {
                Console.WriteLine("Database already has data!");
            }
        }

    }
}
