namespace AspNet.Identity.AdoNet
{
    using System;
    using System.Globalization;

    /// <summary>Static class containing utility helper methods.</summary>
    static class Utilities
    {
        public static T ChangeType<T>(this object value)
        {
            return ChangeType<T>(value, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        /// <remarks>
        ///     Original code from:
        ///     http://www.siepman.nl/blog/post/2012/03/06/Convert-to-unknown-generic-type-ChangeType-T.aspx
        /// </remarks>
        public static T ChangeType<T>(this object value, CultureInfo cultureInfo)
        {
            if (value == null || value is DBNull)
                return default(T);

            var toType = typeof(T);
            if (value is string)
            {
                var stringValue = Convert.ToString(value, cultureInfo);

                if (toType == typeof(Guid))
                    return ChangeType<T>(new Guid(stringValue), cultureInfo);
                
                if (String.IsNullOrEmpty(stringValue) && toType != typeof(string))
                    return ChangeType<T>(null, cultureInfo);
            }
            else if (typeof(T) == typeof(string))
                return ChangeType<T>(Convert.ToString(value, cultureInfo), cultureInfo);

            if (toType.IsGenericType && toType.GetGenericTypeDefinition() == typeof(Nullable<>))
                toType = Nullable.GetUnderlyingType(toType);

#pragma warning disable S1944 // Inappropriate casts should not be made
            bool canConvert = toType is IConvertible || (toType.IsValueType && !toType.IsEnum);
#pragma warning restore S1944 // Inappropriate casts should not be made
            if (canConvert)
                return (T)Convert.ChangeType(value, toType, cultureInfo);

            return (T)value;
        }
    }
}