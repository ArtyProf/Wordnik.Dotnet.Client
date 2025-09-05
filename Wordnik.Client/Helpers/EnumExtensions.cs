using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Wordnik.Client.Helpers
{
    /// <summary>
    /// Provides extension methods for enums to help convert them into API-specific formats or strings.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Converts an enum into its API-specific string representation.
        /// Uses the DisplayAttribute if it is applied to the enum value.
        /// </summary>
        public static string ToApiString<TEnum>(this TEnum enumValue) where TEnum : Enum
        {
            if (!Enum.IsDefined(typeof(TEnum), enumValue))
            {
                throw new ArgumentException($"The value '{Convert.ToInt32(enumValue)}' is not valid for enum '{typeof(TEnum).Name}'.");
            }

            var memberInfo = typeof(TEnum).GetMember(enumValue.ToString());
            var displayAttribute = memberInfo[0].GetCustomAttribute<DisplayAttribute>();

            return displayAttribute?.Name ?? enumValue.ToString();
        }
    }
}
