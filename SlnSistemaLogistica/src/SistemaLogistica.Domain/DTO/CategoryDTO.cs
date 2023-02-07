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
    public class CategoryDTO
    {
        [DisplayName("Código")]
        public int id { get; set; }
        [DisplayName("Categoria")]
        [Required(ErrorMessage = "Informe o nome da Categoria")]
        public string name { get; set; }
        public virtual ICollection<ProductDTO>? productList { get; set; }

        public Category mapToEntity()
        {
            return new Category
            {
                Id = id,
                Name = name
            };
        }
        public CategoryDTO MapToDTO(Category category)
        {
            return new CategoryDTO()
            {
                id = category.Id,
                name = category.Name
            };
        }
    }
}
