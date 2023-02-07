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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(int id)
        {
            return await _repository.Delete(await _repository.FindById(id));
        }

        public List<CategoryDTO> FindAll()
        {
            return _repository.FindAll()
                                .Select(c => new CategoryDTO()
                                    {
                                        id = c.Id,
                                        name = c.Name,
                                    }).ToList();
                    
        }

        public async Task<CategoryDTO> FindById(int id)
        {
            var dto = new CategoryDTO();
            return dto.MapToDTO(await _repository.FindById(id));
        }

        public Task<int> Save(CategoryDTO dto)
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
