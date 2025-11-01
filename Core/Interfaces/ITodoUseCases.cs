using TodoApi.Core.Models;
using TodoApi.Core.DTOs;

namespace TodoApi.Core.Interfaces
{
    public interface ITodoUseCases
    {
        Task<IEnumerable<TodoItem>> GetAllTodosAsync();
        Task<TodoItem?> GetTodoByIdAsync(int id);
        Task<TodoItem> CreateTodoAsync(string title, string description);
        Task<TodoItem> UpdateTodoAsync(int id, string title, string description, bool isCompleted);
        Task<bool> DeleteTodoAsync(int id);
    }
}