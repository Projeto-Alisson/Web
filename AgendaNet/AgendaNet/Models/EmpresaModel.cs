using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Repositorio.Models;

namespace AgendaNet.Models
{
    public class EmpresaModel
    {
        [Key]
        [Display(Name = "codigo")]
        public int CodEmpresa { get; set; }
        
        [Display(Name ="Nome")]
        public string NomeEmpresa { get; set; }

        [Display(Name = "CNPJ")]
        public string CnpjEmpresa { get; set; }

        [Display(Name = "Login")]
        public string LoginEmpresa { get; set; }

        [Display(Name = "Senha")]
        public string SenhaEmpresa { get; set; }
        public string ConfirmaSenhaEmpresa { get; set; }

        public Telefone telefone;
        public Endereco endereco;

        public virtual TelefoneModel IdTelefoneNavigation { get; set; }
        public virtual EnderecoModel IdEnderecoNavigation { get; set; }

    }
}
