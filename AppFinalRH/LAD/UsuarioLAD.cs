using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ODN;

namespace LAD
{
    public class UsuarioLAD
    {

        private GestionRHDbEntities db;
        public UsuarioLAD()
        {
            db = new GestionRHDbEntities();
            
        }

        public IEnumerable<Usuario> GetAll()
        {
            return db.Usuario.ToList();
        }

        public Usuario GetById(int id)
        {
            return db.Usuario.Find(id);
        }

        public void Insert(Usuario usuario)
        {
            db.Usuario.Add(usuario);
            db.SaveChanges();

        }

        public void Update(Usuario usuario)
        {
            db.Entry(usuario).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = db.Usuario.Find(id);
            db.Usuario.Remove(user);
            db.SaveChanges();
        }



    }
}
