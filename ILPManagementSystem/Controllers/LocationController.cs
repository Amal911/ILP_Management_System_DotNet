using AutoMapper;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;


namespace ILPManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LocationController : ControllerBase
    {
        private ApiContext _context;
        private LocationRepository _locationRepository;
        private IMapper _mapper;
        public LocationController(ApiContext _context,IMapper _mapper, LocationRepository _locationRepository)
        {
            this._context = _context;
            this._locationRepository = _locationRepository;
            this._mapper = _mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetAllLocation()
        {
            return Ok(await _locationRepository.GetAllLocationsAsync());
        }
        [HttpPost] 
        public async Task<ActionResult> AddNewLocation([FromBody] Location location) 
        {
            await _locationRepository.AddNewLocation(location);
            return Ok();
        }
    }
}
