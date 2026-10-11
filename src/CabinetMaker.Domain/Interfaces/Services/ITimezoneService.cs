namespace CabinetMaker.Domain.Interfaces.Services;

public interface ITimezoneService
{
    DateTime ToUtc(DateTime localDateTime, string ianaTimezoneId);
    DateTime ToLocal(DateTime utcValue, string ianaTimezoneId);
    string GetUserTimezone();
}
