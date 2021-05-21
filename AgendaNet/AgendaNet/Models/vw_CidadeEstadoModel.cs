using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Repositorio.Models;


namespace AgendaNet.Models
{
    public class vw_CidadeEstadoModel
    {
        [Display(Name ="Codigo_Cidade")]
        public int CodCidade { get; set; }

        [Display(Name = "Codigo_Estado")]
        public int CodEstado { get; set; }

        [Display(Name = "Cidade")]
        public string NomeCidade { get; set; }

        [Display(Name = "Estado")]
        public string NomeEstado { get; set; }

        [Display(Name = "Sigla")]
        public string SiglaEstado { get; set; }
    }
}
