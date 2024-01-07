using AutoMapper;
using Bar_Management_System.DTO;
using Data.Model.BranchManagement;

namespace Bar_Management_System.Configuration
{
    public class MapperInitilizer : Profile
    {
        public MapperInitilizer() {
            CreateMap<Branch, BranchDTO>().ReverseMap();
        }
    }
}
