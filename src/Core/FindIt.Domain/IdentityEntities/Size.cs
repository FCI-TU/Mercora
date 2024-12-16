namespace FindIt.Domain.IdentityEntities;
public class Size
{
    [Key]
    public int SizeId { get; set; }

    [Required]
    public string Label { get; set; } = null!;
}
