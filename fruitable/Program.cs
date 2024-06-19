using Fruitable.Data;
using Fruitable.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddApplicationServices();

var app = builder.Build();

// Initialize database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        DbInitializer.InitializeAsync(services).Wait();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();
// Custom middleware to intercept unauthorized requests and handle them
app.Use(async (context, next) =>
{
    if (!context!.User!.Identity!.IsAuthenticated && Extensions.IsAjaxRequest(context.Request))
    {
        // If it's an AJAX request and user is not authenticated, return 401 Unauthorized
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        await context.Response.WriteAsync("Unauthorized");
    }
    else
    {
        await next(); // Continue to the next middleware
    }
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();

