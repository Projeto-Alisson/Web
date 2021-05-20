using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AgendaNet.Models
{
    public class EstadoModel
    {
        [Key]
        [Display(Name = "codigo")]
        public int CodEstado { get; set; }

        [Display(Name = "Sigla")]
        public string SiglaEstado { get; set; }

        [Display(Name = "Estado")]
        public string NomeEstado { get; set; }
    }
}
