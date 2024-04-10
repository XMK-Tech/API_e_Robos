using AgilleApi.Domain.Enums;
using System.Collections.Generic;

namespace AgilleApi.Domain.Exceptions;

public class ConflictException : DomainException
{
    public ConflictException(IEnumerable<string> validationMessages) : base(validationMessages, ErrorType.Conflict)
    {
    }

    public ConflictException(string message) : base(new[] { message }, ErrorType.Conflict)
    {
    }
}