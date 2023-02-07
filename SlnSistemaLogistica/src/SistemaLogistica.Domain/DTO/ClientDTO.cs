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
    public class ClientDTO
    {
        [DisplayName("Código")]
        public int id { get; set; }
        [DisplayName("Pessoa")]
        [Required(ErrorMessage = "Informe a Pessoa")]
        public int personId { get; set; }
        public virtual PersonDTO? person { get; set; }

        public Client mapToEntity() 
        {
            return new Client
            {
                Id = id,
                PersonId = personId
                
            };
        }
        public ClientDTO mapToDTO(Client client)
        {
            return new ClientDTO()
            {
                id = client.Id,
                personId = client.PersonId
            };
        }
    }
}
