using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Models
{
    public class Funcionario:EntidadeBase
    {
        public string Cpf { get; set; }
        public string Cargo { get; set; }
        public double Salario { get; set; }
        public DateTime DataAdmissao { get; set; }
        
    }
}
