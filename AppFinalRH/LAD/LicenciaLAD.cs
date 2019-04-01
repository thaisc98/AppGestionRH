using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ODN;

namespace LAD
{
    public class LicenciaLAD
    {
        private GestionRHDbEntities db;

        public LicenciaLAD()
        {
            db = new GestionRHDbEntities();
        }


        public IEnumerable<Licencia> GetAll()
        {
            return db.Licencia.ToList();
        }
        

        public Licencia GetById(int id)
        {
            return db.Licencia.Find(id);
        }

        public void Insert(Licencia licencia)
        {
            db.Licencia.Add(licencia);
            db.SaveChanges();
        }

        public void Update(Licencia licencia)
        {
            db.Entry(licencia).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var lis = db.Licencia.Find(id);
            db.Licencia.Remove(lis);
            db.SaveChanges();
        }
    }
}
