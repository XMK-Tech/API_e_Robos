using System;
using System.Globalization;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;

namespace AgilleApi.Domain.Extensions;

/// <summary>
/// Set of extensions to speed up string handling.
/// </summary>
public static class StringExtensions
{
    public static string Patch(this string str, string patch)
    {
        return patch ?? str;
    }

    public static string SanitazeDocument(this string str)
    {
        return str
                .Replace("/", "")
                .Replace(".", "")
                .Replace("-", "");
    }

    public static string SanitazeCib(this string cib)
    {
        return cib
                ?.Replace(".", "")
                .Replace("-", "")
                .Replace("/", "")
                .Replace(" ", "");
    }

    /// <summary>
    /// Sanitizes a string by removing certain characters.
    /// </summary>
    /// <param name="str">The input string to sanitize.</param>
    /// <returns>The sanitized string.</returns>
    public static string Sanitize(this string str)
    {
        if (string.IsNullOrEmpty(str))
            return str;

        return SanitizeExpression().Compile()(str);
    }

    /// <summary>
    /// Creates an expression that sanitizes a string by removing certain characters.
    /// </summary>
    /// <returns>An expression representing the sanitization process.</returns>
    public static Expression<Func<string, string>> SanitizeExpression()
    {
        return str => str
                .ToLower()
                .Replace("\\", "")
                .Replace("/", "")
                .Replace(".", "")
                .Replace("-", "")
                .Replace(" ", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("'", "")
                .Replace("\t", "")
                .Replace("\n", "");
    }

    /// <summary>
    /// Removes diacritics (accented characters) from a string.
    /// </summary>
    /// <param name="str">The input string to remove diacritics from.</param>
    /// <returns>The string with diacritics removed.</returns>
    public static string RemoveDiacritics(this string str)
    {
        if (string.IsNullOrEmpty(str))
            return str;

        return RemoveDiacriticsExpression().Compile()(str);
    }

    /// <summary>
    /// Creates an expression that removes diacritics from a string.
    /// </summary>
    /// <returns>An expression representing the removal of diacritics.</returns>
    public static Expression<Func<string, string>> RemoveDiacriticsExpression()
    {
        return str => str
                .ToLower()
                .Replace("á", "a").Replace("à", "a").Replace("â", "a").Replace("ä", "a").Replace("ã", "a")
                .Replace("é", "e").Replace("è", "e").Replace("ê", "e").Replace("ë", "e")
                .Replace("í", "i").Replace("ì", "i").Replace("î", "i").Replace("ï", "i")
                .Replace("ó", "o").Replace("ò", "o").Replace("ô", "o").Replace("ö", "o").Replace("õ", "o")
                .Replace("ú", "u").Replace("ù", "u").Replace("û", "u").Replace("ü", "u")
                .Replace("ç", "c")
                .Replace("ñ", "n");
    }

    /// <summary>
    /// Removes diacritics (accented characters) from a string and then sanitizes it by removing certain characters.
    /// </summary>
    /// <param name="text">The input string to process.</param>
    /// <returns>The sanitized string with diacritics removed.</returns>
    public static string RemoveDiacriticsAndSanitize(this string text)
    {
        return RemoveDiacritics(text).Sanitize();
    }

    /// <summary>
    /// Formats a string representing a document (CPF or CNPJ) by sanitizing and applying the appropriate format.
    /// </summary>
    /// <param name="str">The input string representing a document.</param>
    /// <returns>The formatted document string.</returns>
    /// <exception cref="Exception">Thrown when the input string has an invalid format.</exception>
    public static string FormatDocument(this string str)
    {
        str = str.Sanitize();

        if (str.Length != 11 && str.Length != 14)
            throw new Exception("Invalid string format.");

        string patternCPF = @"^(\d{3})(\d{3})(\d{3})(\d{2})$";
        string patternCNPJ = @"^(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})$";

        if (str.Length == 11)
            return Regex.Replace(str, patternCPF, "$1.$2.$3-$4");
        else
            return Regex.Replace(str, patternCNPJ, "$1.$2.$3/$4-$5");
    }

    public static string RemoveAccentsFilter(this string text)
    {
        string normalizedString = text.Normalize(NormalizationForm.FormD);
        StringBuilder stringBuilder = new StringBuilder();

        foreach (var c in normalizedString)
        {
            UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            {
                stringBuilder.Append(c);
            }
        }

        return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
    }
}