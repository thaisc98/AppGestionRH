using System.Collections.Generic;
using LAD;
using ODN;

namespace LDN
{
    public class LicenciaLDN
    {
        private LicenciaLAD objLAD;


        public LicenciaLDN()
        {
            objLAD = new LicenciaLAD();
        }

        public IEnumerable<Licencia> GetAll()
        {
            return objLAD.GetAll();
        }

        public Licencia GetById(int id)
        {
            return objLAD.GetById(id);
        }

        public void Insert(Licencia Licencia)
        {
            objLAD.Insert(Licencia);
        }

        public void Update(Licencia Licencia)
        {
            objLAD.Update(Licencia);
        }

        public void Delete(int id)
        {
            objLAD.Delete(id);
        }
    }
}
