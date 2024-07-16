using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace ILPManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BatchTypeController:ControllerBase
    {
        private ApiContext _context;
        public BatchTypeController(ApiContext _context)
        {
            this._context = _context;
        }

        [HttpGet]
        public IEnumerable<BatchType> Get()
        {
            return _context.BatchTypes;
        }

        [HttpPost]
        public IActionResult AddBatchType([FromBody] BatchType batchType)
        {
            _context.BatchTypes.Add(batchType); 
            _context.SaveChanges(); 
            return Ok();
        }
    }
}
