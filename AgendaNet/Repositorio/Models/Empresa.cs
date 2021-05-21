using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class Empresa
    {
        public Empresa()
        {
            Enderecos = new HashSet<Endereco>();
            Telefones = new HashSet<Telefone>();
        }

        public int CodEmpresa { get; set; }
        public string NomeEmpresa { get; set; }
        public string CnpjEmpresa { get; set; }
        public string LoginEmpresa { get; set; }
        public string SenhaEmpresa { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }
    }
}
