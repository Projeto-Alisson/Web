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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;



        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<EmpresaModel> emp = API<List<EmpresaModel>>.get("/empresa/listar.php");
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            List<EmpresaModel> listaModel = mapper.Map<List<EmpresaModel>>(emp);


            return View(listaModel);
        }

        [HttpPost]
        public IActionResult Salvando(EmpresaModel model)
        {
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());

            try
            {
                if (ModelState.IsValid)
                {

                    if (model.senha_empresa == model.ConfirmaSenhaEmpresa)
                    {

                        if (model.cod_empresa == null)
                        {
                            API<EmpresaModel>.post("/empresa/inserir.php", model);
                            ModelState.Clear();
                            model = null;

                            ViewData["mensagem"] = "Conta criada com sucesso!";
                            ViewData["sucesso"] = "alert alert-success";
                        }
                        else
                        {
                            API<EmpresaModel>.post("/empresa/editar.php", model);
                            ModelState.Clear();
                            model = null;
                            ViewData["mensagem"] = "Dados alterados com sucesso!";
                            ViewData["sucesso"] = "alert alert-success";
                        }
                    }
                }
                else
                {
                    ViewData["mensagem"] = "Ops... seus dados não foram salvos.";
                    ViewData["sucesso"] = "alert alert-danger";
                }
            }
            catch (Exception ex)
            {
                ViewData["mensagem"] = "Ops.. Ocorreu um erro, pedimos desculpas. Por favor, entre em contato com o administrador do sistema. " + ex.Message;
                ViewData["sucesso"] = "alert alert-danger";
            }
            return View("Cadastrar", model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Cadastrar(int codigo)
        {
            if (codigo == 0)
            {
                return View(new EmpresaModel());
            }
            else
            {
                EmpresaModel emp = API<EmpresaModel>.post("/empresa/consultar.php", codigo);
                var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                return View(emp);
            }            
        }

        public IActionResult Logar()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public JsonResult getEstados()
        {
            Estado model = new Estado();

            List<Estado> lista = (new EstadoRepositorio()).GetEstados();
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            List<EstadoModel> listaModel = mapper.Map<List<EstadoModel>>(lista);

            return new JsonResult(listaModel);

        }

        public bool verificarCampos(Telefone telefone)
        {
            bool retorno = true;

            if (telefone.NumeroTelefone != "" || telefone.DddTelefone != "" || telefone.CodEmpresaNavigation.NomeEmpresa != ""
                || telefone.CodEmpresaNavigation.CnpjEmpresa != "" || telefone.CodEmpresaNavigation.LoginEmpresa != ""
                || telefone.CodEmpresaNavigation.SenhaEmpresa != "")
                retorno = true;
            else
                retorno = false;

            return retorno;
        }


        [HttpGet]
        public JsonResult getCidades(int estado)
        {
            List<VwCidadeEstado> lista = (new EstadoRepositorio()).GetCidades(estado);
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            List<vw_CidadeEstadoModel> listaModel = mapper.Map<List<vw_CidadeEstadoModel>>(lista);

            return new JsonResult(listaModel);
        }

        public IActionResult Excluir(int codigo)
        {
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            API<EmpresaModel>.post("/empresa/excluir.php", codigo);
            ModelState.Clear();

            ViewData["mensagem"] = "Conta criada com sucesso!";
            ViewData["sucesso"] = "alert alert-success";

            return RedirectToAction("Index");
        }
        

        //[HttpPost]
        //public IActionResult Salvar(TelefoneModel model)
        //{
        //    var mapper = new Mapper(AutoMapperConfig.RegisterMappings());

        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            Empresa emp = mapper.Map<Empresa>(model.empresa);
        //            Telefone tel = mapper.Map<Telefone>(model);
        //            //Endereco end = mapper.Map<Endereco>(model);

        //            if (verificarCampos(tel))
        //            {
        //                if (model.empresa.SenhaEmpresa == model.empresa.ConfirmaSenhaEmpresa)
        //                {

        //                    if ((new EmpresaRepositorio()).verificaCNPJ(model.empresa.CnpjEmpresa) == null)
        //                    {

        //                        if (model.empresa.CodEmpresa == 0)
        //                        {
        //                            (new EmpresaRepositorio()).add(emp);
        //                            tel.CodEmpresa = emp.CodEmpresa;
        //                            tel.DataTelefone = DateTime.Now;
        //                            //end.CodEmpresa = emp.CodEmpresa;

        //                            (new TelefoneRepositorio()).add(tel);
        //                            //(new EnderecoRepositorio()).add(end);
        //                            ViewData["mensagem"] = "Conta criada com sucesso!";
        //                            ViewData["sucesso"] = "alert alert-success";
        //                        }
        //                        else
        //                        {
        //                            (new EmpresaRepositorio()).edit(emp);
        //                            tel.CodEmpresa = emp.CodEmpresa;
        //                            //end.CodEmpresa = emp.CodEmpresa;

        //                            (new TelefoneRepositorio()).edit(tel);
        //                            //(new EnderecoRepositorio()).edit(end);
        //                            ViewData["mensagem"] = "Dados alterados com sucesso!";
        //                            ViewData["sucesso"] = "alert alert-success";
        //                        }
        //                    }
        //                    else
        //                    {
        //                        ViewData["mensagem"] = "O CNPJ informado já possui cadastro!";
        //                        ViewData["sucesso"] = "alert alert-danger";
        //                    }
        //                }
        //                else
        //                {
        //                    ViewData["mensagem"] = "Senha e Confirmação de Senha não coincidem.";
        //                    ViewData["sucesso"] = "alert alert-danger";
        //                }
        //            }
        //            else
        //            {
        //                ViewData["mensagem"] = "Por favor, preencha todos os campos.";
        //                ViewData["sucesso"] = "alert alert-danger";
        //            }
        //        }
        //        else
        //        {
        //            ViewData["mensagem"] = "Ops... seus dados não foram salvos.";
        //            ViewData["sucesso"] = "alert alert-danger";
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        ViewData["mensagem"] = "Ops.. Ocorreu um erro, pedimos desculpas. Por favor, entre em contato com o administrador do sistema. " + ex.Message;
        //        ViewData["sucesso"] = "alert alert-danger";
        //    }
        //    return View("Cadastrar", model);
        //}
    }
}
