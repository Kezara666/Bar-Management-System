using Bar_Management_System.Model.ProductManagement;
using Bar_Management_System.Model.SupplierManagement;
using Data.Model.BranchManagement;

namespace Bar_Management_System.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductCode { get; set; }
        public int BarCode { get; set; }

        public double AlcholPresent { get; set; }
        public int BottleCount { get; set; } = 0;
        public double BottleHaveMililiter { get; set; } = 0;
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public int SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
        public int BranchId { get; set; }
        public Branch? Branch { get; set; }
        public double EmptyPrice { get; set; } = 0;
        public double SellingPrice { get; set; } = 0;
        public double BuyerPrice { get; set; } = 0;
    }
}
