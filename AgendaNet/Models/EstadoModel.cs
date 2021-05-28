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
        public string cod_estado { get; set; }

        [Display(Name = "Sigla")]
        public string sigla_estado { get; set; }

        [Display(Name = "Estado")]
        public string nome_estado { get; set; }
    }
}
