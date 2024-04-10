using AgilleApi.Domain.Enums;
using System.Collections.Generic;

namespace AgilleApi.Domain.Exceptions;

public class NotFoundException : DomainException
{
    public NotFoundException(IEnumerable<string> validationMessages) : base(validationMessages, ErrorType.NotFound)
    {
    }

    public NotFoundException(string message) : base(new[] { message }, ErrorType.NotFound)
    {
    }
}