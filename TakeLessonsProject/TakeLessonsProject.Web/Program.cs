using Microsoft.EntityFrameworkCore;
using TakeLessons.Business.Abstract;
using TakeLessons.Business.Concrete;
using TakeLessons.Data.Abstract;
using TakeLessons.Data.Concrete.EfCore;
using TakeLessons.Entity;

var builder = WebApplication.CreateBuilder(args);

var sqliteConnection = builder.Configuration.GetConnectionString("SqliteCon");
builder.Services.AddDbContext<MyAppContext>(options => options.UseSqlite(sqliteConnection));

builder.Services.AddScoped<ITeacherService, TeacherManager>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();

builder.Services.AddScoped<IStudentService, StudentManager>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddScoped<IBranchService, BranchManager>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();

builder.Services.AddScoped<IStateOfEducationsLevelService, StateOfEducationsLevelManager>();
builder.Services.AddScoped<IStateOfEducationsLevelRepository, StateOfEducationsLevelRepository>();






builder.Services.AddControllersWithViews();

var app = builder.Build();

//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    app.UseHsts();
//}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();




app.MapControllerRoute(
    name: "teachers",
    pattern: "teachers/{educationLevel?}",
    defaults: new { controller = "Teacher", action = "List" }
);


app.MapControllerRoute(
    name: "teachers",
    pattern: "{url}",
    defaults: new { controller = "Teacher", action = "TeacherDetails" }
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
