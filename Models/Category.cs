using System;
using System.Collections.Generic;

namespace UniCalendar.Models;

public partial class Category
{
    public int IdCategory { get; set; }

    public string CategoryName { get; set; } = null!;

    public int ParentCategoryId { get; set; }

    public virtual ICollection<Modulecategory> Modulecategories { get; set; } = new List<Modulecategory>();

    public virtual Parentcategory ParentCategory { get; set; } = null!;
}
