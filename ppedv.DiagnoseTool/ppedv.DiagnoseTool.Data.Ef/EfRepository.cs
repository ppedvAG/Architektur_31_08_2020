using ppedv.DiagnoseTool.Model;
using ppedv.DiagnoseTool.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.DiagnoseTool.Data.Ef
{
    public class EfRepository : IRepository
    {
        private EfContext context = null;

        public EfRepository(string conString = "Server= (localdb)\\MSSQLLocalDB;Database=Diagnosetool_DEMO;Trusted_Connection=true;")
        {
            context = new EfContext(conString);
        }

        

        public void Add<T>(T entity) where T : Entity
        {
            //if (typeof(T) == typeof(Arzt))
            //    context.Ärzte.Add(entity as Arzt);
            context.Set<T>().Add(entity);
        }

        public void Delete<T>(T entity) where T : Entity
        {
            context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            return context.Set<T>().ToList();
        }

        public T GetById<T>(int id) where T : Entity
        {
            return context.Set<T>().Find(id);
        }

        public int SaveAll()
        {
            return context.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity
        {
            var loaded = GetById<T>(entity.Id);
            if (loaded == null)
                throw new ObjectNotFoundException();


            context.Entry(loaded).CurrentValues.SetValues(entity);
        }
    }
}
