
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ContactsController : Controller
    {
        private readonly WebApplication4DbContext _dbContext;

        public ContactsController(WebApplication4DbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        // GET
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            return Ok(await _dbContext.Contacts.ToListAsync());
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> AddContacts(AddContactRequest addContactRequest)
        {
            var contacts = new Contacts()
            {
                Id = Guid.NewGuid(),

            };

            await _dbContext.Contacts.AddAsync(contacts);
            await _dbContext.SaveChangesAsync();

            return Ok(contacts);
        }

       
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Getbyid(int id)
        {
            return Ok(await _dbContext.Contacts.FindAsync(id));
        }
    }
}
