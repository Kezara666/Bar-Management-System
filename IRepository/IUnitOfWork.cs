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
        Task Save();
    }
}
