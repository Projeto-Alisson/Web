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
        public String cod_empresa { get; set; }

        [Display(Name = "Nome")]
        public String nome_empresa { get; set; }

        [Display(Name = "CNPJ")]
        public String cnpj_empresa { get; set; }

        [Display(Name = "Login")]
        public String login_empresa { get; set; }
        
        [Display(Name = "Senha")]
        public String senha_empresa { get; set;}

        public string ConfirmaSenhaEmpresa { get; set; }

        public Telefone telefone;
        public Endereco endereco;

        public virtual TelefoneModel IdTelefoneNavigation { get; set; }
        public virtual EnderecoModel IdEnderecoNavigation { get; set; }

    }
}
