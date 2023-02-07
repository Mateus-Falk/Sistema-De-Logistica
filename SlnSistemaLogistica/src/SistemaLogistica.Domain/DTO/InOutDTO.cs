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
    public class InOutDTO
    {
        [DisplayName("Código")]
        public int id { get; set; }
        [Required(ErrorMessage = "Informe o tipo de transição")] 
        [DisplayName("Entrada ou Saída")]
        public int inOrOut  { get; set; }
        [DisplayName("Hora da Movimentação")]
        public DateTime time { get; set; }
        [DisplayName("Produto")]
        [Required(ErrorMessage = "Informe o produto")]
        public int productId { get; set; }
        [DisplayName("Quantidade")]
        [Required(ErrorMessage = "Informe a quantidade")]
        public int quantity { get; set; }
        [DisplayName("Usuario")]
        [Required(ErrorMessage = "Informe o usuário")]
        public string userName{ get; set; }
        [DisplayName("Cliente")]
        public int? clientId { get; set; }
        public virtual ClientDTO? client { get; set; }
        public virtual ProductDTO? product { get; set; }

        public InOut mapToEntity()
        {
            return new InOut
            {
                Id = id,
                InOrOut = inOrOut,
                Time = time,
                Quantity = quantity,
                UserName = userName,
                ClientId = clientId,
                ProductId = productId
            };
        }

        public InOutDTO mapToDTO(InOut inOut)
        {
            return new InOutDTO()
            {
                id = inOut.Id,
                inOrOut = inOut.InOrOut,
                time = inOut.Time,
                quantity = inOut.Quantity,
                userName = inOut.UserName,
                clientId = inOut.ClientId,
                productId = inOut.ProductId
            };
        }
    }
}
