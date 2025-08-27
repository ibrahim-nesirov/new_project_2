using System.ComponentModel.DataAnnotations;

namespace new_project_2.Models
{
    public class Musteri
    {
        [Key]
        public int idmusteriler { get; set; }

        [Required]
        public string musteriad { get; set; }

        [Required]
        public string musterisoyad { get; set; }

        public string musteriataadi { get; set; }

        public string Telefon { get; set; } 
    }
}

