using System.Collections.Generic;
using LAD;
using ODN;

namespace LDN
{
    public class EmpleadoLDN
    {
        private EmpleadoLAD objLAD;


        public EmpleadoLDN()
        {
            objLAD = new EmpleadoLAD();
        }

        public IEnumerable<Empleado> GetAll()
        {
            return objLAD.GetAll();
        }

        public Empleado GetById(int id)
        {
            return objLAD.GetById(id);
        }

        public void Insert(Empleado Empleado)
        {
            objLAD.Insert(Empleado);
        }

        public void Update(Empleado Empleado)
        {
            objLAD.Update(Empleado);
        }

        public void Delete(int id)
        {
            objLAD.Delete(id);
        }
    }
}
