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
        }
    }
}
