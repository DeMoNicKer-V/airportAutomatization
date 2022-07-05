using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace airportAutomatization.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly airport_dbContext _context;
        public List<Flight> Flights { get; set; }
        public IndexModel(airport_dbContext db)
        {
            _context = db;
        }
        public void OnGet()
        {
            Flights = _context.Flights.AsNoTracking().ToList();
        }
    }
}