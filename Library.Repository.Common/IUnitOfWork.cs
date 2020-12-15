using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveAsync();
    }
}