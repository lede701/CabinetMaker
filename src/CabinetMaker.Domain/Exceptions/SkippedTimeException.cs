namespace CabinetMaker.Domain.Exceptions;

public class SkippedTimeException : Exception
{
    public DateTime LocalDateTime { get; }
    public string IanaTimezoneId { get; }

    public SkippedTimeException(DateTime localDateTime, string ianaTimezoneId)
        : base($"The local time {localDateTime:O} does not exist in timezone '{ianaTimezoneId}' (DST spring-forward gap).")
    {
        LocalDateTime = localDateTime;
        IanaTimezoneId = ianaTimezoneId;
    }
}
