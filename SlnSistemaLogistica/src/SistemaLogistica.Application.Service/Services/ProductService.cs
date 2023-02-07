using SistemaLogistica.Domain.DTO;
using SistemaLogistica.Domain.IRepositories;
using SistemaLogistica.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLogistica.Application.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(int id)
        {
            return await _repository.Delete(await _repository.FindById(id));
        }

        public List<ProductDTO> FindAll()
        {
            return _repository.FindAll()
                .Select(p => new ProductDTO()
                {
                    id = p.Id,
                    name = p.Name,
                    fornecedorId = p.FornecedorId,
                    quantityStock = p.QuantityStock,
                    quantityMinimun = p.QuantityMinimun,
                    image = p.Image,
                    categoryId = p.CategoryId,
                    fornecedor = new FornecedorDTO()
                    {
                        id = p.Fornecedor.Id,
                        personId = p.Fornecedor.PersonId,
                        person = new PersonDTO()
                        {
                            id = p.Fornecedor.Person.Id,
                            name = p.Fornecedor.Person.Name,
                            cep = p.Fornecedor.Person.CEP,
                            country = p.Fornecedor.Person.Country,
                            uf = p.Fornecedor.Person.UF,
                            city = p.Fornecedor.Person.City,
                            neighbourhood = p.Fornecedor.Person.Neighbourhood,
                            street = p.Fornecedor.Person.Street,
                            number = p.Fornecedor.Person.Number
                        }
                    },
                    category = new CategoryDTO()
                    {
                        id = p.Category.Id, 
                        name = p.Category.Name
                    }
                }).ToList();
        }

        public async Task<ProductDTO> FindById(int id)
        {
            var dto = new ProductDTO();
            return dto.mapToDTO(await _repository.FindById(id));
        }

        public Task<int> Save(ProductDTO dto)
        {
            if(dto.id > 0) {
                return _repository.Update(dto.mapToEntity());
            }
            else
            {
                return _repository.Update(dto.mapToEntity());
            }
        }

        public async Task<int> SaveFile(int id,string fileName)
        {
            return await _repository.SaveFile(id,fileName);
        }
    }
}
