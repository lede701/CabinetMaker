using CabinetMaker.Domain.Enums;

namespace CabinetMaker.Domain.Helpers;

public static class FractionHelper
{
    /// <summary>
    /// Converts a decimal inch value to the nearest fractional representation.
    /// e.g. 0.3937 at 1/32 precision → "13/32"
    ///      1.3937 at 1/32 precision → "1 13/32"
    /// </summary>
    public static string ToFractionalInches(decimal inches, FractionPrecision precision)
    {
        bool negative = inches < 0;
        decimal abs = Math.Abs(inches);
        int whole = (int)Math.Floor(abs);
        decimal fractional = abs - whole;

        int denominator = (int)precision;
        int numerator = (int)Math.Round(fractional * denominator);

        // Rounding pushed us to the next whole number
        if (numerator == denominator)
        {
            whole++;
            numerator = 0;
        }

        string result;
        if (numerator == 0)
        {
            result = whole.ToString();
        }
        else
        {
            int gcd = Gcd(numerator, denominator);
            string fraction = $"{numerator / gcd}/{denominator / gcd}";
            result = whole == 0 ? fraction : $"{whole} {fraction}";
        }

        return negative ? $"-{result}" : result;
    }

    /// <summary>
    /// Returns the exact decimal value of the nearest fraction so callers can show the rounding delta.
    /// </summary>
    public static decimal NearestFraction(decimal inches, FractionPrecision precision)
    {
        int denominator = (int)precision;
        bool negative = inches < 0;
        decimal abs = Math.Abs(inches);
        int whole = (int)Math.Floor(abs);
        decimal fractional = abs - whole;
        int numerator = (int)Math.Round(fractional * denominator);
        decimal result = whole + (decimal)numerator / denominator;
        return negative ? -result : result;
    }

    private static int Gcd(int a, int b) => b == 0 ? a : Gcd(b, a % b);
}
