using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Entities;
using Service.Service;

namespace JoinChatApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly TestService service;

        public TestController(TestService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<List<Test>> Get()
        {
            return await service.Get();
        }
    }
}
