using System;
using System.Collections.Generic;

namespace calculadorabe.Models
{
    public partial class Calculadora
    {
        public int IdOperacion { get; set; }
        public string Nombre { get; set; }
        public double OperandoUno { get; set; }
        public double? OperandoDos { get; set; }
        public double Resultado { get; set; }
    }
}
