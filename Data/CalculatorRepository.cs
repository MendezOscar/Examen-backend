using System;
using calculadorabe.Models;

namespace calculadorabe.Data
{
    public class CalculatorRepository: GenericRepository<Calculadora>, ICalculatorRepository
    {
        private bool disposed = false;
        private readonly calculadoradbContext _context;
        public CalculatorRepository(calculadoradbContext context) : base(context)
        {
            _context = context;
        }
        
        protected virtual void Dispose(bool disposing)        
        {            
            if (!this.disposed)            
            {                
                if (disposing)                
                {                    
                    _context.Dispose();                
                }
            }            
            this.disposed = true;        
        }        
        
        public void Dispose()        
        {            
            Dispose(true);            
            GC.SuppressFinalize(this);        
        
        }

    }
}