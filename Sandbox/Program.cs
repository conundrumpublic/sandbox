using Sandbox.Data;
using Sandbox.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<Context>(builder.Configuration["ConnectionStrings:DefaultConnection"]);
builder.Services.AddTransient<UserRepository>();
builder.Services.AddCors(s => s.AddPolicy("local", b => b.SetPreflightMaxAge(new TimeSpan(20, 0, 0, 0))
            .WithOrigins($"http://localhost:5173")
            .WithHeaders(["Authorization", "Content-Type", "Accept", "Origin", "User-Agent", "Cache-Control", "Keep-Alive", "X-Requested-With", "If-Modified-Since"])
            .WithMethods(["GET", "PUT", "OPTIONS", "POST", "DELETE"])
            .AllowCredentials()));
builder.Services.AddControllers();
var app = builder.Build();
app.UseRouting();
app.UseCors("local");
app.UseEndpoints(e =>
{
    e.MapControllers();
    e.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();