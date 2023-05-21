namespace UniCalendar.Models;

public partial class Parentcategory
{
    public int IdParentCategory { get; set; }

    public string ParentCategoryName { get; set; } = null!;

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
