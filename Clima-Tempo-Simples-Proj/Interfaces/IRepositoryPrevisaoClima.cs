using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clima_Tempo_Simples_Proj.Interfaces
{
    //Também poderia haver um repositório generico que implementa o CRUD básico para qualquer entidade
    public interface IRepositoryPrevisaoClima
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
