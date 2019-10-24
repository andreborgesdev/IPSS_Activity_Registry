using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using F3M_UNITS;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using F3M_UNITS.Models;

namespace F3M_UNITS.Controllers
{
    public class UtenteController : Controller
    {
        private IConfiguration configuracao;
        public UtenteController(IConfiguration config)
        {
            this.configuracao = config;
        }

        public IActionResult Informacao(int id)
        {
            Conexao conexao = new Conexao(this.configuracao);
            string queryStr = "select utentes.id, ISNULL(Nome, ' '), ISNULL(IDSexo, 9), ISNULL(DataNascimento, '1900-01-01 00:00:00.000'), ISNULL(FotoCaminho, ' ') from dbo.tbUtentes as utentes, dbo.tbEntidadesRegistadas as registadas, dbo.tbEntidades as entidades where utentes.IDEntidadeRegistada = registadas.ID and registadas.IDEntidade = entidades.ID and utentes.ID = " + id;
            SqlDataReader query = conexao.ExecutarQuery("F3MESR3S1", queryStr);
            Utente utente = null;
            if (query.HasRows)
            {
                while (query.Read())
                {
                    utente = new Utente(query.GetInt64(0), query.GetString(1), query.GetInt64(2), query.GetDateTime(3), query.GetString(4));
                }
            }
            query.Close();
            conexao.Fechar();
            return View("Informacao", utente);
        }
    }
}