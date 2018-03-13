using System;
using System.Linq;
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
            // if(id == 1002) //Added for test to get date in string
            //     return Ok(DateTime.Now.ToString());

            // if(id== 1003) // added for test to write new list to database
            //     {
            //         //var dateTimeFormatString = "MM-dd-yyyy HH:mm:ss";
            //         var time = DateTime.Now;
            //         var newList = new ShopList(){Name="Test",TimeCreated=time, TimeModified=time};
            //         _context.ShoppingLists.Add(newList);
            //         _context.SaveChanges();
                                        
            //         return Ok(_context.ShoppingLists.Include(x => x.ListItems).FirstOrDefaultAsync(i => i.TimeCreated == time));
            //     }

            var shoppingList = await _context.ShoppingLists.Include(x => x.ListItems).FirstOrDefaultAsync(i => i.Id == id);
            if(shoppingList != null)
                return Ok(shoppingList);
            else
                return NotFound();
        }
        private ShopList GetCompleteList(int id)
        {
            var shoppingList = _context.ShoppingLists.Include(x => x.ListItems).FirstOrDefault(i => i.Id == id);
            if(shoppingList != null)
                return shoppingList;
            else
                return null;
        }

        // POST api/Lists
        [HttpPost]
        public async Task<IActionResult> CreateNewList([FromBody]string name)
        {
            if(string.IsNullOrEmpty(name))
                return BadRequest("Error: List must have a name specified");

            var timeNow = DateTime.Now;
            var newList = new ShopList(){ Name = name, TimeCreated=timeNow, TimeModified=timeNow };
            await _context.ShoppingLists.AddAsync(newList);
            await _context.SaveChangesAsync();
            return Ok(newList);
        }

        // PUT api/Lists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateListDetails(int id, [FromBody]string list)
        {
            return Ok();
        }

        // PUT api/Lists/5/items/4
        [HttpPut("{listId}/items/{itemId}")]
        public async Task<IActionResult> UpdateListDetailsItem(int listId, int itemId, [FromBody]string value)
        {
            return Ok();
        }

        // DELETE api/lists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteList(int id)
        {
            var shoppingList = await _context.ShoppingLists.FirstOrDefaultAsync(i => i.Id == id);
            if(shoppingList != null)
            {
                _context.ShoppingLists.Remove(shoppingList);
                await _context.SaveChangesAsync();
                return Ok(shoppingList);
            }
            else
                return NotFound();
        }

        // POST api/lists/5
        [HttpPost("{id}")]
        public async Task<IActionResult> AddItemToList(int id, [FromBody]string name)
        {
            if(string.IsNullOrEmpty(name))
                return BadRequest("Error: Item must have a name specified");

            var list = GetCompleteList(id);
            if(list != null)
            {
                var newItem = new ListItem(){ Name = name, ActiveOnList = true };
                list.ListItems.Add(newItem);
                await _context.SaveChangesAsync();
                return Ok(newItem);
            }
            else
                return BadRequest("unspecified error: "+list + name);
        }

        // DELETE api/lists/5/4
        [HttpDelete("{listId}/{itemId}")]
        public async Task<IActionResult> DeleteItem(int listId, int itemId)
        {
            var list = GetCompleteList(listId);
            if(list != null)
            {
                //_context.ShoppingLists.Remove(shoppingList);
                list.ListItems.Remove(
                    list.ListItems.Find(i => i.Id == itemId));
                
                await _context.SaveChangesAsync();
                return Ok(list);
            }
            else
                return NotFound();
        }


 // Update shoppinglistname
 
 // Update listitem status (aktiv/ikke aktiv, købt/ikke købt)
 
 // Update listitem navn

 // Update listitem vare
        

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