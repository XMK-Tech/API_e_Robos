using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services.Utils
{
    public static class ServiceErrorHandle
    {
        public static dynamic ExceptionThreatment(List<string> ValidationMessages, int StatusCode, Exception ex)
        {
            StatusCode = 500;
            ValidationMessages.Add(ex.Message);

            if (ex.InnerException != null)
                ValidationMessages.Add(ex.InnerException.Message);

            return null;
        }
        public static bool ListNotEmpty<T>(IQueryable<T> query, List<string> ValidationMessages, int StatusCode, string nameOfEntity)
        {
            StatusCode = 200;
            if (query.ToList().Count == 0)
            {
                ValidationMessages.Add($"None {nameOfEntity} was found");
                return false;
            }

            return true;
        }

    }
}
