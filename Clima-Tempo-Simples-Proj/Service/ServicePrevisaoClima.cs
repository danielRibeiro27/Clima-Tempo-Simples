using Clima_Tempo_Simples_Proj.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clima_Tempo_Simples_Proj.Service
{
    public class ServicePrevisaoClima : IServicePrevisaoClima
    {
        private readonly IRepositoryPrevisaoClima repository;

        public ServicePrevisaoClima(IRepositoryPrevisaoClima _repository)
        {
            repository = _repository;
        }

        public void Add(List<PrevisaoClima> previsoes)
        {
            repository.Add(previsoes);
        }

        public PrevisaoClima Get(int id)
        {
            return repository.Get(id);
        }

        public List<PrevisaoClima> GetAll()
        {
            return repository.GetAll();
        }

        public void Remove(int id)
        {
            repository.Remove(id);
        }


        public void Update(PrevisaoClima previsao) //Poderia retornar um INTEIRO para sabere quantas linhas atualizou
        {
            repository.Update(previsao);
        }
        
        public List<PrevisaoClima> Top3HotestCitys()
        {
            return repository.Top3HotestCitys();
        }
        public List<PrevisaoClima> Top3ColdestCitys()
        {
            return repository.Top3ColdestCitys();
        }

        public List<PrevisaoClima> GetPrevisaoPorCidade(int cidadeId)
        {
            return repository.GetPrevisaoPorCidade(cidadeId);
        }
    }
}