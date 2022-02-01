using Clima_Tempo_Simples_Proj.Domain.Interfaces;
using Clima_Tempo_Simples_Proj.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Clima_Tempo_Simples_Proj.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceCidade serviceCidade;
        private readonly IServicePrevisaoClima servicePrevisaoClima;

        public HomeController(IServiceCidade _serviceCidade, IServicePrevisaoClima _servicePrevisaoClima)
        {
            serviceCidade = _serviceCidade;
            servicePrevisaoClima = _servicePrevisaoClima;
        }

        public ActionResult Index()
        {
            //Listar todas cidades 
            ViewBag.cidades = serviceCidade.GetAll();
            ViewBag.Top3HotestCitys = servicePrevisaoClima.Top3HotestCitys();
            ViewBag.Top3ColdestCitys = servicePrevisaoClima.Top3ColdestCitys();

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetPrevisao(int cidadeId)
        {
            List<PrevisaoClima> previsoes = servicePrevisaoClima.GetPrevisaoPorCidade(cidadeId);
            List<object> retorno_generico = new List<object>();

            //Era pra mudar o DayOfWeek para retornar o dia dad semana em portugues
            //Mas não ta funcionando
            CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-Br");

            foreach (PrevisaoClima prev in previsoes)
            {
                retorno_generico.Add(new { 
                    DayOfWeek = prev.DataPrevisao.DayOfWeek.ToString(),
                    Clima = prev.Clima,
                    TemperaturaMinima = prev.TemperaturaMinima,
                    TemperaturaMaxima = prev.TemperaturaMaxima,
                    Cidade = prev.Cidade.Nome
                });
            }

            Thread.CurrentThread.CurrentCulture = originalCulture;

            return Json(retorno_generico);

        }
    }
}