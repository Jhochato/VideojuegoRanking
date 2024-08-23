using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using VideojuegoRanking.Application.Interfaces;

namespace VideojuegoRanking.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RankingController : ControllerBase
    {
        private readonly IRankingService _rankingService;

        public RankingController(IRankingService rankingService)
        {
            _rankingService = rankingService;
        }

        [HttpGet("GenerateCsv")]
        public async Task<IActionResult> GenerateCsv([FromQuery] int top)
        {
            var validationResult = await _rankingService.ValidateTop(top);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var csv = await _rankingService.GenerateRankingCsv(top);
            return File(Encoding.UTF8.GetBytes(csv), "text/csv", "Ranking.csv");
        }
    }
}
