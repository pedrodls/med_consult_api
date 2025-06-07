
using System.ComponentModel.DataAnnotations;

namespace med_consult_api.src.models;

public class User
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public string Email { get; set; }

}