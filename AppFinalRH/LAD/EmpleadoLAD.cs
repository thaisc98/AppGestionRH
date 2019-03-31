using ODN;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LAD
{
    public class EmpleadoLAD
    {
        private GestionRHDbEntities db;

        public EmpleadoLAD()
        {
            db = new GestionRHDbEntities();
        }

        public IEnumerable<Empleado> GetAll()
        {
            return db.Empleado.ToList();
        }

        public Empleado GetById(int id)
        {
            return db.Empleado.Find(id);

        }

        public void Insert(Empleado empleado)
        {
            db.Empleado.Add(empleado);
            db.SaveChanges();
        }

        public void Update(Empleado empleado)
        {
            db.Entry(empleado).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var x = db.Empleado.Find(id);
            db.Empleado.Remove(x);
            db.SaveChanges();
        }

    }
}