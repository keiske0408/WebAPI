using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models.Internal;

[Table("users_information")]
public class UsersInformation
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required] 
    [StringLength(50)] 
    public string FirstName { get; set; }

    [StringLength(50)] 
    public string MiddleName { get; set; }

    [StringLength(50)] 
    public string LastName { get; set; }

    [Required] 
    public UserLevel Level { get; set; }

    [Required] 
    public Status Status { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}

public enum UserLevel
{
    [Display(Name = "Admin")]
    ADMIN,
    
    [Display(Name = "Admin")]
    USER,
}

public enum Status
{
    [Display(Name = "Active")]
    ACTIVE,
    
    [Display(Name = "Inactive")]
    INACTIVE,
}
    
    
    
    