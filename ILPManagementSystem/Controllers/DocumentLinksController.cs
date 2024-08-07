using AutoMapper;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ILPManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class DocumentLinksController:ControllerBase
    {
        private readonly IMapper _mapper; 
        private readonly DocumentLinksRepository _documentLinksRepository;

        public DocumentLinksController(IMapper _mapper,DocumentLinksRepository _documentLinksRepository)
        {
            this._mapper = _mapper;
            this._documentLinksRepository = _documentLinksRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentLinks>>> GetAllDocumentLinks()
        {
            return Ok(await _documentLinksRepository.GetAllLinks());

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentLinks>> GetDocumentsByAssessmentId(int id)
        {
            var documentLinks = await _documentLinksRepository.GetAllLinksByAssessmentId(id);
            if (documentLinks == null)
            {
                return NotFound();
            }
            var documentLinksDTO = _mapper.Map<DocumentLinksDTO>(documentLinks);
            return Ok(documentLinksDTO);
        }
        
    }
}
