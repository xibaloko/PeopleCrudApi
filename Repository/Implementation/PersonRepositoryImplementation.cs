using CrudPessoas.Model;
using CrudPessoas.Model.Context;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace CrudPessoas.Business.Implementation
{
    public class PersonRepositoryImplementation : IPersonRepository
    {
        private MySQLContext _context;

        public PersonRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
            return person;
        }

        public void Delete(long id)
        {
            var result = _context.People.SingleOrDefault(x => x.Id.Equals(id));
            try
            {
                if (result != null) _context.People.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Person> FindAll()
        {
            return _context.People.ToList();
        }

        public Person FindById(long id)
        {
            return _context.People.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return null;
            var result = _context.People.SingleOrDefault(x => x.Id.Equals(person.Id));
            try
            {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
            return person;
        }

        public bool Exists(long? id)
        {
            return _context.People.Any(x => x.Id.Equals(id));
        }
    }
}
