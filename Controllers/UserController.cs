using Microsoft.AspNetCore.Mvc;
using FindAMovie.Models;
using FindAMovie.Data;


namespace FindAMovie.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private readonly ApplicationDbContext _context;
    public UserController(ILogger<UserController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }
   
    [HttpGet]
    public IActionResult Dashboard(string? searchTerm)
    {   
        var movies = string.IsNullOrEmpty(searchTerm)
            ? _context.Movies.ToList()
            : _context.Movies
                .Where(m => m.Series_Title.Contains(searchTerm) || m.Overview.Contains(searchTerm))
                .ToList();
        

        return View(movies);
    }
    
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
        if (movie == null)
        {
            return NotFound();
        }

        _context.Movies.Remove(movie);
        _context.SaveChanges();

        return RedirectToAction("Dashboard");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
        if (movie == null)
        {
            return NotFound();
        }
        return View(movie);
    }


    [HttpPost]
    public IActionResult Edit(Movie updatedMovie)
    {
        var movie = _context.Movies.FirstOrDefault(m => m.Id == updatedMovie.Id);
        if (movie == null)
        {
            return NotFound();
        }

        // Update properties
        movie.Series_Title = updatedMovie.Series_Title;
        movie.Released_Year = updatedMovie.Released_Year;
        movie.Certificate = updatedMovie.Certificate;
        movie.Runtime = updatedMovie.Runtime;
        movie.Genre = updatedMovie.Genre;
        movie.IMDB_Rating = updatedMovie.IMDB_Rating;
        movie.Overview = updatedMovie.Overview;
        movie.Meta_score = updatedMovie.Meta_score;
        movie.Director = updatedMovie.Director;
        movie.Star1 = updatedMovie.Star1;
        movie.Star2 = updatedMovie.Star2;
        movie.Star3 = updatedMovie.Star3;
        movie.Star4 = updatedMovie.Star4;
        movie.No_of_Votes = updatedMovie.No_of_Votes;
        movie.Gross = updatedMovie.Gross;

        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }


    [HttpGet]
    public IActionResult NewMovie()
    {
        return View(); // Render the form for adding a new movie
    }

    [HttpPost]
    public IActionResult NewMovie(Movie newMovie)
    {
        if (!ModelState.IsValid)
        {
            return View(newMovie); // Re-render the form if validation fails
        }

        _context.Movies.Add(newMovie);
        _context.SaveChanges();

        return RedirectToAction("Dashboard");
    }  
}
