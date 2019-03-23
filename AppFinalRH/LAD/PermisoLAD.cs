using ODN;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LAD
{
    public class PermisoLAD
    {
        private GestionRHDbEntities db;

        public PermisoLAD()
        {
            db = new GestionRHDbEntities();
        }

        public IEnumerable<Permiso> GetAll()
        {
            return db.Permiso.ToList();
        }

        public Permiso GetById(int id)
        {
            return db.Permiso.Find(id);
        }

        public void Insert(Permiso permiso)
        {
            db.Permiso.Add(permiso);
            db.SaveChanges();

        }

        public void Update(Permiso permiso)
        {
            db.Entry(permiso).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var permi = db.Permiso.Find(id);
            db.Permiso.Remove(permi);
            db.SaveChanges();
        }
    }
}
