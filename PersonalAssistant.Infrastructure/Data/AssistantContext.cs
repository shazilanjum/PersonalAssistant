using Microsoft.EntityFrameworkCore;
using PersonalAssistant.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAssistant.Infrastructure.Data
{
    public class AssistantContext : DbContext
    {
        public AssistantContext(DbContextOptions<AssistantContext> options) : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }
    }
}
