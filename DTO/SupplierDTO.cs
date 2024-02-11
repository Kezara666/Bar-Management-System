using Data.Model.BranchManagement;

namespace Bar_Management_System.DTO
{
    public class SupplierDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ShortName { get; set; }
        public string? Address { get; set; }
        public string? CompanyRegNo { get; set; }
        public int TelNo { get; set; }

        public int BranchId { get; set; }
        public Branch ?Branch { get; set; }
    }



}
