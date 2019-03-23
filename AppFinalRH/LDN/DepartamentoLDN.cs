using System.Collections.Generic;
using LAD;
using ODN;

namespace LDN
{
    public class DepartamentoLDN
    {
        private DepartamentoLAD objLAD;


        public DepartamentoLDN()
        {
            objLAD = new DepartamentoLAD();
        }

        public IEnumerable<Departamento> GetAll()
        {
            return objLAD.GetAll();
        }

        public Departamento GetById(int id)
        {
            return objLAD.GetByID(id);
        }

        public void Insert(Departamento Departamento)
        {
            objLAD.Insert(Departamento);
        }

        public void Update(Departamento Departamento)
        {
            objLAD.Update(Departamento);
        }

        public void Delete(int id)
        {
            objLAD.Delete(id);
        }
    }
}
