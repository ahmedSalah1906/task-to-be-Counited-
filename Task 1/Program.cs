using Microsoft.EntityFrameworkCore;
using Task_1.Models;
using Task_1.Repository.Billings;
using Task_1.Repository.Customers;
using Task_1.Repository.Employees;
using Task_1.Repository.Items;
using Task_1.Service.Bills;
using Task_1.Service.Customers;
using Task_1.Service.Employees;
using Task_1.Service.Items;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Adding Db Contection String 
builder.Services.AddDbContext<BillingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("cs")));
#region Repository Resolve
builder.Services.AddScoped<IEmployeeRepositry,EmployeeRepository>();
builder.Services.AddScoped<IItemReopsitory,ItemRepository>();
builder.Services.AddScoped<ICustomerRepository,CustomerRepository>();
builder.Services.AddScoped<IBillingRepository,BillingRepository>();
#endregion
#region Service Resolve 
builder.Services.AddScoped<IEmployeeService,EmployeeService>();
builder.Services.AddScoped<ICustomerService,CustomerService>();
builder.Services.AddScoped<IItemService,ItemService>();
builder.Services.AddScoped<IBillingService,BillingService>();
#endregion
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
