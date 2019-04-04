using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ODN;

namespace LAD
{
    public class NominaLAD
    {

        private GestionRHDbEntities db;

        public NominaLAD()
        {
            db = new GestionRHDbEntities();
        }

        public IEnumerable<Nomina> GetAll()
        {
            return db.Nomina.ToList();
        }

        public Nomina GetById(int id)
        {
            return db.Nomina.Find(id);
        }

        public void Insert(Nomina nomina)
        {
            db.Nomina.Add(nomina);
            db.SaveChanges();

        }

        public void Update(Nomina nomina)
        {
           db.Entry(nomina).State = EntityState.Modified;
           db.SaveChanges();
        }

        public void Delete(int id)
        {
            var nomi = db.Nomina.Find(id);
            db.Nomina.Remove(nomi);
            db.SaveChanges();

        }
    }
}
