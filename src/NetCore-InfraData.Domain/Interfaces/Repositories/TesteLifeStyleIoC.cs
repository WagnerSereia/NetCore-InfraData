using System;

namespace NetCore_InfraData.Domain.Interfaces.Repositories
{
    public class OperationService
    {
        public ITesteTransient TransientOperation { get; }
        public ITesteScoped ScopedOperation { get; }
        public ITesteSingleton SingletonOperation { get; }
        public ITesteSingletonInstance SingletonInstanceOperation { get; }

        public OperationService(ITesteTransient transientOperation,
            ITesteScoped scopedOperation,
            ITesteSingleton singletonOperation,
            ITesteSingletonInstance instanceOperation)
        {
            TransientOperation = transientOperation;
            ScopedOperation = scopedOperation;
            SingletonOperation = singletonOperation;
            SingletonInstanceOperation = instanceOperation;
        }
    }

    public class TesteLifeStyleIoC: ITesteTransient, ITesteScoped, ITesteSingleton, ITesteSingletonInstance
    {
        public Guid Id { get; set; }
        public TesteLifeStyleIoC()
        {
            Id = Guid.NewGuid();
        }
        public TesteLifeStyleIoC(Guid id)
        {
            if(id == Guid.Empty)
                Id = Guid.NewGuid();
        }
    }
    public interface ITesteLifeStyleIoC
    {
        Guid Id { get; }
    }

    public interface ITesteTransient : ITesteLifeStyleIoC
    {
    }
    public interface ITesteScoped : ITesteLifeStyleIoC
    {
    }
    public interface ITesteSingleton : ITesteLifeStyleIoC
    {
    }
    public interface ITesteSingletonInstance : ITesteLifeStyleIoC
    {
    }
}