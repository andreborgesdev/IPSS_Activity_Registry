using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F3M_UNITS.Models
{
    public class Quarto
    {
        public long id { get; }
        public string codigo { get; }
        public string descricao { get; }

        public Quarto(long id, string codigo, string descricao)
        {
            this.id = id;
            this.codigo = codigo;
            this.descricao = descricao;
        }
    }
}