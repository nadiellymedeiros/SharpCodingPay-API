using System.ComponentModel.DataAnnotations;

namespace SharpCodingAPI.Domains.Models;

public interface IEntity
{
   public int Id { get; set; }
}

public abstract class Entity : IEntity
{
 [Key]
 [Required]
  public int Id { get; set; }
}