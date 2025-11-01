using TodoApi.Core.Models;
using TodoApi.Core.Repositories;
using TodoApi.Core.Interfaces;
using TodoApi.Core.DTOs;

namespace TodoApi.Core.UseCases
{
    public class TodoUseCases : ITodoUseCases
    {
        public readonly ITodoRepository _todoRepository;

        public TodoUseCases(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<IEnumerable<TodoItem>> GetAllTodosAsync()
        {
            return await _todoRepository.GetAllAsync();
        }

        public async Task<TodoItem?> GetTodoByIdAsync(int id)
        {
            if (id <= 0) throw new ArgumentException("Id invalid");

            return await _todoRepository.GetByIdAsync(id);
        }

        public async Task<TodoItem> CreateTodoAsync(string title, string description)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title is required");

            if (title.Length > 200) throw new ArgumentException("Title is too long");

            var todoItem = new TodoItem
            {
                Title = title.Trim(),
                Description = description.Trim(),
                IsCompleted = false,
                CreatedAt = DateTime.UtcNow
            };

            return await _todoRepository.CreateAsync(todoItem);
        }

        public async Task<TodoItem> UpdateTodoAsync(int id, string title, string description, bool isCompleted)
        {
            if (id <= 0) throw new ArgumentException("Id invalid");

            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title is required");

            var existingTodo = await _todoRepository.GetByIdAsync(id);
            if (existingTodo == null) throw new ArgumentException("Task not found");

            existingTodo.Title = title.Trim();
            existingTodo.Description = description.Trim();
            existingTodo.IsCompleted = isCompleted;
            existingTodo.UpdatedAt = DateTime.UtcNow;

            return await _todoRepository.UpdateAsync(existingTodo);
        }

        public async Task<bool> DeleteTodoAsync(int id)
        {
            if (id <= 0) throw new ArgumentException("Id invalid");

            return await _todoRepository.DeleteAsync(id);
        }

    }




}