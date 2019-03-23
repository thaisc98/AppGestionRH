using System.Collections.Generic;
using LAD;
using ODN;

namespace LDN
{
    public class NominaLDN
    {
        private NominaLAD objLAD;


        public NominaLDN()
        {
            objLAD = new NominaLAD();
        }

        public IEnumerable<Nomina> GetAll()
        {
            return objLAD.GetAll();
        }

        public Nomina GetById(int id)
        {
            return objLAD.GetById(id);
        }

        public void Insert(Nomina Nomina)
        {
            objLAD.Insert(Nomina);
        }

        public void Update(Nomina Nomina)
        {
            objLAD.Update(Nomina);
        }

        public void Delete(int id)
        {
            objLAD.Delete(id);
        }
    }
}
