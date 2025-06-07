
using System.ComponentModel.DataAnnotations;

namespace med_consult_api.src.domain;

public class User
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public required string Email { get; set; }

}