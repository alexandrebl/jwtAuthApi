using System.ComponentModel.DataAnnotations;

namespace jwtAuthApi.Domain.ViewModel
{
    public sealed class UserModel
    {
        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        public string UserName { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(16)]
        public string Password { get; set; }
    }
}