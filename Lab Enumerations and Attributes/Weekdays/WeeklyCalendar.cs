using System.Collections.Generic;

public class WeeklyCalendar
{
    private IList<WeeklyEntry> schedule;

    public WeeklyCalendar()
    {
        this.schedule = new List<WeeklyEntry>();
    }

    public IEnumerable<WeeklyEntry> WeeklySchedule => schedule;

    public void AddEntry(string weekday, string notes)
    {
        this.schedule.Add(new WeeklyEntry(weekday, notes));
    }
}

