
using NetCore_InfraData.Data.Interfaces;

namespace NetCore_InfraData.Application.Services
{
    public class AppService
    {
        private readonly IUnitOfWork _uow;

        public AppService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Commit()
        {
            _uow.Commit();
        }
    }
}
