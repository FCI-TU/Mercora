using FindIt.Server;
using FindIt.Server.ServicesExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddApplicationDependencies();

var app = builder.Build();

app.UseSwaggerMiddleware();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();


app.Run();
