
using NetCore_InfraData.Domain.Entities;
using NetCore_InfraData.Domain.Interfaces.Repositories;
using NetCore_InfraData.Domain.Interfaces.Services;

namespace NetCore_InfraData.Domain.Services
{
    public class CategoriaService : ServiceBase<Categoria>, ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
            : base(categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
    }
}
