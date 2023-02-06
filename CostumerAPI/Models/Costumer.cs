
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CostumerAPI.Models
{
    //[Table("costumer", Schema = "dbo")]
    public class Costumer
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("costumer_id")]
        public int CostumerId { get; set; }

        [Column("costumer_name")]
        public string CostumerName { get; set; }

        [Column("mobile_no")]
        public string MobileNumber { get; set; }

        [Column("email")]
        public string Email { get; set; }
    }
}
