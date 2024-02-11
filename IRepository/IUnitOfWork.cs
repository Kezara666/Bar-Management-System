using Bar_Management_System.Controllers.Product.Category;
using Bar_Management_System.Model.ProductManagement;
using Bar_Management_System.Model.SupplierManagement;
using Data.Model.BranchManagement;
using Repos.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos
{
    public interface IUnitOfWork:IDisposable
    {
        IGenericRepository<Branch> Branch { get; }
        IGenericRepository<Category> Category { get; }
        IGenericRepository<Supplier> Supplier { get; }
        IGenericRepository<Product> Product { get; }
        Task Save();
    }
}
