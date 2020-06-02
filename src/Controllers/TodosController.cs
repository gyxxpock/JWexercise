using Microsoft.AspNetCore.Mvc;
using Exercise.Models;
using Exercise.Controllers;
using Newtonsoft.Json;

namespace Exercise.Todos.Controllers
{
    // Routes get api/todos
    // Routes get api/todos/:id
    // Routes delete api/todo/:id
    // Routes post api/todos
    // Routes put api/todos/:id
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(JsonConvert.SerializeObject(DatabaseController.GetAll(), Formatting.Indented));
        }
        
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetTodo(string id)
        {
            ToDo todo = DatabaseController.GetByID(id);
            if (todo == null)
            {
                return NotFound(id);
            }
            return Ok(JsonConvert.SerializeObject(todo, Formatting.Indented));
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteTodo(string id)
        {
            DatabaseController.Delete(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateTodo(ToDo todo)
        {
            return Ok(DatabaseController.Insert(todo.Description));
        }
        [HttpPut]
        public IActionResult UpdateTodo(ToDo todo)
        {
            DatabaseController.Update(todo);
            return Ok(todo.ID);
        }
    }
}