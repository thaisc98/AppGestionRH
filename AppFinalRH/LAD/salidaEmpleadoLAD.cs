using ODN;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LAD
{
    public class SalidaEmpleadoLAD
    {
        private GestionRHDbEntities db;

        public SalidaEmpleadoLAD()
        {
            db = new GestionRHDbEntities();
        }

        public IEnumerable<SalidaEmpleado> GetAll()
        {
            return db.SalidaEmpleado.ToList();
        }r

        public SalidaEmpleado GetById(int id)
        {
            return db.SalidaEmpleado.Find(id);
        }

        public void Insert(SalidaEmpleado salidaEmpleado)
        {
            db.SalidaEmpleado.Add(salidaEmpleado);
            db.SaveChanges();

        }

        public void Update(SalidaEmpleado salidaEmpleado)
        {
            db.Entry(salidaEmpleado).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var sali = db.SalidaEmpleado.Find(id);
            db.SalidaEmpleado.Remove(sali);
            db.SaveChanges();
        }

    }
}
