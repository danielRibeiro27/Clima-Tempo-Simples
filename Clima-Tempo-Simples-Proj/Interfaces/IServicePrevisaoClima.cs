using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clima_Tempo_Simples_Proj.Interfaces
{
    public interface IServicePrevisaoClima
    {
        void Add(List<PrevisaoClima> previsoes);
        PrevisaoClima Get(int id);
        List<PrevisaoClima> GetAll();
        void Update(PrevisaoClima previsao);
        void Remove(int id); 
         List<PrevisaoClima> Top3HotestCitys();
         List<PrevisaoClima> Top3ColdestCitys();
        List<PrevisaoClima> GetPrevisaoPorCidade(int cidadeId);
    }
}
