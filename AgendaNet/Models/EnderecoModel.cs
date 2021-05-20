using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Repositorio.Models;

namespace AgendaNet.Models
{
    public class EnderecoModel
    {
        [Key]
        [Display(Name = "codigo")]
        public int CodEndereco { get; set; }

        [Display(Name = "codigo_emprsa")]
        public int? CodEmpresa { get; set; }

        [Display(Name = "codigo_cidade")]
        public int? CodCidade { get; set; }

        [Display(Name = "dataEndereco")]
        public DateTime? DataEndereco { get; set; }

        public EmpresaModel empresa { get; set; }
        public virtual Empresa IdEmpresaNavigation { get; set; }
    }
}
