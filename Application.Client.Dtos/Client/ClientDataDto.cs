using System;
using System.ComponentModel.DataAnnotations;
namespace Application.Client.Dtos
{
    public class ClientDataDto : SpaceDto
    {
        public long IdClient { get; set; }
        [Required(ErrorMessage = "The type of identification is required."),
            RegularExpression(@"^[0-9]*$", ErrorMessage = "The identification type format is not valid."),
            Range(1, 6, ErrorMessage = "The value of the identification type is outside the allowed range.")]
        public int IdIdentificationType { get; set; }
        [Required(ErrorMessage = "Identification is required."),
            StringLength(11, ErrorMessage = "Identification exceeds the number of characters allowed.")]
        public string Identification { get; set; }
        [Required(ErrorMessage = "The name is required."),
            StringLength(100, ErrorMessage = "The name exceeds the number of characters allowed.")]
        public string Names { get; set; }
        [Required(ErrorMessage = "The last name is required."),
            StringLength(100, ErrorMessage = "The last name exceeds the number of characters allowed.")]
        public string LastNames { get; set; }
        [Required(ErrorMessage = "The mobile phone number is required."),
            StringLength(15, ErrorMessage = "The mobile phone value exceeds the number of characters allowed.")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Email is required."),
            StringLength(100, ErrorMessage = "The email exceeds the number of characters allowed."),
            EmailAddress(ErrorMessage = "The email format is not valid.")]
        public string Email { get; set; }
    }
}
