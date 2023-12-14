using Bar_Management_System.Model.ProductManagement;
using Data.Model.BranchManagement;

namespace Bar_Management_System.Model.InvoiceManagement
{
    public class SubUnitInvoce
    {
        public int Id { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int Qnt { get; set; }
        public double Discount { get; set; } = 0;
        public double VAT { get; set; }
        public double TotalPurchasePrice { get; set; }
        public double TotalSellPrice { get; set; }
        public int NotRecived { get; set; }
        public int Empty { get; set; } = 0;
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
    }
}
