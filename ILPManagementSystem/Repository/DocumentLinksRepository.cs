using AutoMapper;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository.IRepository;

namespace ILPManagementSystem.Repository
{
    public class DocumentLinksRepository:IDocumentLinksRepository
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        private readonly DocumentLinksRepository _documentLinksRepository;
        public DocumentLinksRepository()
        {
            this._context=_context;
            
        }

        public Task<IEnumerable<DocumentLinksDTO>> GetAllLinks()
        {
            throw new NotImplementedException();
        }

        public Task<DocumentLinksDTO> GetAllLinksByAssessmentId(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
