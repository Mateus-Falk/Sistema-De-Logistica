using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLogistica.Domain.Entities
{
    public class InOut
    {
        public int Id { get; set; }
        public int InOrOut { get; set; }
        public DateTime Time { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string UserName { get; set; }
        public int? ClientId { get; set; }
        public virtual Client? Client { get; set; }
        public virtual Product? Product { get; set; }
    }
}
