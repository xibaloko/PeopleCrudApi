using CrudPessoas.Data.Converters;
using CrudPessoas.Data.VO;
using CrudPessoas.Model;
using CrudPessoas.Repository.Generic;
using System.Collections.Generic;

namespace CrudPessoas.Business.Implementation
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private IRepository<Person> _repository;
        private readonly PersonConverter _converter;

        public PersonBusinessImplementation(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        public PersonVO Create(PersonVO person)
        {
            var PersonEntity = _converter.Parse(person);
            PersonEntity = _repository.Create(PersonEntity);
            return _converter.Parse(PersonEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<PersonVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public PersonVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public PersonVO Update(PersonVO person)
        {
            var PersonEntity = _converter.Parse(person);
            PersonEntity = _repository.Update(PersonEntity);
            return _converter.Parse(PersonEntity);
        }
    }
}
