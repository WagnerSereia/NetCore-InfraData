using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore_InfraData.Data.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
