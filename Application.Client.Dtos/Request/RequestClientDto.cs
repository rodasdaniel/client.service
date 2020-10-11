using System;
using System.ComponentModel.DataAnnotations;
namespace Application.Client.Dtos
{
    public class RequestClientDto : ClientDataDto
    {
        [Required(ErrorMessage = "The city ID is required."),
            RegularExpression(@"^[0-9]*$", ErrorMessage = "The city ID format is not valid."),
            Range(1, int.MaxValue, ErrorMessage = "The city ID value is outside the allowed range.")]
        public int IdCity { get; set; }
        [Required(ErrorMessage = "The address is required."),
            StringLength(200, ErrorMessage = "The address exceeds the number of characters allowed.")]
        public string Address { get; set; }
    }
}
