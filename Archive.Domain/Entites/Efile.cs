
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Archive.Domain.Entites;

public class Efile
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Path { get; set; } = default!;
    public long Size { get; set; }
    public string Type { get; set; } = default!;

    public DateOnly CreatedDate { get; set; }
    public DateOnly ModifiedDate { get; set; }

    public int EfolderId { get; set; }

    //public int SharedFileId { get; set; }

}
