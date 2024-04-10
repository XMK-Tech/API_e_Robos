using System;
using System.Linq;
using System.Linq.Expressions;

namespace AgilleApi.Domain.Extensions;

/// <summary>
/// Set of extensions to speed up query handling.
/// </summary>
public static class QueryableExtensions
{
    /// <summary>
    /// Filters the elements of an IQueryable based on a specified condition and predicate.
    /// </summary>
    /// <param name="condition">The condition to evaluate. If null or false, the filter is not applied.</param>
    /// <param name="predicate">An expression that defines the filter to apply.</param>
    /// <returns>An IQueryable that contains elements from the input sequence that satisfy the specified condition and predicate.</returns>
    public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool? condition, Expression<Func<T, bool>> predicate)
    {
        var final = condition ?? false;
        return final ? query.Where(predicate) : query;
    }

    /// <summary>
    /// Filters the elements of an IQueryable based on a specified condition and predicate.
    /// </summary>
    /// <param name="condition">The condition to evaluate. If string is null or empty, the filter is not applied.</param>
    /// <param name="predicate">An expression that defines the filter to apply.</param>
    /// <returns>An IQueryable that contains elements from the input sequence that satisfy the specified condition and predicate.</returns>
    public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, string condition, Expression<Func<T, bool>> predicate)
    {
        return WhereIf(query, !string.IsNullOrEmpty(condition), predicate);
    }

    /// <summary>
    /// Filters the elements of an IQueryable based on a specified condition and predicate.
    /// </summary>
    /// <param name="condition">The condition to evaluate. If null, the filter is not applied.</param>
    /// <param name="predicate">An expression that defines the filter to apply.</param>
    /// <returns>An IQueryable that contains elements from the input sequence that satisfy the specified condition and predicate.</returns>
    public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, object condition, Expression<Func<T, bool>> predicate)
    {
        var final = condition != null;
        return WhereIf(query, final, predicate);
    }

    /// <summary>
    /// Filters the elements of an IQueryable based on a predicate.
    /// </summary>
    /// <param name="predicate">An expression that defines the filter to apply.</param>
    /// <returns>An IQueryable that contains elements from the input sequence that satisfy the specified condition and predicate.</returns>
    public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, Expression<Func<T, bool>> predicate)
    {
        return WhereIf(query, predicate, predicate);
    }

    /// <summary>
    /// Filters the elements of an IQueryable based on a specified condition and predicate.
    /// </summary>
    /// <param name="condition">The condition to evaluate. If null, the filter is not applied.</param>
    /// <param name="predicate">An expression that defines the filter to apply.</param>
    /// <returns>An IQueryable that contains elements from the input sequence that satisfy the specified condition and predicate.</returns>
    public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, Guid? condition, Expression<Func<T, bool>> predicate)
    {
        var final = condition.HasValue && condition.Value != Guid.Empty;
        return WhereIf(query, final, predicate);
    }

    /// <summary>
    /// Sorts the elements of an IQueryable based on a specified property and direction.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the IQueryable.</typeparam>
    /// <param name="direction">The direction in which to sort the elements (either "asc" or "desc").</param>
    /// <param name="predicate">An expression that selects the property to use for sorting.</param>
    /// <returns>An IQueryable that contains elements from the input sequence sorted based on the specified property and direction.</returns>
    public static IQueryable<T> Sort<T>(this IQueryable<T> query, string direction, Expression<Func<T, object>> predicate)
    {
        direction = direction?.ToLower();
        return direction == "desc" ? query.OrderByDescending(predicate) : query.OrderBy(predicate);
    }

    /// <summary>
    /// Filters query elements ignoring accentuation and based.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the IQueryable.</typeparam>
    /// <param name="target">The string parameter to sanitize and escape.</param>
    /// <param name="selector">An expression that selects the property to compare.</param>
    /// <returns>An IQueryable that contains elements from the input sequence that match the parameter.</returns>
    public static IQueryable<T> WhereLike<T>(this IQueryable<T> query, string target, Expression<Func<T, string>> selector)
    {
        target = target?.RemoveDiacritics();
        return ApplyDiacriticsGenericFilter(query, target, selector);
    }

    /// <summary>
    /// Filters query elements ignoring accentuation and based on a sanitized comparison.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the IQueryable.</typeparam>
    /// <param name="target">The string parameter to sanitize and escape.</param>
    /// <param name="selector">An expression that selects the property to compare.</param>
    /// <returns>An IQueryable that contains elements from the input sequence that match the parameter.</returns>
    public static IQueryable<T> WhereLikeSanitized<T>(this IQueryable<T> query, string target, Expression<Func<T, string>> selector)
    {
        target = target?.RemoveDiacriticsAndSanitize();
        return ApplyDiacriticsGenericFilter(query, target, selector, sanitize: true);
    }

    private static IQueryable<T> ApplyDiacriticsGenericFilter<T>(IQueryable<T> query, string target, Expression<Func<T, string>> selector, bool sanitize = false)
    {
        if (string.IsNullOrEmpty(target))
            return query;

        var parameter = selector.Parameters[0];
        var selectorBody = selector.Body;

        // Converts to lowercase 
        var targetExpr = Expression.Constant(target);
        var toLower = Expression.Call(selectorBody, "ToLower", Type.EmptyTypes);

        // Removes diacritics
        var diacriticsExpression = StringExtensions.RemoveDiacriticsExpression();
        var removeDiacritics = Expression.Invoke(diacriticsExpression, toLower);

        // Sanitize
        Expression<Func<string, string>> sanitizeExpression = StringExtensions.SanitizeExpression();
        if (sanitize)
            removeDiacritics = Expression.Invoke(sanitizeExpression, removeDiacritics);

        // Create expression for EF's Contains method
        var method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
        var containsMethod = Expression.Call(removeDiacritics, method, targetExpr);

        // Combine the expressions
        var lambda = Expression.Lambda<Func<T, bool>>(containsMethod, parameter);

        return query.Where(lambda);
    }

    /// <summary>
    /// Filters the elements of an IQueryable based on a range of values for a given property.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the IQueryable.</typeparam>
    /// <typeparam name="U">The type of the property used for comparison, which must implement the IComparable interface.</typeparam>
    /// <param name="selector">An expression that selects the property to compare against the range.</param>
    /// <returns>An IQueryable that contains elements from the input sequence that fall within the specified range.</returns>
    public static IQueryable<T> WhereInRange<T, U>(this IQueryable<T> query, object minValue, object maxValue, Expression<Func<T, U>> selector)
        where U : IComparable
    {
        if (minValue == null && maxValue == null)
            return query;

        var parameter = selector.Parameters.Single();
        var property = selector.Body as MemberExpression;

        var minValueExpression = minValue != null ? Expression.GreaterThanOrEqual(property, Expression.Constant(minValue, minValue.GetType())) : null;
        var maxValueExpression = maxValue != null ? Expression.LessThanOrEqual(property, Expression.Constant(maxValue, maxValue.GetType())) : null;

        var rangeExpression = minValueExpression ?? maxValueExpression;
        if (minValueExpression != null && maxValueExpression != null)
            rangeExpression = Expression.AndAlso(minValueExpression, maxValueExpression);

        var predicate = Expression.Lambda<Func<T, bool>>(rangeExpression, parameter);

        return query.Where(predicate);
    }
}