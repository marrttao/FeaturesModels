using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Data;
using WebApplication1.Features.Clients.Models;
using WebApplication1.Features.Clients.ViewModels;

namespace WebApplication1.Features.Clients.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _dbContext;

        public IndexModel(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        // for forms
        [BindProperty] public ClientViewModel NewClient { get; set; } = new();
        // for tables
        public List<Client> Clients { get; set; } = new();
        
        public void OnGet()
        {
           // Clients = _dbContext.Clients.ToList();
           Clients = _dbContext.Clients.OrderByDescending(c => c.CreatedAt).ToList();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Clients = _dbContext.Clients.OrderByDescending(c => c.CreatedAt).ToList();
                return Page();
            }
            
            var client = new Client
            {
                Surname = NewClient.Surname,
                FirstName = NewClient.FirstName,
                Patronymic = NewClient.Patronymic,
                Email = NewClient.Email,
                BirthDate = NewClient.BirthDate,
                CreatedAt = DateTime.Now,
                UpdatedAt =  DateTime.Now
            };
            
            _dbContext.Clients.Add(client);
            _dbContext.SaveChanges();
            
            return RedirectToPage();
        }
    }
    
}
