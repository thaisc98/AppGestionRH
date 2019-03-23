using System.Collections.Generic;
using LAD;
using ODN;

namespace LDN
{
    public class VacacionLDN
    {
        private VacacionLAD objLAD;

        public VacacionLDN()
        {
            objLAD = new VacacionLAD();
        }

        public IEnumerable<Vacacion> GetAll()
        {
            return objLAD.GetAll();
        }

        public Vacacion GetById(int id)
        {
            return objLAD.GetById(id);
        }

        public void Insert(Vacacion Vacacion)
        {
            objLAD.Insert(Vacacion);
        }

        public void Update(Vacacion Vacacion)
        {
            objLAD.Update(Vacacion);
        }

        public void Delete(int id)
        {
            objLAD.Delete(id);
        }
    }
}
