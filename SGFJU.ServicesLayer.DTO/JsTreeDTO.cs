using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class JsTreeDTO {
        public JsTreeDTO() {
            this.children = new List<JsTreeDTO>();
        }
        public string id { get; set; }
        public string text { get; set; }
        public string parentId { get; set; }
        public IList<JsTreeDTO> children { get; set; }
    }
}
