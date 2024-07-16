using Bootcamp.Application;
using Bootcamp.Infrastructure;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddMemoryCache();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(configure =>
    {
        configure.AllowAnyHeader();
        configure.AllowAnyMethod();
        configure.AllowAnyOrigin();
    });
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        options.DisplayRequestDuration();
        options.RoutePrefix = string.Empty;
        options.DefaultModelsExpandDepth(-1);
        options.DocumentTitle = "Bootcamp-Api";
        options.DocExpansion(DocExpansion.None);
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();