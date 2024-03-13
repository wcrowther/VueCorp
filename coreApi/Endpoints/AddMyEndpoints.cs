using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace coreApi.Endpoints
{
    public static class AddEndpoints
    {
        public static void AddMyEndpoints(this WebApplication app)
        {
            app.WeatherEndpoints();
            app.AuthenticateEndpoints();
            app.AccountEndpoints();
            app.UsersEndpoints();
        }
    }
}
