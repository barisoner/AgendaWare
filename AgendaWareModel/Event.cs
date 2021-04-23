using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaWare.Models
{
    public class Event
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Başlık Ekleyiniz")]
        [Column(TypeName ="nvarchar(100)")]
        public string title { get; set; }

        [Required(ErrorMessage = "Başlangıç Tarihi Ekleyiniz")]
        public DateTime start { get; set; }

        [Required(ErrorMessage = "Bitiş Tarihi Ekleyiniz")]
        public DateTime end { get; set; }

        [Column(TypeName ="nvarchar(10)")]
        public string color { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string textColor { get; set; }
    }
}
