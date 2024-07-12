namespace Ispit.API.Models
{
    public class TodoListUpdateBinding
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

    }
}
