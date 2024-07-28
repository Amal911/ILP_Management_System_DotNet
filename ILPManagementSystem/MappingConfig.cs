using AutoMapper;
using ILPManagementSystem.Models;
using ILPManagementSystem.Models.DTO;

namespace ILPManagementSystem
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
            CreateMap<Batch,BatchDTO>().ReverseMap();
            CreateMap<Batch,CreateBatchDTO>().ReverseMap();
            CreateMap<Phase,PhaseDTO>().ReverseMap();
            CreateMap<BatchPhase,BatchPhaseDTO>().ReverseMap();
            CreateMap<CompletedAssessment,CompletedAssessmentDTO>().ReverseMap();
            CreateMap<AssessmentType,AssessmentTypeDTO>().ReverseMap();
            CreateMap<DocumentLinks,DocumentLinksDTO>().ReverseMap();

            CreateMap<Session,CreateSessionDTO>().ReverseMap();
            CreateMap<Assessment,CreateAssessmentDTO>().ReverseMap();
            CreateMap<BatchType,BatchTypeDTO>().ReverseMap();       
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<SessionAttendance,SessionAttendanceDTO>().ReverseMap();
            CreateMap<BatchProgram,BatchProgramDTO>().ReverseMap();

            CreateMap<Batch, ExposedBatchDTO>().ReverseMap();
        }
    }
}
