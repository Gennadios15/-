using System;
using System.Collections.Generic;

namespace UniCalendar.Models;

public partial class Modulecategory
{
    public int IdModule { get; set; }

    public int IdCategory { get; set; }

    public DateOnly SinceWhen { get; set; }

    public virtual Category IdCategoryNavigation { get; set; } = null!;

    public virtual Module IdModuleNavigation { get; set; } = null!;
}
