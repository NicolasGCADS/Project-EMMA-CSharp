using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMMAModel
{
    public class Reading
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdReading { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; } = null!;
        public string Humor { get; set; } = null!;
    }
}
