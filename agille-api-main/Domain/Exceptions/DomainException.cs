using AgilleApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgilleApi.Domain.Exceptions;

public abstract class DomainException : Exception
{
    public IEnumerable<string> ValidationMessages;
    public ErrorType ErrorType;
    public DomainException(IEnumerable<string> validationMessages, ErrorType errorType): base(validationMessages.FirstOrDefault())
    {
        ValidationMessages = validationMessages;
        ErrorType = errorType;
    }
}