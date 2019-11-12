using System;
using calculadorabe.Models;

namespace calculadorabe.Data
{
    public interface ICalculatorRepository: IGenericRepository<Calculadora>, IDisposable
    {
         
    }
}