using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Entities
{
    public class JovemProjetoContainer {
        public JovemProjeto ProjetoAnterior { get; set; }
        public JovemProjeto ProjetoAtual { get; set; }
        public bool PassouATerProjeto {
            get {
                return (ProjetoAnterior == null && ProjetoAtual != null) ;
            }
        }
        public bool ProjetoAnteriorMudou { 
            get {
                if (ProjetoAnterior != null && ProjetoAtual != null) {
                    return (ProjetoAtual.Projeto.Code != ProjetoAnterior.Projeto.Code);
                }
                return false;
            }
        }
        public bool DeixouOProjeto {
            get{
                return (ProjetoAtual == null && ProjetoAnterior!= null);
            }
        }
        public bool EmNenhumProjeto {
            get { 
                return (ProjetoAtual == null && ProjetoAnterior == null);
            }
        }
    }
}
