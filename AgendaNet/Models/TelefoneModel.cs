using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Repositorio.Models;

namespace AgendaNet.Models
{
    public class TelefoneModel
    {        
        [Key]
        [Display(Name = "codigo")]
        public int CodTelefone { get; set; }
        
        [Display(Name = "codigo_empresa")]
        public int? CodEmpresa { get; set; }

        [Display(Name = "DDD")]
        public string DddTelefone { get; set; }

        [Display(Name = "Telefone")]
        public string NumeroTelefone { get; set; }

        [Display(Name = "dataTelefone")]
        public DateTime? DataTelefone { get; set; }

        public EmpresaModel empresa { get; set; }
        public virtual Empresa IdEmpresaNavigation { get; set; }
    }
}
