using Ispit.API.Data;
using Ispit.API.Models;
using Ispit.API.Models.Dbo;
using Ispit.API.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Ispit.API.Service.Implementations
{
    public class TodoListService : ITodoListService
    {
        private readonly ApplicationDbContext db;

        public TodoListService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<TodoList> AddTodoList(TodoListBinding model)
        {
            var dbo = new TodoList
            {
               
                Title = model.Title,
                Description = model.Description,
                IsCompleted = model.IsCompleted

            };
            db.TodoLists.Add(dbo);
            await db.SaveChangesAsync();
            return dbo;
        }
        public async Task<TodoList> GetTodoList(int id)
        {
            var dbo = await db.TodoLists.FindAsync(id);
            return dbo;
        }

        public async Task<TodoList> DeleteTodoList(int id)
        {
            var dbo = await db.TodoLists.FindAsync(id);
            db.TodoLists.Remove(dbo);
            await db.SaveChangesAsync();

            return dbo;
        }

        public async Task<List<TodoList>> GetTodoLists()
        {
            var todoLists = await db.TodoLists.ToListAsync();

            return todoLists;
        }


        public async Task<TodoList> UpdateTodoList(TodoListUpdateBinding model)
        {
            var todoList = await db.TodoLists.FirstOrDefaultAsync(m => m.Id == model.Id);
            if (todoList == null)
            {
                return null;
            }

            todoList.Title = model.Title;
            todoList.Description = model.Description;
            todoList.IsCompleted = model.IsCompleted;

            await db.SaveChangesAsync();

            return todoList;
        }
    }
}
