using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Core
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
    }
}
