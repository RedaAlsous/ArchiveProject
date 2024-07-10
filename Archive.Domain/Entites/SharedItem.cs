
namespace Archive.Domain.Entites;

public class SharedItem
{
    public int Id { get; set; }
    public string SharedItemUserId { get; set; } = default!;

    public User User { get; set; } = null!;

    public List<Efile> SharedFiles { get; set; } = new();
    public List<Efolder> SharedFolders { get; set; } = new();

}
