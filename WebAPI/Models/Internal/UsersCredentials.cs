using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models.Internal;

[Table("users_credentials")]
public class UsersCredentials
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid id { get; set; }
    
    [Required]
    [StringLength(50)]
    [Column(TypeName = "varchar(50)")]
    public string Username { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(255)")]
    public string Password { get; set; }
    
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}