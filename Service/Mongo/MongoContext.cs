using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mongo
{
    public class MongoContext : IMongoBaseContext
    {
        public IMongoClient Client { get; }

        public IMongoDatabase Database { get; }

        //IMongoClient IMongoBaseContext.Client => throw new NotImplementedException();

        //IMongoDatabase IMongoBaseContext.Database => throw new NotImplementedException();

        public MongoContext()
        {
            Client = new MongoClient(AppSettings.MongoSettings.ConnectionString);
            Database = Client.GetDatabase(AppSettings.MongoSettings.DatabaseName);
        }
    }
}
