using SistemaLogistica.Domain.Entities;
using SistemaLogistica.Domain.IRepositories;
using SistemaLogistica.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLogistica.Infra.Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly SQLServerContext _context;
        public ProductRepository(SQLServerContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<int> SaveFile(int id,string fileName)
        {
            string sqlCommand = $"UPDATE [dbo].[Product] SET Image = '{fileName}' WHERE Id = {id}";
            return await ExecuteCommand(sqlCommand);
        }
    }
}
