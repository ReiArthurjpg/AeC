using System.Text.RegularExpressions;
namespace AeC.Shared.Extensions;
public static class StringExtensions
{
    public static string OnlyDigits(this string? value) => Regex.Replace(value ?? string.Empty, "\\D", string.Empty);
    public static string Clean(this string? value) => (value ?? string.Empty).Trim();
}
