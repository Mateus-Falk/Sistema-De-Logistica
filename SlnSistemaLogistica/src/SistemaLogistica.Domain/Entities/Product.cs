using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLogistica.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? FornecedorId { get; set; }
        public int QuantityStock { get; set; }
        public int QuantityMinimun { get; set; }
        public string? Image { get; set; }
        public int CategoryId { get; set; }
        public virtual Fornecedor? Fornecedor { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<InOut>? InOutList { get; set; }
    }
}
