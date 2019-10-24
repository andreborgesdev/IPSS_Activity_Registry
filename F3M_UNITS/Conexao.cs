using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using F3M_UNITS.Models;

namespace F3M_UNITS
{
    public class Conexao
    {

        private IConfiguration configuracao;
        private SqlConnection conexao;

        public Conexao(IConfiguration config)
        {
            this.configuracao = config;
        }
        
        public SqlDataReader ExecutarQuery(string conetor, string query)
        {
            this.conexao = new SqlConnection(this.configuracao.GetConnectionString(conetor));
            this.conexao.Open();
            SqlCommand comando = new SqlCommand(query, conexao);
            SqlDataReader resultado = comando.ExecuteReader();
            return resultado;
        }
        public void Fechar()
        {
            this.conexao.Close();
        }

    }
}
