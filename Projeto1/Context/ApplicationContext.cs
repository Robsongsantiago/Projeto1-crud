using Microsoft.EntityFrameworkCore;
using Projeto1.Models;

namespace Projeto1.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<Aluno> alunos { get; set; }
    }
}
