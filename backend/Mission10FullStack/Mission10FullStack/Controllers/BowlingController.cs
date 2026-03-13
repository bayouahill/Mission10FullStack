using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mission10FullStack.Data;

namespace Mission10FullStack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BowlingController : ControllerBase
    {
        private BowlingDbContext BowlingContext;

        public BowlingController(BowlingDbContext someName)
        {
            BowlingContext = someName;
        }

        [HttpGet(Name = "GetBowlingData")]
        public IEnumerable<string> Get()
        {
            
            return new string[]
            {
                "Bowling", "Controller"
            };
        }
    }
}
