using Clima_Tempo_Simples_Proj.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Clima_Tempo_Simples_Proj.Infra.Repositories
{
    public class RepositoryPrevisaoClima : IRepositoryPrevisaoClima
    {
        protected ClimaTempoSimplesContext db = new ClimaTempoSimplesContext();

        public void Add(List<PrevisaoClima> previsoes)
        {
            db.PrevisaoClima.AddRange(previsoes);
            db.SaveChanges();
        }

        public PrevisaoClima Get(int id)
        {
            return db.PrevisaoClima.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<PrevisaoClima> GetAll()
        {
            return db.PrevisaoClima.ToList();
        }

        public void Remove(int id)
        {
            PrevisaoClima to_delete = db.PrevisaoClima.Where(x => x.Id == id).FirstOrDefault();
            if (to_delete != null)
            {
                db.PrevisaoClima.Remove(to_delete);
                db.SaveChanges();
            }
        }
        
        public void Update(PrevisaoClima previsao)
        {
            //Já existe no banco mas foi modificado, então precisa salvar apenas as diferenças.
            db.Entry(previsao).State = EntityState.Modified;
            db.SaveChanges();
        }

        public List<PrevisaoClima> Top3HotestCitys()
        {
            return db.PrevisaoClima.Where(x => DbFunctions.TruncateTime(x.DataPrevisao) == DateTime.Today).OrderByDescending(x => x.TemperaturaMaxima).Take(3).ToList();
        }

        public List<PrevisaoClima> Top3ColdestCitys()
        {
            return db.PrevisaoClima.Where(x => DbFunctions.TruncateTime(x.DataPrevisao) == DateTime.Today).OrderBy(x => x.TemperaturaMinima).Take(3).ToList();
        }

        public List<PrevisaoClima> GetPrevisaoPorCidade(int cidadeId)
        {
            return db.PrevisaoClima.Where(x => x.CidadeId == cidadeId && DbFunctions.TruncateTime(x.DataPrevisao) >= DateTime.Today).OrderBy(x => x.DataPrevisao).Take(7).ToList();
        }
    }
}