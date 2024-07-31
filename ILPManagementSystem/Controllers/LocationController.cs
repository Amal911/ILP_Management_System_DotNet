using AutoMapper;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Repository;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;


namespace ILPManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LocationController : ControllerBase
    {
        private ILocationRepository _locationRepository;
        private IMapper _mapper;
        public LocationController(IMapper _mapper, ILocationRepository _locationRepository)
        {
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
