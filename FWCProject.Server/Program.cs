using FCWProject.API;
using FCWProject.Database;

namespace FCWProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DataStorage dataStorage = new();
            ResponseHandler responseHandler = new(dataStorage);
            // Setup Email System

            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            builder.Services.AddHostedService<APICaller>(_ => new APICaller(responseHandler));

            WebApplication app = builder.Build();

            app.MapGet("/data", (HttpContext httpContext) =>
            {
                return dataStorage.GetLatest(10);
            });

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
