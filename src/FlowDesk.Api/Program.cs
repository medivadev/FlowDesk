using FlowDesk.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// 1. Add CORS so our React app (Vite runs on 5173 usually) can call the API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // Update this if your Vite port is different
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("AllowFrontend");

// 2. Setup our Dummy Data Store directly in the API for now
var dummyTasks = new List<TaskDto>
{
    new("FD-1", "Set up Vite and React bbbbbbbbb", "done", "EA"),
    new("FD-2", "Create layout shell bbbbb", "done", "EA"),
    new("FD-3", "Build Kanban board bbbbbb", "in-progress", "EA"),
    new("FD-4", "Connect to .NET Web API bbbbbbbbb", "todo", "EA")
};

var api = app.MapGroup("/api/tasks").RequireCors("AllowFrontend");

// GET /api/tasks
api.MapGet("/", () => Results.Ok(dummyTasks));

// POST /api/tasks
api.MapPost("/", (CreateTaskRequest request) =>
{
    var newId = $"FD-{dummyTasks.Count + 1}";
    var newTask = new TaskDto(newId, request.Title, "todo", request.Assignee);
    dummyTasks.Add(newTask);

    return Results.Created($"/api/tasks/{newId}", newTask);
});

// PUT /api/tasks/{id}/status
api.MapPut("/{id}/status", (string id, UpdateTaskStatusRequest request) =>
{
    var task = dummyTasks.FirstOrDefault(t => t.Id == id);
    if (task == null) return Results.NotFound();

    // In a real app with immutable records, we'd replace the item in the list/db
    var updatedTask = task with { Status = request.Status };
    var index = dummyTasks.IndexOf(task);
    dummyTasks[index] = updatedTask;

    return Results.Ok(updatedTask);
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Endpoints
app.MapEndpoints();

app.Run();


// DTOs for our Minimal API
public record TaskDto(string Id, string Title, string Status, string Assignee);
public record CreateTaskRequest(string Title, string Assignee);
public record UpdateTaskStatusRequest(string Status);
