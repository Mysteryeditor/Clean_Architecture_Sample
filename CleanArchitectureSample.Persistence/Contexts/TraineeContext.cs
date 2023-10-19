using CleanArchitectureSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CleanArchitectureSample.Persistence.Contexts
{
    public class TraineeDbContext : DbContext
    {
        public TraineeDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Trainee> trainees { get; set; }
    }
}
