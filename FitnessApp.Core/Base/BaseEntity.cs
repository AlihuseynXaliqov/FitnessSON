namespace FitnessApp.Core.Base;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdateAt { get; set; } = DateTime.UtcNow;
}