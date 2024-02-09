using System.ComponentModel.DataAnnotations.Schema;

namespace Cloth.Domain.Entities;

public abstract class Entity
{
    public Guid Id { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long AssociatedId { get; set; }

    public DateTime CreatedOn { get; set; }
}
