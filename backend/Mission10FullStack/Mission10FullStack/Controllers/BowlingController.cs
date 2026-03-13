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
        public IActionResult Get()
        {
            var bowlers = BowlingContext.Bowlers
                .Where(b => b.Team!.TeamName == "Marlins" || b.Team.TeamName == "Sharks")
                .Select(b => new
                {
                    b.BowlerId,
                    b.BowlerFirstName,
                    b.BowlerMiddleInit,
                    b.BowlerLastName,
                    b.BowlerAddress,
                    b.BowlerCity,
                    b.BowlerState,
                    b.BowlerZip,
                    b.BowlerPhoneNumber,
                    b.TeamId,
                    TeamName = b.Team!.TeamName
                })
                .ToList();

            return Ok(bowlers);
        }
    }
}
