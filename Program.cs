using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //builder.Services.AddRazorPages();
            //builder.Services.AddRazorPages(options =>
            //{
            //    options.RootDirectory = "/";
            //    options.Conventions.AddFolderRouteModelConvention("/Features",
            //        model =>
            //        {
            //            foreach (var selector in model.Selectors)
            //            {
            //                selector.AttributeRouteModel.Template = selector.AttributeRouteModel.Template
            //                    .Replace("Features/", "")
            //                    .Replace("/Pages", "");
            //            }
            //        });
            //});

            //builder.Services.AddRazorPages(options => { 
            //    options.RootDirectory = "/";
            //    options.Conventions.AddPageRoute("/Pages/Index", "/");
            //    options.Conventions.AddPageRoute("/Pages/Privacy", "Privacy");
            //    options.Conventions.AddPageRoute("/Features/Clients/Pages/Index","Clients");
            //    options.Conventions.AddPageRoute("/Features/Clients/Pages/Test","Clients/Test");
            //} );

            builder.Services.AddRazorPages(options => {
                options.RootDirectory = "/Pages/Features";
                options.Conventions.AddPageRoute("/Pages/Index", "/");
                options.Conventions.AddPageRoute("/Pages/Privacy", "Privacy");
                options.Conventions.AddPageRoute("/Pages/Clients/Index", "Clients");
                options.Conventions.AddPageRoute("/Pages/Clients/Test", "Clients/Test");

                options.RootDirectory = "/";
                options.Conventions.AddFolderRouteModelConvention("/Features",
                    model =>
                    {
                        foreach (var selector in model.Selectors)
                        {
                            selector.AttributeRouteModel.Template = selector.AttributeRouteModel.Template
                                .Replace("Features/", "")
                                .Replace("/Pages", "");
                        }
                    });
            });

            //builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages()
                .WithStaticAssets();

            //app.MapGet("/",
            //    context =>
            //    {
            //        context.Response.Redirect("/Clients");
            //        return Task.CompletedTask;
            //    });
            app.Run();
