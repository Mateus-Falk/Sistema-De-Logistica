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
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        private readonly SQLServerContext _context;
        public PersonRepository(SQLServerContext context) : base(context)
        {
        }
    }
}
