using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mongo
{
    public interface IMongoBaseContext
    {
        IMongoClient Client { get; }

        IMongoDatabase Database { get; }
    }
}
