using System.ComponentModel.DataAnnotations;

namespace NZWalksAPI.Models.DTO
{
    public class UpdateRegionRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Code Min Length is 3")]
        [MaxLength(5, ErrorMessage = "Code Max Length is  5")]
        public string Code { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Name Has to be maximum of 100 Characters")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
