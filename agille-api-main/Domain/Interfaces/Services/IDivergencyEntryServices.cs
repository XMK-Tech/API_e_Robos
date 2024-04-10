using System;
using System.Collections.Generic;
using AgilleApi.Domain.Entities;

namespace AgilleApi.Domain.Interfaces.Services {
    public interface IDivergencyEntryServices {
        List<DivergencyEntry> GetByIds(IEnumerable<Guid> ids);
    }
}