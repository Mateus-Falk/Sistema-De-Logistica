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
    public class InOutService : IInOutService
    {
        private readonly IInOutRepository _repository;
        public InOutService(IInOutRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(int id)
        {
            return await _repository.Delete(await _repository.FindById(id));
        }

        public List<InOutDTO> FindAll()
        {
            return _repository.FindAll()
                                .Select(i => new InOutDTO()
                                {
                                    id = i.Id,
                                    inOrOut= i.InOrOut,
                                    time = i.Time,
                                    userName = i.UserName,
                                    quantity = i.Quantity,
                                    clientId = i.ClientId,
                                    productId = i.ProductId,
                                    client = new ClientDTO()
                                    {
                                        person = new PersonDTO()
                                        {
                                            name = i.Client.Person.Name
                                        }
                                        
                                    },
                                    product = new ProductDTO()
                                    {
                                        id = i.Product.Id,
                                        name = i.Product.Name,
                                    }
                                }).ToList();
        }

        public async Task<InOutDTO> FindById(int id)
        {
            var dto = new InOutDTO();
            return dto.mapToDTO(await _repository.FindById(id));
        }

        public Task<int> Save(InOutDTO dto)
        {
            if (dto.id > 0)
            {
                return _repository.Update(dto.mapToEntity());
            }
            else
            {
                return _repository.Save(dto.mapToEntity());
            }
        }
    }
}
