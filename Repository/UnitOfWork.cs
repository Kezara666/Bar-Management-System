using Bar_Management_System.Model.ProductManagement;
using Bar_Management_System.Model.SupplierManagement;
using Data.Model;
using Data.Model.BranchManagement;
using Repos.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BMSContext _context;
        public IGenericRepository<Branch> _branch;
        public IGenericRepository<Category> _category;
        public IGenericRepository<Supplier> _supplier;
        public IGenericRepository<Product> _product;
        public UnitOfWork(BMSContext context)
        {
            _context = context;
        }

        public IGenericRepository<Branch> Branch => _branch ??= new GenericRepository<Branch>(_context);

        public IGenericRepository<Category> Category => _category ??= new GenericRepository<Category>(_context);

        public IGenericRepository<Supplier> Supplier => _supplier ??= new GenericRepository<Supplier>(_context);
        public IGenericRepository<Product> Product => _product ??= new GenericRepository<Product>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
