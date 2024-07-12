using Ispit.API.Models;
using Ispit.API.Models.Dbo;
using Ispit.API.Service.Implementations;
using Ispit.API.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Ispit.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoListController : ControllerBase
    {
     

        private readonly ITodoListService todoListService;

        public TodoListController(ITodoListService todoListService)
        {
            this.todoListService = todoListService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TodoList), StatusCodes.Status200OK)]
        public async Task<ActionResult<TodoList>> GetTodoList(int id)
        {

            var todoList = await todoListService.GetTodoList(id);
            return Ok(todoList);

        }
        
        [HttpPost]
        [ProducesResponseType(typeof(TodoList), StatusCodes.Status200OK)]
        public async Task<ActionResult<TodoList>> AddTodoList([FromBody] TodoListBinding model)
        {
            var todoList =  await todoListService.AddTodoList(model);
            return Ok(todoList);
        }
        
        [HttpGet("todoLists")]
        [ProducesResponseType(typeof(List<TodoList>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<TodoList>>> GetTodoLists()
        {
            var todoLists = await todoListService.GetTodoLists();
            return Ok(todoLists);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(TodoList), StatusCodes.Status200OK)]
        public async Task<ActionResult<TodoList>> DeleteTodoList(int id)
        {
            await todoListService.DeleteTodoList(id);
            return Ok(new { Poruka = $"TodoList sa idom {id} je uspješno obrisana!" });
        }
        
        [HttpPut]
        [ProducesResponseType(typeof(TodoList), StatusCodes.Status200OK)]
        public async Task<ActionResult<TodoList>> UpdateTodoList([FromBody] TodoListUpdateBinding model)
        {
                
            var updatedTodoList = todoListService.UpdateTodoList(model);
            return Ok(updatedTodoList);
           
 
        }

    }
}
