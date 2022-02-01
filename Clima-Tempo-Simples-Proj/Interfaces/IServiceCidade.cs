using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clima_Tempo_Simples_Proj.Domain.Interfaces
{
    public interface IServiceCidade
    {
        void Add(List<Cidade> citys);
        Cidade Get(int id);
        List<Cidade> GetAll();
        void Update(Cidade city);
        void Remove(int id);
    }
}
