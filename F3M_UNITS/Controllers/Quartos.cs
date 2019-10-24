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
    public class QuartoController : Controller
    {
        private IConfiguration configuracao;

        public QuartoController(IConfiguration config)
        {
            this.configuracao = config;
        }

        public IActionResult Index()
        {
            Conexao conexao = new Conexao(this.configuracao);
            string queryStr = "Select * from tbAtividades";
            SqlDataReader query = conexao.ExecutarQuery("F3MRAD", queryStr);
            List<Quarto> quartos = new List<Quarto>();
            if (query.HasRows)
            {
                while (query.
                    Read())
                {
                    Quarto quarto = new Quarto(query.GetInt64(0), query.GetString(1), query.GetString(2));
                    quartos.Add(quarto);
                }
            }
            query.Close();
            conexao.Fechar();
            return View(quartos);
        }

        public IActionResult Informacao(long id)
        {
            Conexao conexao = new Conexao(this.configuracao);
            string queryStr = "select * from dbo.tbAtividades where ID = " + id;
            SqlDataReader query = conexao.ExecutarQuery("F3MRAD", queryStr);
            Quarto quarto = null;
            if (query.HasRows)
            {
                while (query.Read())
                {
                    quarto = new Quarto(query.GetInt64(0), query.GetString(1), query.GetString(2));

                }
            }
            query.Close();
            conexao.Fechar();
            return View(quarto);
        }
    }
}