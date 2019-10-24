using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F3M_UNITS.Models
{
    public class Utente
    {
        public long id { get; }
        public string nome { get; }
        public long genero { get; }
        public DateTime dataNascimento { get; }
        public string  urlFoto { get; }

        public Utente(long id, string nome, long genero, DateTime dataNascimento, string urlFoto)
        {
            this.id = id;
            this.nome = nome;
            this.genero = genero;
            this.dataNascimento = dataNascimento;
            this.urlFoto = urlFoto;
        }
    }
}
