using AutoMapper;
using DotNetEnv;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace ILPManagementSystem.Repository;

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
        return _context.Batchs.Include(e => e.Location).Include(u => u.BatchType).Include(u => u.BatchPhases).Include(b=>b.Program);

    }

    [HttpGet]
    public async Task<IEnumerable<object>> GetBatches()
    {
        var batchData = await _context.Batchs
            .Include(b=>b.Program)
            .Include(b => b.Location)
            .Include(b => b.BatchType)
            .Include(b=>b.TraineeList).ThenInclude(t=>t.User)
            .Include(b => b.BatchPhases)
                .ThenInclude(bp => bp.PhaseAssessmentTypeMappings)
                    .ThenInclude(patm => patm.AssessmentType)
            .Select(b => new
            {
                id = b.Id,
                batchName = b.BatchName,
                batchCode = b.BatchCode,
                batchDuration = b.BatchDuration,
                startDate = b.StartDate,
                endDate = b.EndDate,
                isActive = b.IsActive,
                programId = b.ProgramId,
                proogram = b.Program.ProgramName,
                locationId = b.LocationId,
                traineeCount = b.TraineeList.Count,
                traineeList = b.TraineeList.Select(tr => new
                {
                    tr.User.Id,
                    tr.User.FirstName,
                    tr.User.LastName,
                    tr.User.EmailId,
                    tr.User.Gender,
                    tr.User.MobileNumber
                } 
                ).ToList(),
                location = new
                {
                    id = b.Location.Id,
                    locationName = b.Location.LocationName
                },
                batchTypeId = b.BatchTypeId,
                batchType = new
                {
                    id = b.BatchType.Id,
                    batchTypeName = b.BatchType.BatchTypeName
                },
                batchPhases = b.BatchPhases.Select(bp => new
                {
                    id = bp.Id,
                    numberOfDays = bp.NumberOfDays,
                    startDate = bp.StartDate,
                    endDate = bp.EndDate,
                    status = (Status)bp.Status,
                    batchId = bp.BatchId,
                    phaseId = bp.PhaseId,

                   
                    phaseAssessmentTypeMappings = bp.PhaseAssessmentTypeMappings.Select(patm => new
                    {
                        id = patm.Id,
                        weightage = patm.Weightage,
                        assessmentTypeId = patm.AssessmentTypeId,
                        assessmentType = new
                        {
                            id = patm.AssessmentType.Id,
                            assessmentTypeName = patm.AssessmentType.AssessmentTypeName
                        },
                        batchPhaseId = patm.BatchPhaseId
                    }).ToList()
                }).ToList()
            })
            .ToListAsync();

        return batchData;
    }


    /*    public async Task<IEnumerable<Batch>> GetBatchData()
        {

            var batchData =  _context.Batchs
    .Include(b => b.Location)
    .Include(b => b.BatchType)
    .Include(b => b.BatchPhases)
        .ThenInclude(bp => bp.Phase)
    .Include(b => b.BatchPhases)
        .ThenInclude(bp => bp.PhaseAssessmentTypeMappings)
    .Select(b => new
    {
        id = b.Id,
        batchName = b.BatchName,
        batchCode = b.BatchCode,
        batchDuration = b.BatchDuration,
        startDate = b.StartDate,
        endDate = b.EndDate,
        isActive = b.IsActive,
        programId = b.ProgramId,
        locationId = b.LocationId,
        location = new
        {
            id = b.Location.Id,
            locationName = b.Location.LocationName
        },
        batchTypeId = b.BatchTypeId,
        batchType = new
        {
            id = b.BatchType.Id,
            batchTypeName = b.BatchType.BatchTypeName
        },
        batchPhases = b.BatchPhases.Select(bp => new
        {
            id = bp.Id,
            numberOfDays = bp.NumberOfDays,
            startDate = bp.StartDate,
            endDate = bp.EndDate,
            isCompleted = bp.IsCompleted,
            batchId = bp.BatchId,
            phaseId = bp.PhaseId,
            phaseAssessmentTypeMappings = bp.PhaseAssessmentTypeMappings.Select(patm => new
            {
                id = patm.Id,
                weightage = patm.Weightage,
                assessmentTypeId = patm.AssessmentTypeId,
                batchPhaseId = patm.BatchPhaseId
            }).ToList()
        }).ToList()
    }).ToList();

            return batchData;

        }
    */

    public async Task<IEnumerable<BatchDTO>> GetDetailedBatchData()
    {
        var BatchData = await (from  batch in _context.Batchs 
                               join batchType in _context.BatchTypes on batch.BatchTypeId equals batchType.Id
                               join location in _context.Locations on batch.LocationId equals location.Id
                               select new BatchDTO
                               {
                                   Id = batch.Id,
                                   BatchName = batch.BatchName,
                                   BatchCode = batch.BatchCode,
                                   BatchDuration = batch.BatchDuration,
                                   batchTypeId = batch.Id,
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
    public async Task<IEnumerable<object>> GetBatchDetailById(int Id)
    {
        var batchData = await _context.Batchs.Where(u=>u.Id==Id)
            .Include(b => b.Program)
            .Include(b => b.Location)
            .Include(b => b.BatchType)
            .Include(b => b.TraineeList).ThenInclude(t => t.User)
            .Include(b => b.BatchPhases).ThenInclude(bp => bp.Phase)
                .Include(b => b.BatchPhases).ThenInclude(bp => bp.PhaseAssessmentTypeMappings)
                    .ThenInclude(patm => patm.AssessmentType)
            .Select(b => new
            {
                id = b.Id,
                batchName = b.BatchName,
                batchCode = b.BatchCode,
                batchDuration = b.BatchDuration,
                startDate = b.StartDate,
                endDate = b.EndDate,
                isActive = b.IsActive,
                programId = b.ProgramId,
                proogram = b.Program.ProgramName,
                locationId = b.LocationId,
                traineeCount = b.TraineeList.Count,
                traineeList = b.TraineeList.Select(tr => new
                {
                    tr.User.Id,
                    tr.User.FirstName,
                    tr.User.LastName,
                    tr.User.EmailId,
                    tr.User.Gender,
                    tr.User.MobileNumber
                }
                ).ToList(),
                location = new
                {
                    id = b.Location.Id,
                    locationName = b.Location.LocationName
                },
                batchTypeId = b.BatchTypeId,
                batchType = new
                {
                    id = b.BatchType.Id,
                    batchTypeName = b.BatchType.BatchTypeName
                },
                batchPhases = b.BatchPhases.Select(bp => new
                {
                    id = bp.Id,
                    numberOfDays = bp.NumberOfDays,
                    startDate = bp.StartDate,
                    endDate = bp.EndDate,
                    status = bp.Status,
                    batchId = bp.BatchId,
                    phaseId = bp.PhaseId,
                    phaseName = bp.Phase.PhaseName,
                    phase = new
                    {
                        id = bp.Phase.Id,
                        phaseName = bp.Phase.PhaseName,
                    },
                    phaseAssessmentTypeMappings = bp.PhaseAssessmentTypeMappings.Select(patm => new
                    {
                        id = patm.Id,
                        weightage = patm.Weightage,
                        assessmentTypeId = patm.AssessmentTypeId,
                        assessmentType = new
                        {
                            id = patm.AssessmentType.Id,
                            assessmentTypeName = patm.AssessmentType.AssessmentTypeName
                        },
                        batchPhaseId = patm.BatchPhaseId
                    }).ToList()
                }).ToList()
            })
            .ToListAsync();
        return batchData;

    }
    
    public async Task<int> AddNewBatch(Batch batch)
    {
        _context.Batchs.Add( batch );
        _context.SaveChanges();
        return batch.Id;
    }
    public async Task<IEnumerable<object>> GetBatchByProgram(int programId)
    {
        var batchList = _context.Batchs.Where(u => u.ProgramId == programId).Include(b => b.TraineeList).ThenInclude(t => t.User)
            .Select(b => new
            {
                b.Id,
                b.BatchName,
                b.BatchCode,
                b.BatchDuration,
                b.StartDate,
                b.EndDate,
                b.IsActive,
                traineeCount = b.TraineeList.Count
            })
            .ToList();
        return batchList;
    }

    public async Task<IEnumerable<object>> GetBatchTraineeList(int Id)
    {
        var batchData = await _context.Batchs.Where(u=>u.Id==Id)
           .Include(b => b.Program)
           .Include(b => b.TraineeList).ThenInclude(t => t.User)
           .Select(b => new
           {
               id = b.Id,
               batchName = b.BatchName,
               batchCode = b.BatchCode,
               proogram = b.Program.ProgramName,
               traineeCount = b.TraineeList.Count,
               traineeList = b.TraineeList.Select(tr => new
               {
                   tr.User.Id,
                   tr.User.FirstName,
                   tr.User.LastName,
                   tr.User.EmailId,
                   tr.User.Gender,
                   tr.User.MobileNumber
               }
               ).ToList(),
           })
           .ToListAsync();

        return batchData;
    }
    public async Task UpdateBatchAsync(UpdateBatchRequestDTO updateBatchRequest)
    {
        var batch = await _context.Batchs
            .Include(b => b.BatchPhases)
                .ThenInclude(bp => bp.PhaseAssessmentTypeMappings)
            .FirstOrDefaultAsync(b => b.Id == updateBatchRequest.Id);

        if (batch == null)
        {
            throw new KeyNotFoundException("Batch not found");
        }

        batch.BatchName = updateBatchRequest.BatchName;
        batch.BatchCode = updateBatchRequest.BatchCode;
        batch.BatchDuration = updateBatchRequest.BatchDuration;
        batch.StartDate = updateBatchRequest.StartDate;
        batch.EndDate = updateBatchRequest.EndDate;
        batch.IsActive = updateBatchRequest.IsActive;
        batch.ProgramId = updateBatchRequest.ProgramId;
        batch.LocationId = updateBatchRequest.LocationId;
        batch.BatchTypeId = updateBatchRequest.BatchTypeId;

        var existingPhaseIds = batch.BatchPhases.Select(bp => bp.Id).ToList();
        var incomingPhaseIds = updateBatchRequest.BatchPhases.Select(p => p.PhaseId).ToList();

        var phasesToRemove = batch.BatchPhases.Where(bp => !incomingPhaseIds.Contains(bp.PhaseId)).ToList();
        foreach (var phase in phasesToRemove)
        {
            _context.BatchPhase.Remove(phase);
        }

        foreach (var phaseDto in updateBatchRequest.BatchPhases)
        {
            var phase = batch.BatchPhases.FirstOrDefault(bp => bp.PhaseId == phaseDto.PhaseId);
            if (phase == null)
            {
                phase = new BatchPhase
                {
                    BatchId = batch.Id,
                    PhaseId = phaseDto.PhaseId,
                };
                batch.BatchPhases.Add(phase);
            }

            phase.NumberOfDays = phaseDto.NumberOfDays;
            phase.StartDate = phaseDto.StartDate;
            phase.EndDate = phaseDto.EndDate;

            var existingAssessmentTypeIds = phase.PhaseAssessmentTypeMappings.Select(patm => patm.AssessmentTypeId).ToList();
            var incomingAssessmentTypeIds = phaseDto.PhaseAssessmentTypeMappings.Select(p => p.AssessmentTypeId).ToList();

            var assessmentsToRemove = phase.PhaseAssessmentTypeMappings.Where(patm => !incomingAssessmentTypeIds.Contains(patm.AssessmentTypeId)).ToList();
            foreach (var assessment in assessmentsToRemove)
            {
                _context.PhaseAssessmentTypeMappings.Remove(assessment);
            }

            foreach (var assessmentDto in phaseDto.PhaseAssessmentTypeMappings)
            {
                var assessment = phase.PhaseAssessmentTypeMappings.FirstOrDefault(patm => patm.AssessmentTypeId == assessmentDto.AssessmentTypeId);
                if (assessment == null)
                {
                    assessment = new PhaseAssessmentTypeMapping
                    {
                        BatchPhaseId = phase.Id,
                        AssessmentTypeId = assessmentDto.AssessmentTypeId,
                        Weightage = assessmentDto.Weightage
                    };
                    phase.PhaseAssessmentTypeMappings.Add(assessment);
                }
                else
                {
                    assessment.Weightage = assessmentDto.Weightage;
                }
            }
        }

        await _context.SaveChangesAsync();
    }

}
