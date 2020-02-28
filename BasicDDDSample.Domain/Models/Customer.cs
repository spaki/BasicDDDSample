using BasicDDDSample.Domain.Models.Common;

namespace BasicDDDSample.Domain.Models
{
    public class Customer : EntityBase
    {
        public string Email { get; set; }
        public string Nome { get; set; }
    }
}
