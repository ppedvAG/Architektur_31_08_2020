using System;
using System.Collections.Generic;
using System.Linq;
using ppedv.DiagnoseTool.Model;
using ppedv.DiagnoseTool.Model.Contracts;

namespace ppedv.DiagnoseTool.Logik.Tests
{
    public class TestRepo : IRepository
    {
        public void Add<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
        
            throw new NotImplementedException();
        }

        public T GetById<T>(int id) where T : Entity
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            if (typeof(T) == typeof(Arzt))
            {
                var a1 = new Arzt() { Name = "Dr. Frankenstein" };
                a1.Diagnosen.Add(new Diagnose() { Patient = new Patient() });

                var a2 = new Arzt() { Name = "Dr. Wer" };
                a2.Diagnosen.Add(new Diagnose() { Patient = new Patient() });
                a2.Diagnosen.Add(new Diagnose() { Patient = new Patient() });

                return new[] { a1, a2 }.Cast<T>().AsQueryable();
            }
            throw new NotImplementedException();
        }

        public int SaveAll()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }
    }
}
