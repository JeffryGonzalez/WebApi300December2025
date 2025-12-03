var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Employees_Api>("employees-api");

builder.AddProject<Projects.EmployeeManager_Api>("employeemanager-api");

builder.Build().Run();
