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
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _repository;
        public FornecedorService(IFornecedorRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(int id)
        {
            return await _repository.Delete(await _repository.FindById(id));
        }

        public List<FornecedorDTO> FindAll()
        {
            return _repository.FindAll()
                                .Select(c => new FornecedorDTO()
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

        public async Task<FornecedorDTO> FindById(int id)
        {
            var dto = new FornecedorDTO();
            return dto.mapToDTO(await _repository.FindById(id));
        }

        public Task<int> Save(FornecedorDTO dto)
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
