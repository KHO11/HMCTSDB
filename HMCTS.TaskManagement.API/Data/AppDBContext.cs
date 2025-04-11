using Microsoft.EntityFrameworkCore;
using HMCTS.TaskManagement.API.Models;

namespace HMCTS.TaskManagement.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<TaskItem> Tasks => Set<TaskItem>();
}
