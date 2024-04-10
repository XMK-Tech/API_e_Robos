using AgilleApi.Domain.Entities;

namespace AgilleApi.Domain.Interfaces.Repository;

public interface IProprietyRepository : IGenericRepository<Propriety>
{
}

public interface IProprietyOwnerRepository : IGenericRepository<ProprietyOwners>
{
}

public interface IProprietyContactRepository : IGenericRepository<ProprietyContact>
{
}

public interface IProprietyCharacteristicsRepository : IGenericRepository<ProprietyCharacteristics>
{
}

public interface IProprietyAddressRepository : IGenericRepository<ProprietyAddress>
{
}

public interface IProprietyAttachmentRepository : IGenericRepository<ProprietyAttachment>
{
}