using Bar_Management_System.Model.SupplierManagement;
using Data.Model.BranchManagement;

namespace Bar_Management_System.Model.InvoiceManagement
{
    public class Invoice
    {
        public int Id { get; set; }
        public int InvoiceNo { get; set; }
        public DateTime Date { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public double TotalPurchasePrice { get; set; }
        public double TotalSellPrice { get; set; }
        public int TotalItemCount { get; set; }

        public ICollection<SubUnitInvoce> SubInvoces { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }

    }
}
