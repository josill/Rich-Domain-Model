using RichDomainModel.Rich.Exceptions;
using RichDomainModel.Rich.Seedwork;

namespace RichDomainModel.Rich.Aggregates.TimeEntry;

/// <summary>
/// Represents the time entry timer
/// </summary>
public class TimeEntryTimer : ValueObject<TimeEntryTimer>
{
    private static readonly DateTime MinimumStartTime = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    public DateTime StartTime { get; private set; }

    public DateTime? EndTime { get; private set; }

    public double DurationInSeconds => EndTime.HasValue 
        ? (EndTime.Value - StartTime).TotalSeconds 
        : (DateTime.UtcNow - StartTime).TotalSeconds;

    public bool IsRunning => !EndTime.HasValue;
    
    private TimeEntryTimer() {}

    public static TimeEntryTimer Create(DateTime startTime, DateTime? endTime = null)
    {
        Validate(startTime, endTime);

        return new TimeEntryTimer()
        {
            StartTime = startTime.ToUniversalTime(),
            EndTime = endTime?.ToUniversalTime(),
        };
    }

    private static void Validate(DateTime startTime, DateTime? endTime)
    {
        if (startTime < MinimumStartTime) throw DomainException.For<TimeEntryAggregate>($"Start time has to be bigger than: {MinimumStartTime}");
        if (endTime.HasValue && endTime.Value > startTime)
        {
            throw DomainException.For<TimeEntryAggregate>("End time can't be bigger than start time");
        }
    }

    public TimeEntryTimer UpdateStartTime(DateTime startTime)
    {
        if (startTime < MinimumStartTime) throw DomainException.For<TimeEntryAggregate>($"Start time has to be bigger than: {MinimumStartTime}");
        return Create(startTime, EndTime);
    }
    
    public TimeEntryTimer Stop(DateTime endTime)
    {
        if (!IsRunning) throw DomainException.For<TimeEntryAggregate>("Timer is already stopped");
        if (endTime <= StartTime) throw new ArgumentException("End time must be after start time", nameof(endTime));

        return Create(StartTime, endTime);
    }

    public TimeEntryTimer Restart() => Create(StartTime);

    public int GetDurationInMinutes() => (int)(DurationInSeconds / 60);
    
    protected override IEnumerable<object?> GetAttributesToIncludeInEqualityCheck()
    {
        yield return StartTime;
        yield return EndTime;
    }
}