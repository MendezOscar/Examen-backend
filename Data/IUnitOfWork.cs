using System;
using System.Threading.Tasks;

namespace calculadorabe.Data
{
    public interface IUnitOfWork : IDisposable
    {
        ICalculatorRepository Operaciones {get;}

         Task<int> Complete();
    }
}