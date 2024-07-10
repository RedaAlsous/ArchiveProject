

namespace Archive.Domain.Entites;

public class Efolder
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Path { get; set; } = default!;

    public DateOnly CreatedDate { get; set; }

    public DateOnly ModifiedDate { get; set; }

    public List<Efile> files { get; set; } = new();

    public List<Efolder> SubFolders { get; set; } = new();

    //public int SharedFoldereId { get; set; }
}
