using AutoMapper;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ILPManagementSystem.Services;

public class CreateBatchService:ICreateBatchService
{
    private readonly BatchRepository _batchRepository;
    private readonly IMapper _mapper;
    private readonly BatchPhaseRepository _batchPhaseRepository;
    private readonly PhaseAssessmentTypeMappingRepository _phaseAssessmentTypeMappingRepository;
    private readonly ApiContext _context;
    public CreateBatchService(BatchRepository batchRepository, IMapper mapper, BatchPhaseRepository batchPhaseRepository , PhaseAssessmentTypeMappingRepository phaseAssessmentTypeMappingRepository,ApiContext _context)
    {
        this._mapper = mapper;
        this._batchRepository = batchRepository;
        this._batchPhaseRepository = batchPhaseRepository;
        this._phaseAssessmentTypeMappingRepository = phaseAssessmentTypeMappingRepository;
        this._context = _context;

    }
    public async Task CreateNewBatch(CreateBatchDTO batchDetails, IEnumerable<CreateBatchPhaseDTO> batchPhaseDetails)
    {
        Batch newBatch = _mapper.Map<Batch>(batchDetails);
        newBatch.IsActive = true;

        int batchId = await _batchRepository.AddNewBatch(newBatch);

        foreach (var phase in batchPhaseDetails)
        {
            BatchPhase batchPhase = new BatchPhase
            {
                NumberOfDays = phase.NumberOfDays,
                StartDate = phase.StartDate,
                EndDate = phase.EndDate,
                IsCompleted = phase.IsCompleted,
                BatchId = batchId,
                PhaseId = phase.PhaseId,
            };

            int batchPhaseId = await _batchPhaseRepository.AddNewBatchPhase(batchPhase);

            foreach (var phaseAssessment in phase.PhaseAssessmentMapping)
            {
                PhaseAssessmentTypeMapping phaseAssessmentType = new PhaseAssessmentTypeMapping
                {
                    Weightage = phaseAssessment.Weightage,
                    AssessmentTypeId = phaseAssessment.AssessmentTypeId,
                    BatchPhaseId = batchPhaseId,
                };

                await _phaseAssessmentTypeMappingRepository.AddPhaseAssessmentMapping(phaseAssessmentType);
            }
        }
    }

    public async Task CreateNewBatch2(CreateBatchDTO batchDetails, IEnumerable<CreateBatchPhaseDTO> batchPhaseDetails)
    {
        Batch newBatch = _mapper.Map<Batch>(batchDetails);
        _context.Batchs.Add(newBatch);
        _context.SaveChanges();


/*        int batchId = await _batchRepository.AddNewBatch(newBatch);
*/
        foreach (var phase in batchPhaseDetails)
        {
            BatchPhase batchPhase = new BatchPhase
            {
                NumberOfDays = phase.NumberOfDays,
                StartDate = phase.StartDate,
                EndDate = phase.EndDate,
                IsCompleted = phase.IsCompleted,
                BatchId = newBatch.Id,
                PhaseId = phase.PhaseId,
            };

            _context.BatchPhase.Add(batchPhase);
            _context.SaveChanges();



/*            int batchPhaseId = await _batchPhaseRepository.AddNewBatchPhase(batchPhase);
*/
            foreach (var phaseAssessment in phase.PhaseAssessmentMapping)
            {
                PhaseAssessmentTypeMapping phaseAssessmentType = new PhaseAssessmentTypeMapping
                {
                    Weightage = phaseAssessment.Weightage,
                    AssessmentTypeId = phaseAssessment.AssessmentTypeId,
                    BatchPhaseId = batchPhase.Id,
                };
                _context.PhaseAssessmentTypeMappings.Add(phaseAssessmentType);
                _context.SaveChanges() ;    

/*                await _phaseAssessmentTypeMappingRepository.AddPhaseAssessmentMapping(phaseAssessmentType);
*/            }
        }
    }
}
