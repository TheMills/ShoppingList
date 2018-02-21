using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingList.API.Data;

namespace ShoppingList.API.Controllers
{
    [Route("api/[controller]")]
    public class ListsController : Controller
    {
        private readonly DataContext _context;
        
        public ListsController(DataContext context)
        {
            _context = context;
        }
        // GET api/Lists
        [HttpGet]
        public async Task<IActionResult> GetLists()
        {
            var shoppingLists = await _context.ShoppingLists.ToListAsync();
            return Ok(shoppingLists);
        }

        // GET api/Lists/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetListAndItems(int id)
        {
            var shoppingList = await _context.ShoppingLists.Include(x => x.ListItems).FirstOrDefaultAsync(i => i.Id == id);
            if(shoppingList != null)
                return Ok(shoppingList);
            else
                return NotFound();
        }

        // // POST api/values
        // [HttpPost]
        // public void Post([FromBody]string value)
        // {
        // }

        // // PUT api/values/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody]string value)
        // {
        // }

        // // DELETE api/values/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}