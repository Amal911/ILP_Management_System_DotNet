using AutoMapper;
using ILPManagementSystem.Models.DTO;
using ILPManagementSystem.Models;
using ILPManagementSystem.Repository;

namespace ILPManagementSystem.Services
{
    public class AssessmentService
    {
        private readonly AssessmentRepository _assessmentRepository;
        private readonly IMapper _mapper;

        public AssessmentService(AssessmentRepository assessmentRepository, IMapper mapper)
        {
            _assessmentRepository = assessmentRepository;
            _mapper = mapper;
        }

        public async Task<Assessment> CreateAssessment(CreateAssessmentDTO newAssessment)
        {
            var assessment = _mapper.Map<Assessment>(newAssessment);

            if (newAssessment.IsSubmitable)
            {
                assessment.DueDateTime = newAssessment.DueDateTime.Value;
                await HandleDocumentUpload(newAssessment, assessment);
            }
            else
            {
                ResetAssessmentDocument(assessment);
            }

            await _assessmentRepository.CreateAssessment(assessment);
            return assessment;
        }

        private async Task HandleDocumentUpload(CreateAssessmentDTO newAssessment, Assessment assessment)
        {
            if (newAssessment.Document != null)
            {
                var (filePath, fileName) = await FileUploadHelper.UploadFile(newAssessment.Document, "AssessmentDocuments");
                assessment.DocumentPath = filePath;
                assessment.DocumentName = fileName;
                assessment.DocumentContentType = newAssessment.Document.ContentType;
            }
        }

        private void ResetAssessmentDocument(Assessment assessment)
        {
            assessment.DueDateTime = default;
            assessment.DocumentPath = null;
            assessment.DocumentName = null;
            assessment.DocumentContentType = null;
        }

        public async Task SubmitMarks(int assessmentId, List<CompletedAssessmentDTO> marks)
        {
            foreach (var mark in marks)
            {
                var completedAssessment = new CompletedAssessment
                {
                    AssessmentId = assessmentId,
                    TraineeId = mark.TraineeId,
                    Score = mark.Score,
                };
                await _assessmentRepository.SubmitMarks(completedAssessment);
            }
        }

        public async Task<IEnumerable<Assessment>> GetAssessmentsByBatchId(int batchId)
        {
            return await _assessmentRepository.GetAssessmentsByBatchId(batchId);
        }

    }
}
