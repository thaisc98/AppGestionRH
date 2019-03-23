using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ODN;

namespace LAD
{
    public class VacacionLAD
    {

        private GestionRHDbEntities db;

        public VacacionLAD()
        {
            db = new GestionRHDbEntities();
        }

        public IEnumerable<Vacacion> GetAll()
        {
            return db.Vacacion.ToList();
        }

        public Vacacion GetById(int id)
        {
            return db.Vacacion.Find(id);
        }
        
        public void Insert(Vacacion vaca)
        {
            db.Vacacion.Add(vaca);
            db.SaveChanges();
        }

        public void Update(Vacacion vaca)
        {
            db.Entry(vaca).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var vaca = db.Usuario.Find(id);
            db.Usuario.Remove(vaca);
            db.SaveChanges();
        }



    }
}
