using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Wordnik.Dotnet.Client.Helpers
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Converts an enum into its API-specific string representation.
        /// Uses the DisplayAttribute if it is applied to the enum value.
        /// </summary>
        public static string ToApiString<TEnum>(this TEnum enumValue) where TEnum : Enum
        {
            var memberInfo = typeof(TEnum).GetMember(enumValue.ToString());
            var displayAttribute = memberInfo[0].GetCustomAttribute<DisplayAttribute>();

            return displayAttribute?.Name ?? enumValue.ToString();
        }
    }
}
