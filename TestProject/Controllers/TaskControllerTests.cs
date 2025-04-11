using Xunit;
using HMCTS.TaskManagement.API.Controllers;
using HMCTS.TaskManagement.API.Data;
using HMCTS.TaskManagement.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HMCTS.TaskManagement.API.Tests.Controllers;

public class TasksControllerTests
{
    private readonly TasksController _controller;
    private readonly AppDbContext _context;

    public TasksControllerTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "HMCTSDB")
            .Options;

        _context = new AppDbContext(options);
        _controller = new TasksController(_context);
    }

    [Fact]
    public async Task GetTasks_ReturnsAllTasks()
    {
        // Arrange
        _context.Tasks.Add(new TaskItem { Title = "Test Task 1", DueDate = DateTime.Now });
        _context.Tasks.Add(new TaskItem { Title = "Test Task 2", DueDate = DateTime.Now });
        await _context.SaveChangesAsync();

        // Act
        var result = await _controller.GetTasks();

        // Assert
        var tasks = Assert.IsType<List<TaskItem>>(result.Value);
        Assert.Equal(2, tasks.Count);
    }

    [Fact]
    public async Task CreateTask_ReturnsCreatedTask()
    {
        var task = new TaskItem { Title = "New Task", DueDate = DateTime.Now };

        var result = await _controller.CreateTask(task);

        var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
        var createdTask = Assert.IsType<TaskItem>(createdResult.Value);
        Assert.Equal(task.Title, createdTask.Title);
    }
}
