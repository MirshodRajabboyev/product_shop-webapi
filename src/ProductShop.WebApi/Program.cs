using ProductShop.WebApi.Configurations.Layers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();
builder.ConfigureCORSPolicy(); 

builder.ConfigureDataAccess();
builder.ConfigureServiceLayer();
builder.ConfigureWeb();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseCors("AllowAll");
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
