namespace Day2MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(options =>
               options.IdleTimeout = TimeSpan.FromDays(2));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.Use(async (cont, nex) =>
            {
                
                if (cont.Request.Cookies.ContainsKey("ReqNum"))
                {
                    //inc
                    int num = int.Parse(cont.Request.Cookies["ReqNum"]);
                    cont.Response.Cookies.Append("ReqNum", (++num).ToString());
                    switch (num)
                    {
                        case 10:
                            cont.Response.Cookies.Append("Star", "1 star");
                            break;
                        case 20:
                            cont.Response.Cookies.Append("Star", "2 stars");
                            break;
                        case 30:
                            cont.Response.Cookies.Append("Star", "3 stars");
                            break;
                        case 40:
                            cont.Response.Cookies.Append("Star", "4 stars");
                            break;
                        case 50:
                            cont.Response.Cookies.Append("Star", "5 stars");
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    cont.Response.Cookies.Append("ReqNum", "1");
                }
                await nex();
            });
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Employee}/{action=Index}/{id?}");

            app.Run();
        }
    }
}