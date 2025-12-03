using Employees.Api;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(c =>
{
    c.AddDocumentTransformer<CustomDocumentTransformer>();
});
builder.Services.AddValidation();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();



app.MapGet("/employees", () =>
{
    List<EmployeeInfo> employees = [
        new EmployeeInfo(1, "Bob Smith", "555-1212"),
        new EmployeeInfo(2, "Renee Jones", "555-1212")
        ];
    return TypedResults.Ok(employees);
});

app.MapGet("/employees/{id:int}", (int id) =>
{
   
    return new EmployeeInfo(id, "Bob Jones", "555-1212");
});



app.MapPost("/employees", (EmployeeCreateRequest request) =>
{


    var response = new EmployeeInfo(new Random().Next(100, 1000), request.Name, request.Phone);
    return TypedResults.Ok(response);
});


app.MapPost("/v2/employees", (EmployeeCreateRequest2 request) =>
{

    var response = new EmployeeInfo(new Random().Next(100, 1000), request.Name, request.Phone);
    return TypedResults.Ok(response);
});
app.MapDefaultEndpoints();
app.Run();


/// <summary>
/// This is information about an employee
/// </summary>
/// <param name="Id"></param>
/// <param name="Name"></param>
/// <param name="Phone">Their work phone number</param>
public record EmployeeInfo(
    
    int Id, [property:MaxLength(50), MinLength(3)]string Name, string Phone);


/// <summary>
/// This is used to create an Employee
/// </summary>
public record EmployeeCreateRequest
{
    [Required, MinLength(3), MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    // add a regex or something for phone, whateer
    public string Phone { get; set; } = string.Empty;

}

public record EmployeeCreateRequest2
{
    [Required, MinLength(3), MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    // add a regex or something for phone, whateer
    public string Phone { get; set; } = string.Empty;

    [Required]
    public required string EyeColor { get; set; }

}