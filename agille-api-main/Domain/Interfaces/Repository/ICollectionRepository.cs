using AgilleApi.Domain.Entities;

namespace AgilleApi.Domain.Interfaces.Repository;

public interface ICollectionRepository : IGenericRepository<Collection>
{ }

public interface ICollectionAttachmentRepository : IGenericRepository<CollectionAttachment>
{ }