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
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;
        public PersonService(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(int id)
        {
            return await _repository.Delete(await _repository.FindById(id));
        }

        public List<PersonDTO> FindAll()
        {
            return _repository.FindAll()
                                .Select(p => new PersonDTO()
                                {
                                    id = p.Id,
                                    name = p.Name,
                                    cep = p.CEP,
                                    country = p.Country,
                                    uf = p.UF,
                                    city = p.City,
                                    neighbourhood = p.Neighbourhood,
                                    street = p.Street,
                                    number = p.Number
                                }).ToList();
        }

        public async Task<PersonDTO> FindById(int id)
        {
            var dto = new PersonDTO();
            return dto.mapToDTO(await _repository.FindById(id));
        }

        public Task<int> Save(PersonDTO dto)
        {
            if(dto.id > 0)
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
