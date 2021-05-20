using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio.Models;

namespace Repositorio
{
    public class EstadoRepositorio
    {
        public List<Estado> GetEstados()
        {
            List<Estado> lista = null;
            using (agendanetContext db = new agendanetContext())
            {
                lista = (from e in db.Estados
                         orderby e.NomeEstado
                         select e).ToList();
            }
            return lista;
        }
    }
}
