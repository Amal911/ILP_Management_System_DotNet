using AutoMapper;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ILPManagementSystem.Repository
{
    public class BatchTypeRepository:IBatchTypeRepository
    {
        private readonly ApiContext _context;

        public BatchTypeRepository(ApiContext _context)
        {
            this._context = _context;
        }

        public async Task<IEnumerable<BatchType>> GetBatchTypeData()
        {
            return this._context.BatchTypes;
        }

        public async Task AddBatchType(BatchType batchType)
        {
            _context.BatchTypes.Add(batchType);
            _context.SaveChanges();
        }

        public async Task DeleteBatchType(int id)
        {
             _context.BatchTypes.Remove( _context.BatchTypes.Find(id));
            _context.SaveChanges();
        }
    }
}
