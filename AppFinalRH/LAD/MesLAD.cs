using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ODN;

namespace LAD
{
    public class MesLAD
    {
        private GestionRHDbEntities db;

        public MesLAD()
        {
            db = new GestionRHDbEntities();
        }

        public IEnumerable<Mes> GetAll()
        {
            return db.Mes.ToList();
        }


        public Mes GetById(int id)
        {
            return db.Mes.Find(id);
        }

        public void Insert(Mes Mes)
        {
            db.Mes.Add(Mes);
            db.SaveChanges();
        }

        public void Update(Mes Mes)
        {
            db.Entry(Mes).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var lis = db.Mes.Find(id);
            db.Mes.Remove(lis);
            db.SaveChanges();
        }
    }
}
