using DataLibrary.Data;
using DataLibrary.Db;
using MyBudgetTrackerApp.Exceptions;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
    .WriteTo.Seq("http://localhost:5341")  //  Send logs to Seq
    .Enrich.FromLogContext()
    .MinimumLevel.Error()
    .CreateLogger();

Log.Information("Starting up the Budget Tracker App");
var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog(); // Plug Serilog into the host

// Add services to the container.
builder.Services.AddControllersWithViews();

//[+]Custom Services
builder.Services.AddSingleton(new ConnectionStringData
{
    SqlConnectionName = "Default"
});
builder.Services.AddSingleton<IDataAccess, SqlDb>();
builder.Services.AddSingleton<IBankBalanceData, BankBalanceData>();
builder.Services.AddSingleton<IExpenseData, ExpenseData>();
//[-]Custom Services

//[+]Exception Handling
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
//[-]Exception Handling

var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

if (app.Environment.IsDevelopment())
{
    // And in your pipeline
    app.UseExceptionHandler();
}
else
{
    app.UseExceptionHandler("/error"); // Redirects to /error endpoint
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
