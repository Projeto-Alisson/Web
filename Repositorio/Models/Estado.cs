using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Cidades = new HashSet<Cidade>();
        }

        public int CodEstado { get; set; }
        public string SiglaEstado { get; set; }
        public string NomeEstado { get; set; }

        public virtual ICollection<Cidade> Cidades { get; set; }
    }
}
