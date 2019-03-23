using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ODN;

namespace LAD
{
    public class DepartamentoLAD
    {
        private GestionRHDbEntities db;

        public DepartamentoLAD()
        {
            db = new GestionRHDbEntities();
        }

        public IEnumerable<Departamento> GetAll()
        {
            return db.Departamento.ToList();
        }

        public Departamento GetByID(int id)
        {
            return db.Departamento.Find(id);
        }

        public void Insert(Departamento departamento)
        {
            db.Departamento.Add(departamento);
            db.SaveChanges();
        }

        public void Update(Departamento departamento)
        {
            db.Entry(departamento).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var depa = db.Departamento.Find(id);
            db.Departamento.Remove(depa);
            db.SaveChanges();
        }


    }
}
