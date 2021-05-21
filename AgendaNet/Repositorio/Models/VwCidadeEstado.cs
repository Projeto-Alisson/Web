using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class VwCidadeEstado
    {
        public int CodCidade { get; set; }
        public int CodEstado { get; set; }
        public string NomeCidade { get; set; }
        public string NomeEstado { get; set; }
        public string SiglaEstado { get; set; }
    }
}
