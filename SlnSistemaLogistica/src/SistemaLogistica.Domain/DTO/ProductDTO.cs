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
    public class ProductDTO
    {
        [DisplayName("Código")]
        public int id { get; set; }
        [DisplayName("Produto")]
        [Required(ErrorMessage = "Informe o produto")]
        public string name { get; set; }
        [DisplayName("Fornecedor")]
        [Required(ErrorMessage = "Informe o fornecedor")]
        public int? fornecedorId { get; set; }
        [DisplayName("Quantidade no Estoque")]
        public int quantityStock { get; set; }
        [DisplayName("Quantidade Minima")]
        [Required(ErrorMessage = "Informe a quantidade minima")]
        public int quantityMinimun { get; set; }
        [DisplayName("Imagem")]
        public string? image { get; set; }
        [DisplayName("Categoria")]
        [Required(ErrorMessage = "Informe a categoria")]
        public int categoryId { get; set; }
        public virtual FornecedorDTO? fornecedor { get; set; }
        public virtual CategoryDTO? category { get; set; }
        public virtual ICollection<InOutDTO>? inOutList { get; set; }

        public Product mapToEntity()
        {
            return new Product
            {
                Id = id,
                Name = name,
                FornecedorId = fornecedorId,
                QuantityStock = quantityStock,
                QuantityMinimun = quantityMinimun,
                Image = image,
                CategoryId = categoryId
            };
        }
        public ProductDTO mapToDTO(Product product)
        {
            return new ProductDTO()
            {
                id = product.Id,
                name = product.Name,
                fornecedorId = product.FornecedorId,
                quantityStock = product.QuantityStock,
                quantityMinimun = product.QuantityMinimun,
                image = product.Image,
                categoryId = product.CategoryId
            };
        }
    }
}
