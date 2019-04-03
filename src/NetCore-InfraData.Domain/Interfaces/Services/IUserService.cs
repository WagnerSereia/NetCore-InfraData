using NetCore_InfraData.Domain.Entities;
using System;

namespace NetCore_InfraData.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Guid GetUserId();
        bool IsAuthenticated();
        bool IsValidUserAndPasswordCombination(string login, string senha);
        User GetUser();
    }
}
