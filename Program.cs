using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages(options =>
{
    options.RootDirectory = "/";
    options.Conventions.AddFolderRouteModelConvention(
        "/Features",
        model =>
        {
            foreach (var selector in model.Selectors)
            {
                selector.AttributeRouteModel.Template =
                    selector.AttributeRouteModel.Template.Replace("Features/", "")
                        .Replace("/Pages", "");

            }
        });
});

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapGet(
    "/", context =>
    {
        context.Response.Redirect("/Clients");
        return Task.CompletedTask;
    }
    );

app.Run();