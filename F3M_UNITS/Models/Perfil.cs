using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F3M_UNITS.Models
{
    public class Perfil
    {
        public string descricao { get; set; }
        public string descAbreviada { get; set; }
        public Boolean ativo { get; set; }
        public Perfil(string descricao, string descAbreviada, Boolean ativo)
        {
            this.descricao = descricao;
            this.descAbreviada = descAbreviada;
            this.ativo = ativo;
        }
    }
}
