using Service.Entities;
using Service.Mongo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class TestService : BaseService<Test>
    {
        private readonly IMongoRepository<Test> repository;
        public TestService(IMongoRepository<Test> repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<List<Test>> Get()
        {
            var data = await repository.GetAllAsync();
            return data;
        }
    }
}
