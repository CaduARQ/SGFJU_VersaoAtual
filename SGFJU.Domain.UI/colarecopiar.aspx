<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="colarecopiar.aspx.cs" Inherits="SGFJU.Domain.UI.colarecopiar" %>


<!DOCTYPE html>
<html>

<head>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

<%--    <title>INSPINIA | Wizards</title>

    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="font-awesome/css/font-awesome.css" rel="stylesheet">
    <link href="css/plugins/iCheck/custom.css" rel="stylesheet">
    <link href="css/plugins/steps/jquery.steps.css" rel="stylesheet">
    <link href="css/animate.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet">--%>
    <link href="css/fju-tema.css" rel="stylesheet">

    <style type="text/css">
        .auto-style2 {
            width: 515px;
        }
        .auto-style3 {
            width: 534px;
        }
        .auto-style4 {
            width: 158px;
        }
        .auto-style5 {
            width: 71%;
        }
        .auto-style6 {
            width: 356px;
        }
        .auto-style7 {
            width: 351px;
        }
        .auto-style8 {
            width: 234px;
        }
        table, th, td {
          border: 1px solid black;
          border-collapse: collapse;
          font-family: Helvetica
        }
        thHeader {
            border: none
        }
        .auto-style10 {
            width: 78px;
        }
        .auto-style11 {
            width: 205px;
        }
        .auto-style12 {
            width: 1309px;
        }
        .auto-style13 {
            width: 103px;
        }
        .auto-style14 {
            width: 108px;
        }
        .auto-style15 {
            width: 110px;
        }
        .auto-style16 {
            height: 27px;
        }
        .auto-style17 {
            height: 23px;
        }
        .auto-style19 {
            width: 455px;
        }
        .auto-style20 {
            width: 533px;
        }
        .auto-style21 {
            width: 323px;
        }
    </style>

</head>

