using System.ComponentModel.DataAnnotations;

namespace FinishLine.Models;

public class Entity
{
    [Key]
    public Guid Id { get; set; }

}