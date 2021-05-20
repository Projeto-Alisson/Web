using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class Cidade
    {
        public Cidade()
        {
            Enderecos = new HashSet<Endereco>();
        }

        public int CodCidade { get; set; }
        public int? CodEstado { get; set; }
        public string NomeCidade { get; set; }

        public virtual Estado CodEstadoNavigation { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
