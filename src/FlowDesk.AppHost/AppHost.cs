var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.FlowDesk_Api>("api");

builder.Build().Run();
