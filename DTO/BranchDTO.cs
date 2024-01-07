using Bar_Management_System.Model.ProductManagement;
using Bar_Management_System.Model.SupplierManagement;
using Data.Model.UserManagement;

namespace Bar_Management_System.DTO
{
    public class BranchDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
       
    }
}
