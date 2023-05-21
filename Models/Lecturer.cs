namespace UniCalendar.Models;

public partial class Lecturer
{
    public int IdLecturer { get; set; }

    public string LecturerName { get; set; } = null!;

    public string LecturerBio { get; set; } = null!;

    public string LecturerUrl { get; set; } = null!;

    public byte[]? LecturerPhoto { get; set; }

    public string LecturerEmail { get; set; } = null!;

    public string LecturerRoles { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<Module> Modules { get; set; } = new List<Module>();
}
