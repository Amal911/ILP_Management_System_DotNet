using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ILPManagementSystem.Repository
{
    public class LocationRepository:ILocationRepository
    {
        private ApiContext _context;
        public LocationRepository(ApiContext _context ) {
            this._context = _context;
        }

        public async Task<IEnumerable<Location>> GetAllLocationsAsync()
        {
            return this._context.Locations;
        }
        public async Task AddNewLocation(Location location)
        {
            _context.Locations.Add( location );
            await _context.SaveChangesAsync();
            
        }
    }
}
