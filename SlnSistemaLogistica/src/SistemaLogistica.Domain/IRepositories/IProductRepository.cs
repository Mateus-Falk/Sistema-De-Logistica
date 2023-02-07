using SistemaLogistica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLogistica.Domain.IRepositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<int> SaveFile(int id, string fileName);
    }
}
