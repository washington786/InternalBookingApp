using System.ComponentModel.DataAnnotations;

namespace InternalBookingApp.DTOs.Resource;

public record class UpdateResourceDto(
    [Required][StringLength(250)]
    string Name,
    [Required][StringLength(250)]
    string Description,
    [Required] [StringLength(250)]
    string Location,
    [Range(1,int.MaxValue,ErrorMessage ="Capacity must be greater than 1")]
    int Capacity,
    bool IsAvailable
)
{

}
