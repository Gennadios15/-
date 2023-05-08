using System;
using System.Collections.Generic;

namespace UniCalendar.Models;

public partial class Interest
{
    public int IdInterest { get; set; }

    public int ModuleId { get; set; }

    public int EventId { get; set; }

    public string Username { get; set; } = null!;

    public string? Comment { get; set; }

    public string Email { get; set; } = null!;
}
