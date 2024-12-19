using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FindAMovie.Models;
using FindAMovie.Data;

namespace FindAMovie.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {        
        return View();
    }

    public IActionResult License()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpGet]
    public IActionResult Index(string? searchTerm)
    {        
        // var movies =_context.Movies.ToList();
        var movies = string.IsNullOrEmpty(searchTerm)
            ? _context.Movies.ToList()
            : _context.Movies
                .Where(m => m.Series_Title.Contains(searchTerm) || m.Overview.Contains(searchTerm))
                .ToList();
        

        return View(movies);
    }
}
