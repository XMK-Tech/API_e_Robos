using AgilleApi.Domain.Enums;
using System.Collections.Generic;

namespace AgilleApi.Domain.Exceptions;

public class UnauthorizedException : DomainException
{
    public UnauthorizedException(IEnumerable<string> validationMessages)
        : base(validationMessages, ErrorType.Unauthorized)
    { }

    public UnauthorizedException(string message)
        : base(new[] { message }, ErrorType.Unauthorized)
    { }

    public static UnauthorizedException BuildExceptionPermission(string[] permissions)
    {
        if (permissions.Length > 1)
        {
            var permission = BuildPermissionsMessage(permissions);
            return new UnauthorizedException($"É necessario ter ao menos uma das seguintes permissões: {permission} para ter acesso a essa função");
        }
        else
            return new UnauthorizedException($"É necessario ter a permissão {permissions[0]} para ter acesso a essa função");
    }

    private static string BuildPermissionsMessage(string[] permissions)
    {
        var permissionsMessage = "";
        for (var i = 0; i < permissions.Length; i++)
        {
            if (i == 0)
                permissionsMessage += $"'{permissions[i]}'";
            else if (i == permissions.Length - 1)
                permissionsMessage += $" ou '{permissions[i]}'";
            else
                permissionsMessage += $", '{permissions[i]}'";
        }
        return permissionsMessage;
    }
}