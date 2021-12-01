using ClassLibrary1.Data;
using ClassLibrary1.Models;
using ClassLibrary1.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ITenantProvider, TenantProvider>();

string constr = builder.Configuration.GetConnectionString("constr");
builder.Services.AddSqlServer<StudentContext>(constr);

WebApplication app = builder.Build();

app.MapGet("/student", (StudentContext context) =>
{
    IList<Student> students = context.Students.OrderBy(s => s.Id).ToList();
    return Results.Ok(students);
});

app.Run();