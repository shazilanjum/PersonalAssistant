using Microsoft.EntityFrameworkCore;
using PersonalAssistant.Core.Abstractions;
using PersonalAssistant.Core.Entities;
using PersonalAssistant.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAssistant.Application.Repository
{
    public class TodosRepository : ITodoRepository
    {
        private readonly AssistantContext _context;

        public TodoRepository(AssistantContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Todo>> GetTodos()
        {
            return await _context.Todos.AsNoTracking().ToListAsync();
        }
        public async Task<Todo> GetTodoById(int todoId)
        {
            return await _context.Todos
                .AsNoTracking()
                .FirstOrDefaultAsync(t=>t.TaskId == todoId);
        }

        public async Task AddTodo(Todo todo)
        {
            await _context.Todos.AddAsync(todo);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteTodo(Todo todo)
        {
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTodo(Todo todo)
        {
            var todoToUpdate = await _context.Todos.FindAsync(todo);

            if(todoToUpdate is not null)
            {
                todoToUpdate.TaskName = todo.TaskName;
                todoToUpdate.TaskDescription = todo.TaskName;
                todoToUpdate.DoneBefore = todo.DoneBefore;

                await _context.SaveChangesAsync();
            }
        }
    }
}
