using System;
using System.ComponentModel.DataAnnotations;

namespace ProvaTecnica.Models
{
    public class Log
    {
        [Key]
        public int Id { get; set; }
        public DateTime Momento { get; set; }

        [Display(Name = "Ação")]
        public string Acao { get; set; }
        public string Depois { get; set; }
        public string Antes { get; set; }
    }
}