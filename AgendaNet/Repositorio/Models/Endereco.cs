using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class Endereco
    {
        public int CodEndereco { get; set; }
        public int? CodEmpresa { get; set; }
        public int? CodCidade { get; set; }
        public DateTime? DataEndereco { get; set; }

        public virtual Cidade CodCidadeNavigation { get; set; }
        public virtual Empresa CodEmpresaNavigation { get; set; }
    }
}
