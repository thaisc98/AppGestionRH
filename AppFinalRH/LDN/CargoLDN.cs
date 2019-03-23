using System.Collections.Generic;
using LAD;
using ODN;

namespace LDN
{
    public class CargoLDN
    {
        private CargoLAD objLAD;


        public CargoLDN()
        {
            objLAD = new CargoLAD();
        }

        public IEnumerable<Cargo> GetAll()
        {
            return objLAD.GetAll();
        }

        public Cargo GetById(int id)
        {
            return objLAD.GetById(id);
        }

        public void Insert(Cargo cargo)
        {
            objLAD.Insert(cargo);
        }

        public void Update(Cargo cargo)
        {
            objLAD.Update(cargo);
        }

        public void Delete(int id)
        {
            objLAD.Delete(id);
        }
    }
}
