using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingList.API.Data;
using ShoppingList.API.Models;

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
            if(id == 1002) //Added for test to get date in string
                return Ok(DateTime.Now.ToString());

            if(id== 1003) // added for test to write new list to database
                {
                    //var dateTimeFormatString = "MM-dd-yyyy HH:mm:ss";
                    var time = DateTime.Now;
                    var newList = new ShopList(){Name="Test",TimeCreated=time, TimeModified=time};
                    _context.ShoppingLists.Add(newList);
                    _context.SaveChanges();
                                        
                    return Ok(_context.ShoppingLists.Include(x => x.ListItems).FirstOrDefaultAsync(i => i.TimeCreated == time));
                }

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