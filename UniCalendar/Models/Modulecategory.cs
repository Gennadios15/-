namespace UniCalendar.Models;

public partial class Modulecategory
{
    public int IdModule { get; set; }

    public int IdCategory { get; set; }

    public DateTime SinceWhen { get; set; }

    public virtual Category IdCategoryNavigation { get; set; } = null!;

    public virtual Module IdModuleNavigation { get; set; } = null!;
}
