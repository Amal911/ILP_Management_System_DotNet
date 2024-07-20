using AutoMapper;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ILPManagementSystem.Repository
{
    public class BatchRepository:IBatchRepository
    {
        private readonly ApiContext _context;
        private readonly IBatchRepository _batchRepository;
        private readonly IMapper _mapper;

        public BatchRepository(ApiContext _context)
        {
            this._context = _context;
        }
        public async Task<IEnumerable<Batch>> GetBatchData()
        {
            return _context.Batchs.Include(e=>e.Location);

        }
        public async Task<IEnumerable<BatchDTO>> GetDetailedBatchData()
        {
            var BatchData = await (from  batch in _context.Batchs 
                                   join batchType in _context.BatchTypes on batch.batchId equals batchType.Id
                                   join location in _context.Locations on batch.LocationId equals location.Id
                                   select new BatchDTO
                                   {
                                       Id = batch.Id,
                                       BatchName = batch.BatchName,
                                       BatchCode = batch.BatchCode,
                                       BatchDuration = batch.BatchDuration,
                                       batchId = batch.Id,
                                       BatchType = batchType.BatchTypeName,
                                       StartDate = batch.StartDate,
                                       EndDate = batch.EndDate,
                                       ProgramId = batch.ProgramId,
                                       LocationId = batch.LocationId,
                                       LocationName = location.LocationName,
                                       IsActive = batch.IsActive,
                                   }
                                   ).ToListAsync();
            return BatchData;

        }
        public async Task<IEnumerable<BatchDTO>> GetBatchDetailById(int Id)
        {
            var BatchData = await (from batch in _context.Batchs
                                   join batchType in _context.BatchTypes on batch.batchId equals batchType.Id
                                   join location in _context.Locations on batch.LocationId equals location.Id
                                   where batch.Id == Id
                                   select new BatchDTO
                                   {
                                       Id = batch.Id,
                                       BatchName = batch.BatchName,
                                       BatchCode = batch.BatchCode,
                                       BatchDuration = batch.BatchDuration,
                                       batchId = batch.Id,
                                       BatchType = batchType.BatchTypeName,
                                       StartDate = batch.StartDate,
                                       EndDate = batch.EndDate,
                                       ProgramId = batch.ProgramId,
                                       LocationId = batch.LocationId,
                                       LocationName = location.LocationName,
                                       IsActive = batch.IsActive,
                                   }
                                   ).ToListAsync(); 
            return BatchData;

        }
        public async Task AddNewBatch(Batch batch)
        {
            _context.Batchs.Add( batch );
            _context.SaveChanges();
        }
    }
}
