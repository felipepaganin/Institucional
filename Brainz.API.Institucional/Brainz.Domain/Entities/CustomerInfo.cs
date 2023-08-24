using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainz.Domain.Entities
{
    public class CustomerInfo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string CEP { get; set; }
        public string Address { get; set; }
    }
}
