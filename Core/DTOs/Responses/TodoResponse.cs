using TodoApi.Core.Models;

namespace TodoApi.Core.DTOs.Responses
{
    public class TodoResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public static TodoResponse FromTodoItem(TodoItem todoItem)
        {
            return new TodoResponse
            {
                Id = todoItem.Id,
                Title = todoItem.Title,
                Description = todoItem.Description ?? string.Empty,
                IsCompleted = todoItem.IsCompleted,
                CreatedAt = todoItem.CreatedAt,
                UpdatedAt = todoItem.UpdatedAt
            };
        }
    }
}