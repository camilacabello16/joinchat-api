using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.Mongo;

namespace Service
{
    public static class AppSettings
    {
        public static MongoSettings MongoSettings { get; set; }
        public static IConfiguration Keys { get; set; }
        public static void Init(IServiceCollection services, IConfiguration configuration)
        {
            MongoSettings = configuration.GetSection("MongoSettings").Get<MongoSettings>();
            Keys = configuration.GetSection("AppSettings");
        }
    }
}
