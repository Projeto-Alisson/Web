using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Repositorio
{
    public class EmpresaRepositorio : BaseRepository<Empresa>
    {
        public Empresa verificaCNPJ(String email)
        {
            Empresa obj = null;

            using (agendanetContext db = new agendanetContext())
            {
                obj = (from e in db.Empresas
                       where e.CnpjEmpresa == email
                       select e).FirstOrDefault();    
            }

            return obj;
        }
    }
}
