using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/todo")]
    [ApiController]
    public class TodoController : ControllerBase
    {

        private readonly TodoContext _context;

        public TodoController(TodoContext todoContext)
        {
            _context = todoContext;
        }

        // GET: All todo
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _context.TodoItems.ToListAsync();
            return Ok(items);
        }

        //Get one todo
        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> GetOne([FromRoute] long id)
        {
            var item = await _context.TodoItems.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        //Add Item
        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody] TodoItem todoItem)
        {

            var addTodo = new TodoItem
            {
                Id = todoItem.Id,
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete
            };

            _context.TodoItems.Add(addTodo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("CreateTodo", new { id = todoItem.Id }, todoItem);
        }

        [HttpPut]
        [Route("{id:long}")]
        public async Task<IActionResult> UpdateTodo([FromBody] TodoItem todoItem, [FromRoute] long id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            item.Name = todoItem.Name;
            item.IsComplete = todoItem.IsComplete;

            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }
}