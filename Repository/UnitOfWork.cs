using Data.Model;
using Repos.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly BMSContext _context;
        public UnitOfWork(BMSContext context)
        {
            _context = context;
        }

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
