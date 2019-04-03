

using NetCore_InfraData.Data.Context;
using NetCore_InfraData.Domain.Entities;
using NetCore_InfraData.Domain.Interfaces.Repositories;

namespace NetCore_InfraData.Data.Repositories
{
    public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(DBContext context)
            : base(context)
        {
        }
    }
}
