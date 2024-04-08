using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace TradePerformanceAPI.dtos.Trader
{
    public class TraderCreateDto
    {
      
        [Required]
        [StringLength(50)]
        [SwaggerSchema(Description = "The name of the trader")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [SwaggerSchema(Description = "The email address of the trader")]
        public string Email { get; set; }
    }
}
