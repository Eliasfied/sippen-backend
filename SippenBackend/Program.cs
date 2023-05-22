using Microsoft.Extensions.Configuration;
using SippenBackend.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SippenDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://127.0.0.1:5173")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});



var app = builder.Build();
app.UseCors("AllowSpecificOrigin");

var sippenApi = app.MapGroup("/api");

app.MapGet("/", () => "Hello World5!");
sippenApi.MapGet("/fragen", async (HttpContext context) =>
{
    using (var scope = context.RequestServices.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<SippenDbContext>();

        var fragen = await dbContext.Frage
            .Include(f => f.Schwierigkeitsgrad)
            .Include(f => f.Kategorie)
            .ToListAsync();

        return Results.Ok(fragen);
    }
});

sippenApi.MapGet("/antworten", async (SippenDbContext dbContext) =>
{
    var antworten = await dbContext.Antwort.ToListAsync();
    return Results.Ok(antworten);
});

app.Run();

