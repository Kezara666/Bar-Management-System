using AutoMapper;
using Bar_Management_System.DTO;
using Bar_Management_System.Model.ProductManagement;
using Bar_Management_System.Model.SupplierManagement;
using Data.Model.BranchManagement;

namespace Bar_Management_System.Configuration
{
    public class MapperInitilizer : Profile
    {
        public MapperInitilizer() {
            CreateMap<Branch, BranchDTO>().ReverseMap();
            CreateMap<Category, ShowCategoryDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Supplier, SupplierDTO>().ReverseMap();
                CreateMap<Product, ProductDTO>().ReverseMap();
        }


    }
}
