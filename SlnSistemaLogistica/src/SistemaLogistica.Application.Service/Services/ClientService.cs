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
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;
        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(int id)
        {
            return await _repository.Delete(await _repository.FindById(id));
        }

        public List<ClientDTO> FindAll()
        {
            return _repository.FindAll()
                                .Select(c => new ClientDTO()
                                {
                                    id = c.Id,
                                    personId = c.PersonId,
                                    person = new PersonDTO()
                                    {
                                        id = c.Person.Id,
                                        name = c.Person.Name,
                                        cep = c.Person.CEP,
                                        country = c.Person.Country,
                                        uf = c.Person.UF,
                                        city = c.Person.City,
                                        neighbourhood = c.Person.Neighbourhood,
                                        street = c.Person.Street,
                                        number = c.Person.Number
                                    }
                                }).ToList();
        }

        public async Task<ClientDTO> FindById(int id)
        {
            var dto = new ClientDTO();
            return dto.mapToDTO(await _repository.FindById(id));
        }

        public Task<int> Save(ClientDTO dto)
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
