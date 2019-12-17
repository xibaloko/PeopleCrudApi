using CrudPessoas.Data.Converter;
using CrudPessoas.Data.VO;
using CrudPessoas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudPessoas.Data.Converters
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {
        public Person Parse(PersonVO origin)
        {
            if (origin == null) return new Person();
            return new Person()
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public PersonVO Parse(Person origin)
        {
            if (origin == null) return new PersonVO();
            return new PersonVO()
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public List<Person> ParseList(List<PersonVO> originList)
        {
            if (originList == null) return new List<Person>();
            return originList.Select(x => Parse(x)).ToList();
        }

        public List<PersonVO> ParseList(List<Person> originList)
        {
            if (originList == null) return new List<PersonVO>();
            return originList.Select(x => Parse(x)).ToList();
        }
    }
}
