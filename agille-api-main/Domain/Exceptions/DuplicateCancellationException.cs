using System.Collections.Generic;

namespace AgilleApi.Domain.Exceptions;

public class DuplicateCancellationException : BadRequestException
{
    public DuplicateCancellationException(IEnumerable<string> validationMessages) 
        : base(validationMessages)
    {
    }

    public DuplicateCancellationException(string message) 
        : base(new[] { message })
    {
    }
}