using System.Collections.Generic;
using LAD;
using ODN;

namespace LDN
{
    public class SalidaEmpleadoLDN
    {
        private SalidaEmpleadoLAD objLAD;


        public SalidaEmpleadoLDN()
        {
            objLAD = new SalidaEmpleadoLAD();
        }

        public IEnumerable<SalidaEmpleado> GetAll()
        {
            return objLAD.GetAll();
        }

        public SalidaEmpleado GetById(int id)
        {
            return objLAD.GetById(id);
        }

        public void Insert(SalidaEmpleado SalidaEmpleado)
        {
            objLAD.Insert(SalidaEmpleado);
        }

        public void Update(SalidaEmpleado SalidaEmpleado)
        {
            objLAD.Update(SalidaEmpleado);
        }

        public void Delete(int id)
        {
            objLAD.Delete(id);
        }
    }
}
