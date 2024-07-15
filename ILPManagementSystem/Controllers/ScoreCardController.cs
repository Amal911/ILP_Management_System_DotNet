using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace ILPManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ScoreCardController: ControllerBase
    {
        private ApiContext _context;

        public ScoreCardController(ApiContext _context)
        {
            this._context = _context;
        }
        [HttpGet]
        public IEnumerable<Scorecard> GetScore() { return _context.Scorecards; }

        [HttpPost]
        public IActionResult PostScore([FromBody] Scorecard scorecard)
        {
            _context.Scorecards.Add(scorecard);
            _context.SaveChanges(); 
            return Ok();    
        }
    }
}