<body>

    

    <table class="auto-style5">
        <tr style="background-color: #428bca; color: white; font-family: Helvetica; font-weight: bold">
            <td colspan="6" class="auto-style17">&nbsp;<img alt="" src="img/FJU(LOGO) CINZA (1).png" width="80px" class="auto-style16" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Árvore da vida FJU - SGFJU&nbsp;
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: darkslateblue; color: white">Nome</td>
            <td class="auto-style3" colspan="2">
                <input id="Text1" class="auto-style2" type="text" /></td>
            <td class="auto-style4" style="background-color: #dcdcdc">Data de Nascimento</td>
            <td colspan="2">
                <input id="Text2" type="text" class="auto-style8" /></td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: #dcdcdc">Estado</td>
            <td class="auto-style3" colspan="2">
                <input id="Text5" class="auto-style6" type="text" /></td>
            <td class="auto-style4" style="background-color: #dcdcdc">Bloco</td>
            <td>
                <input id="Text3" type="text" /></td>
            <td rowspan="5">
                <img alt="" src="FotosJovens/SP_ID_COORDENADOR_92788_2020-12-01165258_4584c891-d4a6-4556-a158-dece3aa5ecad.jpg" height="125px" width="110px" style="border: 1px solid #000000"  /></td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: #dcdcdc">Região</td>
            <td class="auto-style3" colspan="2">
                <input id="Text6" class="auto-style7" type="text" /></td>
            <td class="auto-style4" style="background-color: #dcdcdc">Igreja</td>
            <td>
                <input id="Text4" type="text" /></td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: #dcdcdc">Whatsapp</td>
            <td class="auto-style3" colspan="2">
                <input id="Text7" type="text" /></td>
            <td class="auto-style4" style="background-color: #dcdcdc">Estado Civil</td>
            <td>
                <input id="Text8" type="text" /></td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: #dcdcdc">Endereço</td>
            <td colspan="3">
                <input id="Text9" class="auto-style2" type="text" /></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: #dcdcdc">Quando entrou na FJU?</td>
            <td class="auto-style3" colspan="2">
                <input id="Text10" type="text" /></td>
            <td class="auto-style4" style="background-color: #dcdcdc">Projeto</td>
            <td>
                <input id="Text11" type="text" /></td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: #dcdcdc">Como conheceu a FJU</td>
            <td colspan="5">
                <input id="Text12" class="auto-style6" type="text" /></td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: #dcdcdc">Batizado nas águas</td>
            <td class="auto-style11">
                <input id="Text13" type="text" /></td>
            <td class="auto-style10" style="background-color: #dcdcdc">
                Data:</td>
            <td>
                <input id="Text17" type="text" class="auto-style13" /></td>
            <td style="background-color: #dcdcdc">Foi na IURD?</td>
            <td>
                <input id="Text16" type="text" class="auto-style14" /></td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: #dcdcdc">Tem o Espírito Santo</td>
            <td colspan="3">
                <input id="Text14" type="text" /></td>
            <td style="background-color: #dcdcdc">Data</td>
            <td>
                <input id="Text15" type="text" class="auto-style15" /></td>
        </tr>
    </table>

    <!---->
    <br />
    <!---->

    <table class="auto-style5">
        <tr style="background-color: #428bca; color: white; font-family: Helvetica; font-weight: bold">
            <td colspan="6" class="auto-style17">&nbsp;<img alt="" src="img/FJU(LOGO) CINZA (1).png" width="80px" class="auto-style16" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Árvore da vida FJU - SGFJU&nbsp;
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: darkslateblue; color: white">Nome</td>
            <td class="auto-style3" colspan="2">
                <input id="Text1" class="auto-style2" type="text" /></td>
            <td class="auto-style4" style="background-color: #dcdcdc">Data de Nascimento</td>
            <td colspan="2">
                <input id="Text2" type="text" class="auto-style8" /></td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: #dcdcdc">Estado</td>
            <td class="auto-style3" colspan="2">
                <input id="Text5" class="auto-style6" type="text" /></td>
            <td class="auto-style4" style="background-color: #dcdcdc">Bloco</td>
            <td>
                <input id="Text3" type="text" /></td>
            <td rowspan="5">
                <img alt="" src="FotosJovens/SP_ID_COORDENADOR_92788_2020-12-01165258_4584c891-d4a6-4556-a158-dece3aa5ecad.jpg" height="125px" width="110px" style="border: 1px solid #000000"  /></td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: #dcdcdc">Região</td>
            <td class="auto-style3" colspan="2">
                <input id="Text6" class="auto-style7" type="text" /></td>
            <td class="auto-style4" style="background-color: #dcdcdc">Igreja</td>
            <td>
                <input id="Text4" type="text" /></td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: #dcdcdc">Whatsapp</td>
            <td class="auto-style3" colspan="2">
                <input id="Text7" type="text" /></td>
            <td class="auto-style4" style="background-color: #dcdcdc">Estado Civil</td>
            <td>
                <input id="Text8" type="text" /></td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: #dcdcdc">Endereço</td>
            <td colspan="3">
                <input id="Text9" class="auto-style2" type="text" /></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: #dcdcdc">Quando entrou na FJU?</td>
            <td class="auto-style3" colspan="2">
                <input id="Text10" type="text" /></td>
            <td class="auto-style4" style="background-color: #dcdcdc">Projeto</td>
            <td>
                <input id="Text11" type="text" /></td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: #dcdcdc">Como conheceu a FJU</td>
            <td colspan="5">
                <input id="Text12" class="auto-style6" type="text" /></td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: #dcdcdc">Batizado nas águas</td>
            <td class="auto-style11">
                <input id="Text13" type="text" /></td>
            <td class="auto-style10" style="background-color: #dcdcdc">
                Data:</td>
            <td>
                <input id="Text17" type="text" class="auto-style13" /></td>
            <td style="background-color: #dcdcdc">Foi na IURD?</td>
            <td>
                <input id="Text16" type="text" class="auto-style14" /></td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: #dcdcdc">Tem o Espírito Santo</td>
            <td colspan="3">
                <input id="Text14" type="text" /></td>
            <td style="background-color: #dcdcdc">Data</td>
            <td>
                <input id="Text15" type="text" class="auto-style15" /></td>
        </tr>
    </table>

    <br />
    <!---->
    <table class="auto-style5">
        <tr style="background-color: #428bca; color: white; font-family: Helvetica; font-weight: bold">
            <td colspan="7" class="auto-style17">&nbsp;<img alt="" src="img/FJU(LOGO) CINZA (1).png" width="80px" class="auto-style16" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Árvore da vida FJU - SGFJU&nbsp;
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: darkslateblue; color: white">Nome</td>
            <td class="auto-style3" colspan="3">
                <input id="Text1" class="auto-style2" type="text" /></td>
            <td class="auto-style4" style="background-color: #dcdcdc">Data de Nascimento</td>
            <td colspan="2">
                <input id="Text2" type="text" class="auto-style8" /></td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: #dcdcdc">Estado</td>
            <td class="auto-style3" colspan="3">
                <input id="Text5" class="auto-style6" type="text" /></td>
            <td class="auto-style4" style="background-color: #dcdcdc">Bloco</td>
            <td>
                <input id="Text3" type="text" /></td>
            <td rowspan="5">
                <img alt="" src="FotosJovens/SP_ID_COORDENADOR_92788_2020-12-01165258_4584c891-d4a6-4556-a158-dece3aa5ecad.jpg" height="125px" width="110px" style="border: 1px solid #000000"  /></td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: #dcdcdc">Região</td>
            <td class="auto-style3" colspan="3">
                <input id="Text6" class="auto-style7" type="text" /></td>
            <td class="auto-style4" style="background-color: #dcdcdc">Igreja</td>
            <td>
                <input id="Text4" type="text" /></td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: #dcdcdc">Whatsapp</td>
            <td class="auto-style3" colspan="3">
                <input id="Text7" type="text" /></td>
            <td class="auto-style4" style="background-color: #dcdcdc">Estado Civil</td>
            <td>
                <input id="Text8" type="text" /></td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: #dcdcdc">Endereço</td>
            <td colspan="5">
                <input id="Text9" class="auto-style2" type="text" /></td>
        </tr>
        <tr>
            <td style="background-color: #dcdcdc" colspan="2">Quando entrou na FJU?</td>
            <td class="auto-style19" colspan="2">
                <input id="Text10" type="text" /></td>
            <td class="auto-style4" style="background-color: #dcdcdc">Projeto</td>
            <td>
                <input id="Text11" type="text" /></td>
        </tr>
        <tr>
            <td style="background-color: #dcdcdc; text-align: center" colspan="7">Informações do jovem relacionadas à FJU</td>
        </tr>
        <tr>
            <td style="background-color: #dcdcdc" colspan="3">Como conheceu a FJU</td>
            <td colspan="4">
                <input id="Text12" class="auto-style20" type="text" /></td>
        </tr>
        <tr>
            <td style="background-color: #dcdcdc; text-align: center" colspan="7">Informações sobre Batismo</td>
        </tr>
        <tr>
            <td style="" colspan="7">
                Batizado nas águas:&nbsp;
                <input value="Sim" title="Sim" id="Checkbox1" type="checkbox" />Sim
                <input value="Não" title="Não" id="Checkbox2" type="checkbox" />
                Não&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; |&nbsp;&nbsp; Data:
                <input id="Text18" type="text" class="auto-style13" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; |&nbsp;&nbsp; Foi na IURD:
                <input value="Sim" title="Sim" id="Checkbox5" type="checkbox" />Sim
                <input value="Não" title="Não" id="Checkbox6" type="checkbox" />
                Não</td>
        </tr>
        <tr>
            <td style="" colspan="7">Batizado com o Espírito Santo:&nbsp;
                <input value="Sim" title="Sim" id="Checkbox3" type="checkbox" />Sim
                <input value="Não" title="Não" id="Checkbox4" type="checkbox" /> Não&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; | Data:
                <input id="Text19" type="text" class="auto-style13" /></td>
        </tr>
        <tr>
            <td style="background-color: #dcdcdc; text-align: center"  colspan="7"></td>
        </tr>
        </table>
    <!---->

    <p>
        abaixo tabela</p>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

    <table class="auto-style5">
        <tr style="background-color: #428bca; color: white; font-family: Helvetica; font-weight: bold">
            <td colspan="5" class="auto-style17">&nbsp;<img alt="" src="img/FJU(LOGO) CINZA (1).png" width="80px" class="auto-style16" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Árvore da vida FJU - SGFJU&nbsp;
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: darkslateblue; color: white">Nome</td>
            <td class="auto-style3">
                <input id="Text20" class="auto-style2" type="text" /></td>
            <td class="auto-style4" style="background-color: #dcdcdc">Data de Nascimento</td>
            <td colspan="2">
                <input id="Text21" type="text" class="auto-style8" /></td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: #dcdcdc">Estado</td>
            <td class="auto-style3">
                <input id="Text22" class="auto-style6" type="text" /></td>
            <td class="auto-style4" style="background-color: #dcdcdc">Bloco</td>
            <td>
                <input id="Text23" type="text" /></td>
            <td rowspan="5">
                <img alt="" src="FotosJovens/SP_ID_COORDENADOR_92788_2020-12-01165258_4584c891-d4a6-4556-a158-dece3aa5ecad.jpg" height="125px" width="110px" style="border: 1px solid #000000"  /></td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: #dcdcdc">Região</td>
            <td class="auto-style3">
                <input id="Text24" class="auto-style7" type="text" /></td>
            <td class="auto-style4" style="background-color: #dcdcdc">Igreja</td>
            <td>
                <input id="Text25" type="text" /></td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: #dcdcdc">Whatsapp</td>
            <td class="auto-style3">
                <input id="Text26" type="text" /></td>
            <td class="auto-style4" style="background-color: #dcdcdc">Estado Civil</td>
            <td>
                <input id="Text27" type="text" /></td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: #dcdcdc">Endereço</td>
            <td colspan="3">
                <input id="Text28" class="auto-style2" type="text" /></td>
        </tr>
        <tr>
            <td style="background-color: #dcdcdc" colspan="4">Quando entrou na FJU? |&nbsp;
                <input id="Text29" type="text" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; |&nbsp; Projeto&nbsp;
                <input id="Text30" type="text" /></td>
        </tr>
        <tr>
            <td style="background-color: #dcdcdc" colspan="5">Como conheceu a FJU&nbsp;&nbsp; |&nbsp;
                <input id="Text31" class="auto-style21" type="text" /></td>
        </tr>
        <tr>
            <td style="background-color: #dcdcdc; text-align:center" colspan="5">Informações relacionadas ao batismo</td>
        </tr>
        <tr>
            <td colspan="5">
                Batizado nas águas:&nbsp;
                <input value="Sim" title="Sim" id="Checkbox7" type="checkbox" />Sim
                <input value="Não" title="Não" id="Checkbox8" type="checkbox" />
                Não&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; |&nbsp;&nbsp; Data:
                <input id="Text32" type="text" class="auto-style13" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; |&nbsp;&nbsp; Foi na IURD:
                <input value="Sim" title="Sim" id="Checkbox9" type="checkbox" />Sim
                <input value="Não" title="Não" id="Checkbox10" type="checkbox" />
                Não

            </td>
        </tr>
        <tr>
            <td colspan="5">
                Batizado com o Espírito Santo:&nbsp;
                <input value="Sim" title="Sim" id="Checkbox11" type="checkbox" />Sim
                <input value="Não" title="Não" id="Checkbox12" type="checkbox" /> Não&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; | Data:
                <input id="Text33" type="text" class="auto-style13" />
                </td>
        </tr>
    </table>

    <br />
    <br />
    <br />
    <br />
    <br />
    &lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt; abaixo não mexer porque está certinha - esta do meio está topzeira não mexer por enquanto &gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;<br />
    <br />

    <table class="auto-style5">
        <tr style="background-color: #428bca; color: white; font-family: Helvetica; font-weight: bold">
            <td colspan="5" class="auto-style17">&nbsp;<img alt="" src="img/FJU(LOGO) CINZA (1).png" width="80px" class="auto-style16" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Árvore da vida FJU - SGFJU&nbsp;
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: darkslateblue; color: white">Nome</td>
            <td class="auto-style3">
                <input id="Text34" class="auto-style2" type="text" /></td>
            <td class="auto-style4" style="background-color: #dcdcdc">Data de Nascimento</td>
            <td colspan="2">
                <input id="Text35" type="text" class="auto-style8" /></td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: #dcdcdc">Estado</td>
            <td class="auto-style3">
                <input id="Text36" class="auto-style6" type="text" /></td>
            <td class="auto-style4" style="background-color: #dcdcdc">Bloco</td>
            <td>
                <input id="Text37" type="text" /></td>
            <td rowspan="5">
                <img alt="" src="FotosJovens/SP_ID_COORDENADOR_92788_2020-12-01165258_4584c891-d4a6-4556-a158-dece3aa5ecad.jpg" height="125px" width="110px" style="border: 1px solid #000000"  /></td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: #dcdcdc">Região</td>
            <td class="auto-style3">
                <input id="Text38" class="auto-style7" type="text" /></td>
            <td class="auto-style4" style="background-color: #dcdcdc">Igreja</td>
            <td>
                <input id="Text39" type="text" /></td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: #dcdcdc">Whatsapp</td>
            <td class="auto-style3">
                <input id="Text40" type="text" /></td>
            <td class="auto-style4" style="background-color: #dcdcdc">Estado Civil</td>
            <td>
                <input id="Text41" type="text" /></td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: #dcdcdc">Endereço</td>
            <td colspan="2">
                <input id="Text42" class="auto-style2" type="text" /></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="background-color: #dcdcdc" colspan="4">Quando entrou na FJU? |&nbsp;
                <input id="Text43" type="text" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; |&nbsp; Projeto&nbsp;
                <input id="Text44" type="text" /></td>
        </tr>
        <tr>
            <td style="background-color: #dcdcdc" colspan="5">Como conheceu a FJU&nbsp;&nbsp; |&nbsp;
                <input id="Text45" class="auto-style21" type="text" /></td>
        </tr>
        <tr>
            <td style="background-color: #dcdcdc; text-align:center" colspan="5">Informações relacionadas ao batismo</td>
        </tr>
        <tr>
            <td colspan="5">
                Batizado nas águas:&nbsp;
                <input value="Sim" title="Sim" id="Checkbox13" type="checkbox" />Sim
                <input value="Não" title="Não" id="Checkbox14" type="checkbox" />
                Não&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; |&nbsp;&nbsp; Data:
                <input id="Text46" type="text" class="auto-style13" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; |&nbsp;&nbsp; Foi na IURD:
                <input value="Sim" title="Sim" id="Checkbox15" type="checkbox" />Sim
                <input value="Não" title="Não" id="Checkbox16" type="checkbox" />
                Não

            </td>
        </tr>
        <tr>
            <td colspan="5">
                Batizado com o Espírito Santo:&nbsp;
                <input value="Sim" title="Sim" id="Checkbox17" type="checkbox" />Sim
                <input value="Não" title="Não" id="Checkbox18" type="checkbox" /> Não&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; | Data:
                <input id="Text47" type="text" class="auto-style13" />
                </td>
        </tr>
    </table>

    <br />
    <br />
    &lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt; &gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;<br />
    <br />

    <table class="auto-style5">
        <tr style="background-color: #428bca; color: white; font-family: Helvetica; font-weight: bold">
            <td colspan="5" class="auto-style17">&nbsp;<img alt="" src="img/FJU(LOGO) CINZA (1).png" width="80px" class="auto-style16" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Árvore da vida FJU - SGFJU&nbsp;
                   </td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: darkslateblue; color: white">Nome</td>
            <td class="auto-style3">
                <input id="Text1" class="auto-style2" type="text" /></td>
            <td class="auto-style4" style="background-color: #dcdcdc">Data de Nascimento</td>
            <td colspan="2">
                <input id="Text2" type="text" class="auto-style8" /></td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: #dcdcdc">Estado</td>
            <td class="auto-style3">
                <input id="Text5" class="auto-style6" type="text" /></td>
            <td class="auto-style4" style="background-color: #dcdcdc">Bloco</td>
            <td>
                <input id="Text3" type="text" /></td>
            <td rowspan="5">
                <img alt="" src="FotosJovens/SP_ID_COORDENADOR_92788_2020-12-01165258_4584c891-d4a6-4556-a158-dece3aa5ecad.jpg" height="125px" width="110px" style="border: 1px solid #000000"  /></td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: #dcdcdc">Região</td>
            <td class="auto-style3">
                <input id="Text6" class="auto-style7" type="text" /></td>
            <td class="auto-style4" style="background-color: #dcdcdc">Igreja</td>
            <td>
                <input id="Text4" type="text" /></td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: #dcdcdc">Whatsapp</td>
            <td class="auto-style3">
                <input id="Text7" type="text" /></td>
            <td class="auto-style4" style="background-color: #dcdcdc">Estado Civil</td>
            <td>
                <input id="Text8" type="text" /></td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: #dcdcdc">Endereço</td>
            <td colspan="2">
                <input id="Text9" class="auto-style2" type="text" /></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: #dcdcdc">Quando entrou na FJU?</td>
            <td class="auto-style3">
                <input id="Text10" type="text" /></td>
            <td class="auto-style4" style="background-color: #dcdcdc">Projeto</td>
            <td>
                <input id="Text11" type="text" /></td>
        </tr>
        <tr>
            <td class="auto-style12" style="background-color: #dcdcdc">Como conheceu a FJU</td>
            <td colspan="4">
                <input id="Text12" class="auto-style6" type="text" /></td>
        </tr>
        <tr>
            <td colspan="5">
                Batizado nas águas:&nbsp;
                <input value="Sim" title="Sim" id="Checkbox1" type="checkbox" />Sim
                <input value="Não" title="Não" id="Checkbox2" type="checkbox" />
                Não&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; |&nbsp;&nbsp; Data:
                <input id="Text18" type="text" class="auto-style13" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; |&nbsp;&nbsp; Foi na IURD:
                <input value="Sim" title="Sim" id="Checkbox5" type="checkbox" />Sim
                <input value="Não" title="Não" id="Checkbox6" type="checkbox" />
                Não</td>

            </td>
        </tr>
        <tr>
            <td colspan="5">
                Batizado com o Espírito Santo:&nbsp;
                <input value="Sim" title="Sim" id="Checkbox3" type="checkbox" />Sim
                <input value="Não" title="Não" id="Checkbox4" type="checkbox" /> Não&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; | Data:
                <input id="Text19" type="text" class="auto-style13" /> ss</td>
        </tr>
    </table>
    <script>
        var __TEMPLATE_TABLE_FICHA_ACOMPANHAMENTO =
            '<table class="auto-style5"> ' +
            '    <tr style="background-color: #428bca; color: white; font-family: Helvetica; font-weight: bold"> ' +
            '        <td colspan="5" class="auto-style17">&nbsp;<img alt="" src="img/FJU(LOGO) CINZA (1).png" width="80px" class="auto-style16" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Árvore da vida FJU - SGFJU&nbsp; ' +
            '        <br /> ' +
            '        </td> ' +
            '    </tr> ' +
            '    <tr> ' +
            '        <td class="auto-style12" style="background-color: darkslateblue; color: white">Nome</td> ' +
            '        <td class="auto-style3"> ' +
            '            <input id="Text20" class="auto-style2" type="text" /></td> ' +
            '        <td class="auto-style4" style="background-color: #dcdcdc">Data de Nascimento</td> ' +
            '        <td colspan="2"> ' +
            '            <input id="Text21" type="text" class="auto-style8" /></td> ' +
            '    </tr> ' +
            '    <tr> ' +
            '        <td class="auto-style12" style="background-color: #dcdcdc">Estado</td> ' +
            '        <td class="auto-style3"> ' +
            '            <input id="Text22" class="auto-style6" type="text" /></td> ' +
            '        <td class="auto-style4" style="background-color: #dcdcdc">Bloco</td> ' +
            '        <td> ' +
            '            <input id="Text23" type="text" /></td> ' +
            '        <td rowspan="5"> ' +
            '            <img alt="" src="FotosJovens/SP_ID_COORDENADOR_92788_2020-12-01165258_4584c891-d4a6-4556-a158-dece3aa5ecad.jpg" height="125px" width="110px" style="border: 1px solid #000000" /></td> ' +
            '    </tr> ' +
            '    <tr> ' +
            '        <td class="auto-style12" style="background-color: #dcdcdc">Região</td> ' +
            '        <td class="auto-style3"> ' +
            '            <input id="Text24" class="auto-style7" type="text" /></td> ' +
            '        <td class="auto-style4" style="background-color: #dcdcdc">Igreja</td> ' +
            '        <td> ' +
            '            <input id="Text25" type="text" /></td> ' +
            '    </tr> ' +
            '    <tr> ' +
            '        <td class="auto-style12" style="background-color: #dcdcdc">Whatsapp</td> ' +
            '        <td class="auto-style3"> ' +
            '            <input id="Text26" type="text" /></td> ' +
            '        <td class="auto-style4" style="background-color: #dcdcdc">Estado Civil</td> ' +
            '        <td> ' +
            '            <input id="Text27" type="text" /></td> ' +
            '    </tr> ' +
            '    <tr> ' +
            '        <td class="auto-style12" style="background-color: #dcdcdc">Endereço</td> ' +
            '        <td colspan="3"> ' +
            '            <input id="Text28" class="auto-style2" type="text" /></td> ' +
            '    </tr> ' +
            '    <tr> ' +
            '        <td style="background-color: #dcdcdc" colspan="4">Quando entrou na FJU? |&nbsp; ' +
            '        <input id="Text29" type="text" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; |&nbsp; Projeto&nbsp; ' +
            '        <input id="Text30" type="text" /></td> ' +
            '    </tr> ' +
            '    <tr> ' +
            '        <td style="background-color: #dcdcdc" colspan="5">Como conheceu a FJU&nbsp;&nbsp; |&nbsp; ' +
            '        <input id="Text31" class="auto-style21" type="text" /></td> ' +
            '    </tr> ' +
            '    <tr> ' +
            '        <td style="background-color: #dcdcdc; text-align:center" colspan="5">Informações relacionadas ao batismo</td> ' +
            '    </tr> ' +
            '    <tr> ' +
            '        <td colspan="5"> ' +
            '            Batizado nas águas:&nbsp; ' +
            '        <input value="Sim" title="Sim" id="Checkbox7" type="checkbox" />Sim ' +
            '        <input value="Não" title="Não" id="Checkbox8" type="checkbox" /> ' +
            '            Não&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; |&nbsp;&nbsp; Data: ' +
            '        <input id="Text32" type="text" class="auto-style13" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; |&nbsp;&nbsp; Foi na IURD: ' +
            '        <input value="Sim" title="Sim" id="Checkbox9" type="checkbox" />Sim ' +
            '        <input value="Não" title="Não" id="Checkbox10" type="checkbox" /> ' +
            '            Não ' +
            '    </td> ' +
            '    </tr> ' +
            '    <tr> ' +
            '        <td colspan="5"> ' +
            '            Batizado com o Espírito Santo:&nbsp; ' +
            '        <input value="Sim" title="Sim" id="Checkbox11" type="checkbox" />Sim ' +
            '        <input value="Não" title="Não" id="Checkbox12" type="checkbox" /> Não&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; | Data: ' +
            '        <input id="Text33" type="text" class="auto-style13" /> ' +
            '        </td> ' +
            '    </tr> ' +
            '</table> ';
    </script>
</body>

</html>
