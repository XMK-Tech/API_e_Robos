using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository;

public class ProprietyRepository : GenericRepository<Propriety>, IProprietyRepository
{
    public ProprietyRepository(Context _context) : base(_context)
    {
    }
}

public class ProprietyOwnerRepository : GenericRepository<ProprietyOwners>, IProprietyOwnerRepository
{
    public ProprietyOwnerRepository(Context _context) : base(_context)
    {
    }
}

public class ProprietyContactRepository : GenericRepository<ProprietyContact>, IProprietyContactRepository
{
    public ProprietyContactRepository(Context _context) : base(_context)
    {
    }
}

public class ProprietyCharacteristicsRepository : GenericRepository<ProprietyCharacteristics>, IProprietyCharacteristicsRepository
{
    public ProprietyCharacteristicsRepository(Context _context) : base(_context)
    {
    }
}

public class ProprietyAddressRepository : GenericRepository<ProprietyAddress>, IProprietyAddressRepository
{
    public ProprietyAddressRepository(Context _context) : base(_context)
    {
    }
}

public class ProprietyAttachmentRepository : GenericRepository<ProprietyAttachment>, IProprietyAttachmentRepository
{
    public ProprietyAttachmentRepository(Context _context) : base(_context)
    {
    }
}