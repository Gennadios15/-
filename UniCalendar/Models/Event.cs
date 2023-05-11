using System;
using System.Collections.Generic;

namespace UniCalendar.Models;

public partial class Event
{
    public int GoogleCalendarId { get; set; }

    public int EventId { get; set; }

    public int Idmodule { get; set; }

    public int Idlecturer { get; set; }

    public string EventName { get; set; } = null!;

    public string Eventdetails { get; set; } = null!;

    public DateOnly EventStartsOn { get; set; }

    public DateOnly EventsEndsOn { get; set; }

    public virtual Lecturer IdlecturerNavigation { get; set; } = null!;

    public virtual Module IdmoduleNavigation { get; set; } = null!;
}
