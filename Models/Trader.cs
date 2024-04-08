
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TradePerformanceAPI.Models
{
    public class Trader
    {
     [Key]
     [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public  Guid Id { get; set; }
    public string Name { get; set; }
     public string Email { get; set; }

    }
}
