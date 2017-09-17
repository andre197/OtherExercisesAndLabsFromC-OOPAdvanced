using System;

public class WeeklyEntry : IComparable<WeeklyEntry>
{
    private WeekDay day;
    private string note;

    public WeeklyEntry(string weekday, string notes)
    {
        this.day = (WeekDay)Enum.Parse(typeof(WeekDay), weekday);
        this.note = notes;
    }

    public int CompareTo(WeeklyEntry other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }
        if (ReferenceEquals(null, other))
        {
            return 1;
        }
        var weekDay = this.day.CompareTo(other.day);
        if (weekDay == 0)
        {
            return string.Compare(this.note,other.note, StringComparison.Ordinal);
        }
        return weekDay;
    }

    public override string ToString() => $"{this.day} - {this.note}";
}