using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class ParametroPesquisaPatrimonioDTO
    {
        public int IdEstado { get; set; }
        public int IdItemPatrimonio { get; set; }
        public int IdCategoriaItem { get; set; }
        public string NomeItemPatrimonio { get; set; }
        public string DescricaoPatrimonio { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string DataCompra { get; set; }
        public string LocalCompra { get; set; }
        public decimal ValorUnitario { get; set; }
    }
}
