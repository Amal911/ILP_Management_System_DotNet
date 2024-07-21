using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;

namespace ILPManagementSystem.Repository.IRepository
{
    public interface IDocumentLinksRepository
    {
        Task<IEnumerable<DocumentLinksDTO>> GetAllLinks();
        Task<DocumentLinksDTO> GetAllLinksByAssessmentId(int Id);
    }
}
