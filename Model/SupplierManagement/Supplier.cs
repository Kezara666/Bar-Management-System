using Bar_Management_System.Model.ProductManagement;
using Data.Model.BranchManagement;
using System.ComponentModel.DataAnnotations;

namespace Bar_Management_System.Model.SupplierManagement
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ShortName { get; set; }
        public string? Address { get; set; }
        public string? CompanyRegNo { get; set; }
        public int TelNo { get; set; }

        public ICollection<Product> Products { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
    }
}
