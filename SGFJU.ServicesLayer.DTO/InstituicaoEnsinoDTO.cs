using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class InstituicaoEnsinoDTO
    {
        public int IdInstituicaoEnsino { get; set; }
        public string NomeInstituicaoEnsino { get; set; }
        public string Endereco { get; set; }
        public string Contato { get; set; }
        public string NomeContato { get; set; }
        public string FuncaoContatoInstituicaoEnsino { get; set; }
        public int IdEstadoInstituicao { get; set; }
        public int IdBlocoInstituicao { get; set; }
        public string NomeBlocoInstituicao { get; set; }
        public int IdRegiaoInstituicao { get; set; }
        public string NomeRegiaoInstituicao { get; set; }
        public int IdIgrejaInstituicao { get; set; }
        public string NomeIgrejaInstituicao { get; set; }
        public int IdPerfilInstituicao { get; set; }
        public string DescricaoPerfilInstituicao { get; set; }
        public int IdTipoInstituicao { get; set; }
        public string DescricaoTipoInstituicao { get; set; }
        public int IdClassificacaoInstituicao { get; set; }
        public string DescricaoClassificacaoInstituicao { get; set; }
    }
}
