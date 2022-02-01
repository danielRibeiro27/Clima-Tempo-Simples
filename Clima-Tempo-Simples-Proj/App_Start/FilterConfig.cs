using System.Web;
using System.Web.Mvc;

namespace Clima_Tempo_Simples_Proj
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
