using System.Threading.Tasks;
using calculadorabe.Models;

namespace calculadorabe.Data
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly calculadoradbContext _context;
        public ICalculatorRepository Operaciones { get; }


        public UnitOfWork(calculadoradbContext context)
        {
            _context = context;
            Operaciones = new CalculatorRepository(_context);
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}