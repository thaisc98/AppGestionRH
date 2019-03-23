using System.Collections.Generic;
using LAD;
using ODN;

namespace LDN
{
    public class PermisoLDN
    {
        private PermisoLAD objLAD;


        public PermisoLDN()
        {
            objLAD = new PermisoLAD();
        }

        public IEnumerable<Permiso> GetAll()
        {
            return objLAD.GetAll();
        }

        public Permiso GetById(int id)
        {
            return objLAD.GetById(id);
        }

        public void Insert(Permiso Permiso)
        {
            objLAD.Insert(Permiso);
        }

        public void Update(Permiso Permiso)
        {
            objLAD.Update(Permiso);
        }

        public void Delete(int id)
        {
            objLAD.Delete(id);
        }
    }
}
