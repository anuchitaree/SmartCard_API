using SmartCard_API.Workers;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);



//---// For Running on Windows services
//var webApplicationOptions = new WebApplicationOptions()
//{
//    Args = args,
//    ContentRootPath = AppContext.BaseDirectory,
//    ApplicationName = System.Diagnostics.Process.GetCurrentProcess().ProcessName
//};
//var builder = WebApplication.CreateBuilder(webApplicationOptions);
//builder.Host.UseWindowsService();




//var connectionFolder = builder.Configuration["ConnectionFolder"];
//if (!File.Exists(connectionFolder))
//    Directory.CreateDirectory(connectionFolder);

//// Add services to the container.
//builder.Services.AddHostedService<ConfirmWorker>();

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

    builder.WebHost.UseUrls(builder.Configuration["UseUrls"]);

}

app.UseAuthorization();

app.MapControllers();

app.Run();