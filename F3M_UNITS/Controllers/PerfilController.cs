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
    public class PerfilController : Controller
    {
        private IConfiguration configuracao;

        public PerfilController(IConfiguration config)
        {
            this.configuracao = config;
        }

        public IActionResult Index()
        {
            Conexao conexao = new Conexao(this.configuracao);
            SqlDataReader query = conexao.ExecutarQuery("F3MESGeral", "Select * from tbPerfis");
            List<Perfil> perfis = new List<Perfil>();
            if (query.HasRows)
            {
                while (query.
                    Read())
                {
                    Perfil perfil = new Perfil(query.GetString(1), query.GetString(2), query.GetBoolean(3));
                    perfis.Add(perfil);
                }
            }
            query.Close();
            conexao.Fechar();
            Debug.Write("###############\n");
            return View(perfis);
        }
    }
}