namespace FitnessApp.Core.Plan;

public enum DurationType
{
    Day=1,
    Week=7,
    Month=30
}
public static class DurationTypeExtensions
{
    public static string ToFriendlyString(this DurationType duration)
    {
        return duration switch
        {
            DurationType.Day => "1 Day",
            DurationType.Week => "7 Days",
            DurationType.Month => "30 Days",
            _ => $"{(int)duration} Days"
        };
    }
}
