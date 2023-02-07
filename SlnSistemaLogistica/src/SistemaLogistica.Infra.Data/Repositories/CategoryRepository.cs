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
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly SQLServerContext _context;
        public CategoryRepository(SQLServerContext context) : base(context)
        {
        }
    }
}
