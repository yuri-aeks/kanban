using Kanban.API.Authentication;
using Kanban.API.Configurations;
using Kanban.CrossCutting;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddServices();
builder.AddRepository();
builder.Services.AddSwagger();
builder.Services.AddAuthentication()
    .AddScheme<AuthenticationSchemeOptions, CustomAuthenticationHandler>(
        Constants.Authentication, null
    );
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseAuthorization();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
