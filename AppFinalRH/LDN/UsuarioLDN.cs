using System.Collections.Generic;
using LAD;
using ODN;

namespace LDN
{
    public class UsuarioLDN
    {
        private UsuarioLAD objLAD;

        public UsuarioLDN()
        {
            objLAD = new UsuarioLAD();
        }

        public IEnumerable<Usuario> GetAll()
        {
            return objLAD.GetAll();
        }

        public Usuario GetById(int id)
        {
            return objLAD.GetById(id);
        }

        public void Insert(Usuario Usuario)
        {
            objLAD.Insert(Usuario);
        }

        public void Update(Usuario Usuario)
        {
            objLAD.Update(Usuario);
        }

        public void Delete(int id)
        {
            objLAD.Delete(id);
        }
    }
}
