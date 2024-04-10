using System;

namespace AgilleApi.Domain.Extensions
{
    public static class GuidValidation
    {
        public static bool GuidIsValid(this Guid? guid)
        {
            if (guid != null && guid != Guid.Empty)
                return true;
            return false;
        }
        public static bool GuidIsInvalid(this Guid? guid)
        {
            return !GuidIsValid(guid);
        }
    }
}
