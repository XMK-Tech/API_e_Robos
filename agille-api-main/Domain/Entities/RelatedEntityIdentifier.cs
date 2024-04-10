using AgilleApi.Domain.Shared;
using System;

namespace AgilleApi.Domain.Entities;

public class RelatedEntityIdentifier : Entity
{
    public RelatedEntityIdentifier() { }
    public RelatedEntityIdentifier(bool isFromMainEntity, Guid? relatedEntityId)
    {
        IsFromMainEntity = isFromMainEntity;
        RelatedEntityId = relatedEntityId;
    }

    public bool IsFromMainEntity { get; set; } = false;

    public Guid? RelatedEntityId { get; set; }
    public RelatedEntity RelatedEntity { get; set; }
}