using System;
using System.Collections.Generic;

namespace UniCalendar.Models;

public partial class Module
{
    public int IdModules { get; set; }

    public string ModuleName { get; set; } = null!;

    public string ModuleDesc { get; set; } = null!;

    public DateOnly CreatedSince { get; set; }

    public int TotalHours { get; set; }

    public int Lectures { get; set; }

    public int ModuleLeader { get; set; }

    public string GoogleCalendarId { get; set; } = null!;

    public string GoogleCalendarTitle { get; set; } = null!;

    public string? ModuleUrl { get; set; }

    public string? ModuleVideoUrl { get; set; }

    public string? ModuleFacebookGroup { get; set; }

    public decimal Price { get; set; }

    public string Online { get; set; } = null!;

    public string? Room { get; set; }

    public string? OnlineMethod { get; set; }

    public int Rating { get; set; }

    public string? Tags { get; set; }

    public string Active { get; set; } = null!;

    public string Lab { get; set; } = null!;

    public string Book { get; set; } = null!;

    public string ModuleType { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual Lecturer ModuleLeaderNavigation { get; set; } = null!;

    public virtual ICollection<Modulecategory> Modulecategories { get; set; } = new List<Modulecategory>();
}
