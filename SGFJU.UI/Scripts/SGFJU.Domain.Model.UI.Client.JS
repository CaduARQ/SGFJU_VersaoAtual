var ClientFactory =
{
    Register: function (_Name) {
        var chk = false;
        var cob = "";
        var spc = _Name.split(".");
        for (var i = 0; i < spc.length; i++) {
            if (cob != "") {
                cob += ".";
            }
            cob += spc[i];
            chk = this.Exists(cob);
            if (!chk) {
                this.Create(cob);
            }
        }
        if (chk) {
            throw "Namespace: " + _Name + " is already defined.";
        }
    },

    Create: function (_Src) {
        eval("window." + _Src + " = new Object();");
    },

    Exists: function (_Src) {
        eval("var NE = false; try{if(" + _Src + "){NE = true;}else{NE = false;}}catch(err){NE=false;}");
        return NE;
    }
};

/* Registro de objetos e seus respectivos namespaces */
ClientFactory.Register('SGFJU.Domain.Model.ClientObjects.Projeto');

SGFJU.Domain.Model.ClientObjects.Projeto = function () {
    AbreConfiguracaoDetalhesProjeto: function (IDProjeto, nomeProjeto) {
        var wnd = window.radopen('../Views/formInformacoesAdicionaisProjeto.aspx?IdProjeto=' + IDProjeto, null);
        wnd.setSize(1030, 710);
        wnd.set_title('Preenchimento de informações adicionais do projeto: ' + nomeProjeto);
        wnd.set_behaviors(Telerik.Web.UI.WindowBehaviors.Close);
        wnd.set_modal(true);
        wnd.center();
        args.set_cancel(true);
    }
};