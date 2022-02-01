using Clima_Tempo_Simples_Proj.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clima_Tempo_Simples_Proj.Service
{
    public class ServiceCidade : IServiceCidade
    {
        private readonly IRepositoryCidade repository;

        public ServiceCidade(IRepositoryCidade _repository)
        {
            repository = _repository;
        }

        public void Add(List<Cidade> citys)
        {
            repository.Add(citys);
        }

        public Cidade Get(int id)
        {
            return repository.Get(id);
        }

        public List<Cidade> GetAll()
        {
            return repository.GetAll();
        }

        public void Remove(int id)
        {
            repository.Remove(id);
        }

        public void Update(Cidade city)
        {
            repository.Update(city);
        }
    }
}