using PersonalAssistant.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAssistant.Core.Abstractions
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetTodos();
        Task<Todo> GetTodoById(int todoId);
        Task AddTodo(Todo todo);
        Task DeleteTodo(Todo todo);
        Task UpdateTodo(Todo todo);
    }
}
