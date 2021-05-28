using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repositorio.Models;
using AgendaNet.Models;
using Repositorio;

namespace AgendaNet
{

    public class AutoMapperConfig : Profile
    {

        public static MapperConfiguration RegisterMappings()

        {

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Endereco, EnderecoModel>();
                cfg.CreateMap<EnderecoModel, Endereco>();
                cfg.CreateMap<Estado, EstadoModel>();
                cfg.CreateMap<EstadoModel, Estado>();
                cfg.CreateMap<Telefone, TelefoneModel>();
                cfg.CreateMap<TelefoneModel, Telefone>();
                cfg.CreateMap<Empresa, EmpresaModel>();
                cfg.CreateMap <EmpresaModel, Empresa>();
                cfg.CreateMap<VwCidadeEstado, vw_CidadeEstadoModel>();
                cfg.CreateMap<vw_CidadeEstadoModel, VwCidadeEstado>();

            });
            return config;

        }


    }
}
