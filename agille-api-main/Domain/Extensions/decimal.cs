using System;

namespace AgilleApi.Domain.Extensions;

public static class DecimalExtensions
{
    public static decimal Round(this decimal number, int decimals = 2)
    {
        return Math.Round(number, 2);
    }
    public static string FormatValue(this decimal @value)
    {
        return @value.ToString("#,##0.00");
    }
}