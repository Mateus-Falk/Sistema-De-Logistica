using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLogistica.Domain.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CEP { get; set; }
        public string Country { get; set; }
        public string UF { get; set; }
        public string City { get; set; }
        public string Neighbourhood { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public virtual ICollection<InOut>? InOutList { get; set; }
        public virtual ICollection<Product>? ProductList { get; set; }
        public virtual ICollection<Client>? ClientList { get; set; }
        public virtual ICollection<Fornecedor>? FornecedorList { get; set; }
    }
}
