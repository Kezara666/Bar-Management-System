using Bar_Management_System.Model.SupplierManagement;
using Data.Model.BranchManagement;

namespace Bar_Management_System.Model.ProductManagement
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}