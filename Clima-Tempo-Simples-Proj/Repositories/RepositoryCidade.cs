using Clima_Tempo_Simples_Proj.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Clima_Tempo_Simples_Proj.Infra.Repositories
{
    public class RepositoryCidade : IRepositoryCidade
    {
        protected ClimaTempoSimplesContext db = new ClimaTempoSimplesContext();

        public void Add(List<Cidade> citys) 
        {
            db.Cidade.AddRange(citys);
            db.SaveChanges();
        }

        public Cidade Get(int id)
        {

            return db.Cidade.Where(x => x.Id == id).FirstOrDefault();

        }

        public List<Cidade> GetAll()
        {
            return db.Cidade.ToList();     
        }

        public void Remove(int id)
        {
            Cidade to_delete = db.Cidade.Where(x => x.Id == id).FirstOrDefault();
            if(to_delete != null)
            {
                db.Cidade.Remove(to_delete);
                db.SaveChanges();
            }
        }

        public void Update(Cidade city)
        {
            //Já existee no banco mas foi modificado, então precisa salvar apenas as diferenças.
            db.Entry(city).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}