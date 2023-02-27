using SmartCard_API.Interfaces;
using SmartCard_API.Services;
using SmartCard_API.Workers;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

//var builder = WebApplication.CreateBuilder(args);



//---// For Running on Windows services
var webApplicationOptions = new WebApplicationOptions()
{
    Args = args,
    ContentRootPath = AppContext.BaseDirectory,
    ApplicationName = System.Diagnostics.Process.GetCurrentProcess().ProcessName
};
var builder = WebApplication.CreateBuilder(webApplicationOptions);
builder.Host.UseWindowsService();


var path = builder.Configuration["ConnectionFolder"];

if (!Directory.Exists(path))
    Directory.CreateDirectory(path!);


//// Add services to the container.
//builder.Services.AddHostedService<ConfirmWorker>();

builder.Services.AddTransient<ISystemIO, SystemIO>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors(options => options.AddPolicy(name: MyAllowSpecificOrigins, builder =>
{
    builder.WithOrigins("http://localhost:8080", "*")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed((host) => true)
    .AllowCredentials();

}));



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (!app.Environment.IsDevelopment())
{

    builder.WebHost.UseUrls(builder.Configuration["UseUrls"]!);

}

app.UseAuthorization();

app.MapControllers();

app.Run();