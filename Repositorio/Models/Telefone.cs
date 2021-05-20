using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class Telefone
    {
        public int CodTelefone { get; set; }
        public int? CodEmpresa { get; set; }
        public string DddTelefone { get; set; }
        public string NumeroTelefone { get; set; }
        public DateTime? DataTelefone { get; set; }

        public virtual Empresa CodEmpresaNavigation { get; set; }

    }
}
