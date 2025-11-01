using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Core.DTOs.Requests;
using TodoApi.Core.DTOs.Responses;
using TodoApi.Core.Models;
using TodoApi.Core.Interfaces;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoUseCases _todoUseCases;

        public TodoController(ITodoUseCases todoUseCases)
        {
            _todoUseCases = todoUseCases;
        }

        // GET: api/todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoResponse>>> GetAll()
        {
            try
            {
                var todos = await _todoUseCases.GetAllTodosAsync();
                var response = todos.Select(TodoResponse.FromTodoItem);
                return Ok(response);
            } catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }

        // GET: api/todo/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoResponse>> GetById(int id)
        {
            try
            {
                var todo = await _todoUseCases.GetTodoByIdAsync(id);
                if (todo == null) return NotFound(new { message = "Task not found" });
                return Ok(TodoResponse.FromTodoItem(todo));
            }
            catch (ArgumentException  ex)
            {
                return BadRequest(new { message = ex.Message });
            } catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
            
        }

        // POST: api/todo
        [HttpPost]
        public async Task<ActionResult<TodoItem>> Create([FromBody] CreateTodoRequest request)
        {
            try
            {
                var todo = await _todoUseCases.CreateTodoAsync(request.Title, request.Description);
                var response = TodoResponse.FromTodoItem(todo);

                return CreatedAtAction(nameof(GetById), new { id = todo.Id }, response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }

        // PUT: api/todo/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTodoRequest request)
        {
            try
            {
                var todo = await _todoUseCases.UpdateTodoAsync(id, request.Title, request.Description, request.IsCompleted);
                if (todo == null) return NotFound(new { message = "Task not found" });
                return Ok(TodoResponse.FromTodoItem(todo));
            } catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            } catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }

        // DELETE: api/todo/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _todoUseCases.DeleteTodoAsync(id);
                if (!result) return NotFound(new { message = "Task not found" });
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }
    }
}