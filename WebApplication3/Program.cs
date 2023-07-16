using WebApplication3.DAL;
using WebApplication3.DTO;
using WebApplication3.BL;
namespace WebApplication3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/user", () =>
            {
                UserManager userManager = new UserManager();
                return userManager.FindAll();
            });
            app.MapGet("/user/{id}", (int id) =>
            {
                UserManager userManager = new UserManager();
                return userManager.FindId(id);
            });
            app.MapPost("/user", (User u) =>
            {
                UserManager userManager = new UserManager();
                return userManager.AddNew(u);
            });
            app.MapPut("/user/{id}/{fullname}", (int id, string fullname) =>
            {
                UserManager userManager = new UserManager();
                return userManager.UpdateFullname(id, fullname);
            });
            app.Run();
        }
    }
}