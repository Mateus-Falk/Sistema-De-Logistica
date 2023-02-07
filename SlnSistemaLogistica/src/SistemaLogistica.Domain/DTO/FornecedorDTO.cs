using SistemaLogistica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLogistica.Domain.DTO
{
    public class FornecedorDTO
    {
        [DisplayName("Código")]
        public int id { get; set; }
        [DisplayName("Pessoa")]
        [Required(ErrorMessage = "Informe a Pessoa")]
        public int personId { get; set; }
        public virtual PersonDTO? person { get; set; }

        public Fornecedor mapToEntity()
        {
            return new Fornecedor
            {
                Id = id,
                PersonId = personId,
            };
        }
        public FornecedorDTO mapToDTO(Fornecedor fornecedor)
        {
            return new FornecedorDTO
            {
                id = fornecedor.Id,
                personId = fornecedor.PersonId,
                
            };
        }
    }
}
