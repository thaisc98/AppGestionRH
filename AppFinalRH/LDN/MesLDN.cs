using System.Collections.Generic;
using LAD;
using ODN;

namespace LDN
{
    public class MesLDN
    {
        private MesLAD objLAD;

        public MesLDN()
        {
            objLAD = new MesLAD();
        }

        public IEnumerable<Mes> GetAll()
        {
            return objLAD.GetAll();
        }

        public Mes GetById(int id)
        {
            return objLAD.GetById(id);
        }

        public void Insert(Mes Mes)
        {
            objLAD.Insert(Mes);
        }

        public void Update(Mes Mes)
        {
            objLAD.Update(Mes);
        }

        public void Delete(int id)
        {
            objLAD.Delete(id);
        }
    }
}
