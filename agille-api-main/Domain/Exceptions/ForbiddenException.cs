using AgilleApi.Domain.Enums;
using System.Collections.Generic;

namespace AgilleApi.Domain.Exceptions;

public class ForbiddenException : DomainException
{
    public ForbiddenException(IEnumerable<string> validationMessages) : base(validationMessages, ErrorType.Forbidden)
    {
    }

    public ForbiddenException(string message) : base(new[] { message }, ErrorType.Forbidden)
    {
    }
}