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
    public class InOutRepository : BaseRepository<InOut>, IInOutRepository
    {
        private readonly SQLServerContext _context;
        public InOutRepository(SQLServerContext context) : base(context)
        {
        }
    }
}
