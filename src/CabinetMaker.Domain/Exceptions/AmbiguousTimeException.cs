namespace CabinetMaker.Domain.Exceptions;

public class AmbiguousTimeException : Exception
{
    public DateTime LocalDateTime { get; }
    public string IanaTimezoneId { get; }

    public AmbiguousTimeException(DateTime localDateTime, string ianaTimezoneId)
        : base($"The local time {localDateTime:O} is ambiguous in timezone '{ianaTimezoneId}' (DST fall-back overlap).")
    {
        LocalDateTime = localDateTime;
        IanaTimezoneId = ianaTimezoneId;
    }
}
