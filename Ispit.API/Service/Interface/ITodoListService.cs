using Ispit.API.Models;
using Ispit.API.Models.Dbo;

namespace Ispit.API.Service.Interface
{
    public interface ITodoListService
    {
        Task<TodoList> AddTodoList(TodoListBinding model);
        Task<TodoList> DeleteTodoList(int id);
        Task<TodoList> GetTodoList(int id);
        Task<List<TodoList>> GetTodoLists();
        Task<TodoList> UpdateTodoList(TodoListUpdateBinding model);
    }
}