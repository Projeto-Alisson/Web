using AgendaNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Repositorio;
using Repositorio.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http;
using Newtonsoft.Json;

namespace AgendaNet.Controllers
{
    public class EstadoController : Controller
    {
        public IActionResult Index()
        {
            List<EstadoModel> estado = API<List<EstadoModel>>.get("estado/listar.php");
            return View(estado);
        }
    }
}
