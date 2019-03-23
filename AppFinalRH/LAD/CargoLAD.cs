using ODN;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LAD
{
    public class CargoLAD
    {
        private GestionRHDbEntities db;
        public CargoLAD()
        {
            db = new GestionRHDbEntities();
        }
        
        public IEnumerable<Cargo> GetAll()
        {
            return db.Cargo.ToList();
        }

        public Cargo GetById(int id)
        {
            return db.Cargo.Find(id);

        }

        public void Insert(Cargo cargo)
        {
            db.Cargo.Add(cargo);
            db.SaveChanges();
        }

        public void Update(Cargo cargo)
        {
            db.Entry(cargo).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var x = db.Cargo.Find(id);
            db.Cargo.Remove(x);
            db.SaveChanges();
        }



    }
}
