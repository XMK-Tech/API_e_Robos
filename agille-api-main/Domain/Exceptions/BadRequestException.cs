using AgilleApi.Domain.Enums;
using System.Collections.Generic;

namespace AgilleApi.Domain.Exceptions;

public class BadRequestException : DomainException
{
    public BadRequestException(IEnumerable<string> validationMessages) : base(validationMessages, ErrorType.BadRequest)
    {
    }

    public BadRequestException(string message) : base(new[] { message }, ErrorType.BadRequest)
    {
    }
}