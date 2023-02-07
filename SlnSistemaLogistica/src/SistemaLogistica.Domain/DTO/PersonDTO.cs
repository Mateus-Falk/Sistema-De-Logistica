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
    public class PersonDTO
    {
        [DisplayName("Código")]
        public int id { get; set; }
        [DisplayName("Nome")]
        [Required(ErrorMessage = "Informe o nome")]
        public string name { get; set; }
        [DisplayName("CEP")]
        [Required(ErrorMessage = "Informe o CEP")]
        [MinLength(8, ErrorMessage = "CEP deve conter 8 números")]
        [MaxLength(8, ErrorMessage = "CEP deve conter 8 números")]
        public string cep { get; set; }
        [DisplayName("País")]
        [Required(ErrorMessage = "Informe o país")]
        public string country { get; set; }
        [Required(ErrorMessage = "Informe o estado")]
        [DisplayName("Estado")]
        public string uf { get; set; }
        [DisplayName("Cidade")]
        [Required(ErrorMessage = "Informe a cidade")]
        public string city { get; set; }
        [DisplayName("Bairro")]
        [Required(ErrorMessage = "Informe o bairro")]
        public string neighbourhood { get; set; }
        [DisplayName("Rua")]
        [Required(ErrorMessage = "Informe a rua")]
        public string street { get; set; }
        [DisplayName("Número")]
        [Required(ErrorMessage = "Informe o número")]
        public int number { get; set; }
        public virtual ICollection<InOutDTO>? inOutList { get; set; }
        public virtual ICollection<ProductDTO>? productList { get; set; }
        public virtual ICollection<FornecedorDTO>? fornecedorList { get; set; }
        public virtual ICollection<ClientDTO>? clientList { get; set; }

        public Person mapToEntity()
        {
            return new Person
            {
                Id = id,
                Name = name,
                CEP = cep,
                Country = country,
                UF = uf,
                City = city,
                Neighbourhood = neighbourhood,
                Street = street,
                Number = number
            };
        }

        public PersonDTO mapToDTO(Person person)
        {
            return new PersonDTO()
            {
                id = person.Id,
                name = person.Name,
                cep = person.CEP,
                country = person.Country,
                uf = person.UF,
                city = person.City,
                neighbourhood = person.Neighbourhood,
                street = person.Street,
                number = person.Number
            };
        }
    }
}
