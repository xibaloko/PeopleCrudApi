using System.Runtime.Serialization;

namespace CrudPessoas.Model.Base
{
    [DataContract]
    public class BaseEntity
    {
        public long Id { get; set; }

    }
}
