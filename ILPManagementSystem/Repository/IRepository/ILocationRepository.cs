using ILPManagementSystem.Models;

namespace ILPManagementSystem.Repository.IRepository
{
    public interface ILocationRepository
    {
        Task<IEnumerable<Location>> GetAllLocationsAsync();
        Task AddNewLocation(Location location);
    }
}
