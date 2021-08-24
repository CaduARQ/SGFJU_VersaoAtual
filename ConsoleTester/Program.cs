using HibernatingRhinos.Profiler.Appender.NHibernate;
using NHibernate.Criterion;
using SGFJU.Bussiness.Facade;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.DataAccess.MySql.Common;
using SGFJU.Domain.Model.Infra.DataAccess.MySql.Implementation;
using SGFJU.Domain.Model.Infra.Security;
using SGFJU.Domain.Model.ValueObjects;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            //------------------------------------------------------------------

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Thread.Sleep(10000);
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            //// Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            //Console.WriteLine("RunTime " + elapsedTime);



            //------------------------------------------------------------------

            //NHibernateProfiler.Initialize();

            //var sessao = FluentSessionFactory.CreateFactory("Server=localhost; Port=3306; Database=SGFJU_DB;Uid=root;Pwd=FJU07;");
            //var sessaoAberta = sessao.OpenSession();

            //var estados = sessaoAberta.CreateCriteria<Jovem>().List<Jovem>();
            //var hqlQuery = "select jv" +
            //               "  from Jovem      as jv" +
            //               " inner Join jv.ProjetosAosQuaisJovemEstaLigado pjl";
            //var resultSet = sessaoAberta.CreateQuery(hqlQuery).List<Jovem>();
            //var a = sessaoAberta.QueryOver<Jovem>()
            //                    .List<Jovem>();
            //var td = sessaoAberta.QueryOver<JovemHabilidadeProjeto>().List<JovemHabilidadeProjeto>();
            //var b = a;

            /*
            var repo = new JovemRepositoryImpl();
            var usuarioDeSP = repo.ObterJovensPorEstado(new Estado { Id = 34 });
            var bbbb = usuarioDeSP;

            foreach (var bloco in usuarioDeSP)
            {
                TextInfo tInfo = CultureInfo.CurrentCulture.TextInfo;
                Console.WriteLine("Nome Usuario: " + tInfo.ToTitleCase(bloco.Nome));
            }*/


            //var sessao = FluentSessionFactory.CreateFactory("Server=localhost; Port=3306; Database=SGFJU_DEV;Uid=root;Pwd=FJU07;");
            //var raimundo = new Jovem { Id = 39 };
            //var arquimedes = new Jovem { Id = 38389 };
            /*
            var repo = new ArvoreVidaRepositoryImpl();
            var obraAdriele = new ObreiroDTO { IdObreiro = 136 };
            var listaJovensAssociar = new List<JovemAcompanhamentoDTO>(){
                    new JovemAcompanhamentoDTO { IdJovem = 48, DataInicioAcompanhamento = "03/06/2020" },
                    new JovemAcompanhamentoDTO { IdJovem = 76, DataInicioAcompanhamento = "09/07/2020" },
                    new JovemAcompanhamentoDTO { IdJovem = 59, DataInicioAcompanhamento = "14/10/2020" },
                    new JovemAcompanhamentoDTO { IdJovem = 68, DataInicioAcompanhamento = "15/11/2020" }

            };

            var obreirosSP = repo.PesquisaObreiroPorParametro(new ParametroPesquisaObreiroDTO
            {
                NomeObreiro = "vivian"
            });*/

            /*
            var codigoEncriptado = EncryptionHelper.Encrypt("118");
            var codigoDecriptado = EncryptionHelper.Decrypt(codigoEncriptado);
            Console.WriteLine("código Encriptado "+ codigoEncriptado);
            Console.WriteLine("código DEncriptado " + codigoDecriptado);
            */
            /*
            var ints = new[] { 4, 5, 3, 1, 6 };
            foreach (var item in ints.Select((x, i) => new { OldIndex = i, Value = x, NewIndex = -1 })
                                     .OrderByDescending(x => x.Value)
                                     .Select((x, i) => new { OldIndex = x.OldIndex, Value = x.Value, NewIndex = i + 1 })
                                     .OrderBy(x => x.OldIndex))
                Console.Write(item.NewIndex + " ");
            */

            //repo.AssociaJovensAObreiro(listaJovensAssociar, obraAdriele);
            //var res = repo.ListaJovensAcompanhadosPorObreiro(new ObreiroDTO { IdObreiro = 136 });
            //var obreiroRetornado = repo.RetornaObreiroQueAcompanhaJovem(new Jovem { Id = 39 });

            /*
            var repo = new JovemRepositoryImpl();
            var resposta = repo.SolicitarAutorizacaoCompraCamisa(new List<AutorizacaoCompraCamisaDTO>
            {
                new AutorizacaoCompraCamisaDTO{ 
                    IdJovem = 27, 
                    CodigoAutorizacaoCompraCamisa = $"CASGFJU{27}{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Millisecond}",
                    DataAutorizacaoCompraCamisa = DateTime.Now.ToString("yyyy-MM-dd"),
                    NomeAutorizadorCompraCamisa = "Ob Anderson Lima Nonato Andrade",
                    NomeCamisaAutorizada = "Jovem/Projeto Cultura",
                    OrigemCompraCamisa = "Souvenir"
                },
                new AutorizacaoCompraCamisaDTO{
                    IdJovem = 28,
                    CodigoAutorizacaoCompraCamisa = $"CASGFJU{27}{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Millisecond}",
                    DataAutorizacaoCompraCamisa = DateTime.Now.ToString("yyyy-MM-dd"),
                    NomeAutorizadorCompraCamisa = "Stephanie amemia",
                    NomeCamisaAutorizada = "Jovem/Projeto Help",
                    OrigemCompraCamisa = "Souvenir"
                }
            });
            */

            

            /*
            var acompanhamentoTS = new JovemObreiro {
                Jovem = raimundo,

                Obreiro = arquimedes,
                DataInicioAcompanhamento = DateTime.Parse("01/08/2020")
            };*/
            /*
            var historicoRaimundo = new JovemHistorico { 
                Jovem = raimundo,
                Obreiro = arquimedes,
                StatusJovem = new StatusAcompanhamento { Codigo = 1 },
                TextoObservacao = "Começou a vir na FJU",
                DataHistoricoAcompanhamento = DateTime.Parse("01/08/2020")
            };

            var historicoRaimundoSet = new JovemHistorico
            {
                Jovem = raimundo,
                Obreiro = arquimedes,
                StatusJovem = new StatusAcompanhamento { Codigo = 2 },
                TextoObservacao = "Se batizou nas àguas",
                DataHistoricoAcompanhamento = DateTime.Parse("01/09/2020")
            };

            var historicoRaimundoOut = new JovemHistorico
            {
                Jovem = raimundo,
                Obreiro = arquimedes,
                StatusJovem = new StatusAcompanhamento { Codigo = 2 },
                TextoObservacao = "Foi Batizado com o Espírito Santo",
                DataHistoricoAcompanhamento = DateTime.Parse("01/10/2020")
            };

            var sessaoaberta = sessao.OpenSession();
            var transacao = sessaoaberta.BeginTransaction();

            sessaoaberta.Save(historicoRaimundoSet);
            //sessaoaberta.Save(historicoRaimundoSet);
            //sessaoaberta.Save(historicoRaimundoOut);
            transacao.Commit();*/



            
            var repositoriocoordenador = new CoordenadorRepositoryImpl();
            
            var igCoordenador = new IgrejaCoordenador{
                CoordenadorFJU = new Jovem { 
                    Nome = "Nander Alves Antunes",
                    DataNascimento = DateTime.ParseExact("01/05/1981", "dd/MM/yyyy", null),
                    EstadoCivilJovem = new TipoEstadoCivil { Code = 6 },
                    ConjugeEhObreiro = 'S',
                    PossuiFilhos = 'N',
                    QuantidadeFilhos = 0,
                    SituacaoJovemIURDFJU = new SituacaoIURDFJU { 
                        EhObreiro = 'S',
                        MesAnoFoiLevantadoObreiro = "01/2008",
                        DesejaFazerObraNoAltar = 'S'
                    },
                    DadosEducacionaisJovem = new DadosEducacionais { },
                    DadosEspirituaisJovem = new DadosEspirituais { },
                    DadosProfissionaisJovem = new DadosProfissionais { },
                    RedeSocialJovem = new RedeSocial { },
                    DataCadastro = DateTime.Now,
                    EhPastor = false,
                    SiglaEstadoJovem = "SP"
                },
                IgrejaFJU = new Igreja { Id=59 },
                
                TotalAnosCoordenandoFJU=12,
                TotalMesesCoordenandoFJU=0,
                AnosCoordenandoIgrejaAtualFJU = 1,
                MesesCoordenandoIgrejaAtualFJU = 6,
                QuantidadeJovensEncontroAnterior=300,
                QuantidadeJovensEncontroAtual=800,
                DataEntradaCoordenador = DateTime.ParseExact("15/01/2020", "dd/MM/yyyy", null),
                FoiEntrevistadoEstadualFJU = 'S',      
                NomeEstadualEntrevistou = "Fabio Nunes",
                MesAnoEntrevistaEstadual = "09/2020",
                NomePastorEfetuouTroca = "Chambarelli Mello"
            };

            repositoriocoordenador.RegistraCoordenador2(igCoordenador);

            var idNovoCoordenador = igCoordenador.CoordenadorFJU.Id;

            var jovem = (new JovemRepositoryImpl()).ObterJovemInformacoesDetalhadas(new Jovem { Id = idNovoCoordenador });

                Console.ReadKey();

            //var estados = sessaoAberta.CreateCriteria<Jovem>().List<Jovem>();

            //Console.WriteLine("Lista de estados do Brasil");

            //foreach (var estadoRetornado in estados)
            //{
            //    string NomeEstado = estadoRetornado.Nome;
            //    string SiglaEstado = estadoRetornado.Nome;
            //    Console.WriteLine($"Estado: {NomeEstado} - Sigla: {SiglaEstado}");
            //}

            /*
            var repository = new RepositoryImpl<Jovem>();

            var situacaoIURDFJU = new SituacaoIURDFJU
            {
                EhObreiro = 'S',
                AnosObreiro = 3,
                MesesObreiro = 3,
                DesafiosConcluidos = 'S',
                NomeCamisaFJU = "Help",
                DesejaFazerObraNoAltar = 'S',
                PertenceAltarJovem = 'S',
                PertenceIntellimen = 'S',
                TelefoneParceiroIntellimen = "(11) 98887-4848"                

            };
            var endereco = new Endereco
            {
                Emdereco = "Av Celso Garcia Nº499",
                Bairro = "Brás",
                NomeEstado = "São Paulo",
                Cidade = "São Paulo",
                TipoDeMoradia = new TipoMoradia { Code = 1}
            };
            var contato = new Contato
            {
                Whatsapp = "(11) 97788-4455",
                NomeContatoEmergecia = "Lander",
                TelefoneEmergecia = "(11) 3656-4859"
            };
            var dadosEducacionais = new DadosEducacionais
            {
                GrauEscolaridade = "Ensino Superior Completo",
                Grau = "Ensino Superior",
                EstudaAtualmente = 'N',
                PossuiNivelSuperior = 'S'
            };
            var dadosEspirituais = new DadosEspirituais
            {
                AnoChegadaiurd = 2000,
                EhBatizadoAguas = 'S',
                BatismoAguasIURD = 'S',
                MesAnoBatismoAguas = "06/2000",
                LeuTodaBiblia = 'N',
                JaSeAfastou = 'N',
                TempoEstaFirme = "10 anos",
                EhBatizadoEspiritoSanto = 'S',
                MesAnoBatismoEspiritoSanto = "07/2000",
                EhMembroIURD = 'S',
                MesAnoEntradaFJU = "06/2000",
                ComoConheceuIURD = "Na hora da dor",
                MotivoEntradaFJU = "queria conhecer como ser um jovem feliz",
                OcasiaoBatismoEspiritoSanto = "Em uma vigília"
            };
            var redeSocial = new RedeSocial
            {
                Instagram = "@Anderson",
                Facebook = "fb.com/AndersonLino",
                Email = "andersonlino@gmail.com",
                PossuiCelularComInternet = 'S',
                PossuiComputador = 'S',
                EhLeitorUniversalorg = 'N',
                EhAssinanteUNIVER = 'S',
                EhLeitorBlogBM = 'S',
                EhSeguidorOficialFJU = 'S',
                EhSeguidorTelegram = 'S',
                EhSeguidorYoutube = 'S'
            };
            var novoJovem = new Jovem
            {
                Nome = "Anderson Antunes Coimbra",
                DataNascimento = DateTime.Parse("02/05/1990"),
                EstadoCivilJovem = new TipoEstadoCivil { Code = 1},                
                DataCadastro = DateTime.Now,
                PossuiTituloEleitor = 'S',
                NomeArquivoFoto = "foto1.png",
                PertenceGrupoMulheresIURD = 'N',
                EnderecoJovem          = endereco,
                DadosEspirituaisJovem  = dadosEspirituais,
                DadosEducacionaisJovem = dadosEducacionais,
                ContatoJovem           = contato,
                SituacaoJovemIURDFJU   = situacaoIURDFJU,
                RedeSocialJovem = redeSocial,                
            };

            var projetoCultura = new Projeto
            {
                Code = 9,
                NomeProjeto = "Cultura"
            };
            var departamentoBanda = new DepartamentoProjeto
            {
                Projeto = projetoCultura,
                NomeDepartamentoProjeto = "Banda"
            };
            projetoCultura.AddDepartamentoAoProjeto(departamentoBanda);

            novoJovem.AddCursoRelacionado(new CursoRelacionadoProjeto
            {
                NomeCurso = "Excel"
            });

            novoJovem.addLivroLidoPeloJovem(new Livro { });
            novoJovem.addReuniaoFJUAssistidaPeloJovem(new ReuniaoFJU { });
            */

            //NHibernateProfiler.Initialize();

            //var sessionFactory = FluentSessionFactory.CreateFactory("Server=34.202.180.165; Port=3306; Database=SGFJU_DEV;Uid=root;Pwd=!greja#universa1;");



            /*

            var repository = new RepositoryImpl<Estado>();
            var teste = repository.ListAllValueObjects<Tribo>();

            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {

                var criteria = session.CreateCriteria<Tribo>();
                //criteria.Add(Restrictions.Eq("EstadoBloco.Id", 1));
                var datasource = criteria.List<Tribo>();

                var projetoHelp = new Projeto { Code = 1 };
                //var departamentoConteudo = new DepartamentoProjeto
                //{
                //    Code = 6,
                //    Projeto = projetoHelp
                //};
                //var habilidadeEscreverTexto = new HabilidadeProjeto
                //{
                //    NomeHabilidade = "Web Writter",
                //    DepartamentoRelacionado = departamentoConteudo,
                //    ProjetoRelacionado = projetoHelp
                //};


                
                var contatoJovem = new Contato { 
                    Code = 1
                };
                var enderecoJovem = new Endereco { 
                    DescricaoEndereco = "Rua da guerra nº7",
                    Cidade = "São Paulo",
                    NomeEstado = "São Paulo",
                    Bairro = "Vitória"
                };
                var redeSocialJovem = new RedeSocial { 
                    Instagram = "@julianavitoria",
                    EhAssinanteUNIVER = 'S',
                    EhLeitorBlogBM = 'S',
                    EhLeitorUniversalorg = 'S',
                    EhSeguidorOficialFJU = 'S',
                    EhSeguidorTelegram = 'S',
                    EhSeguidorYoutube = 'S',
                    Facebook = "fb.com/windersongonsalvez",
                    PossuiCelularComInternet = 'S',
                    PossuiComputador = 'S',
                };
                var dadosProfissionais = new DadosProfissionais { 
                    NomeEmpresa = "Trabalho S/A",
                    EnderecoEmpresa = "Rua do trabalho nº11",
                    Profissao = "ANALISTA DE SISTEMAS",
                    TrabalhaAtualmente = 'S'
                };
                var dadosEspirituais = new DadosEspirituais { 
                    EhMembroIURD = 'S',
                    BatismoAguasIURD = 'S',
                    EhBatizadoAguas = 'S',
                    ComoConheceuIURD = "Convite familiar",
                    AnoChegadaiurd = 2000,
                    DescricaoFamiliaresIURD = "Marido, Mãe, pai e irmão",
                    DescricaoModoChegouFJU = "convite de um ente querido",
                    EhBatizadoEspiritoSanto = 'S',
                    LeuTodaBiblia = 'N',
                    MesAnoBatismoAguas = "01/2000",
                    MesAnoBatismoEspiritoSanto = "02/2000",
                    MesAnoChegadaIURD = "01/2000",
                    MotivoEntradaFJU = "queria uma mudança",
                    PossuiBiblia = 'S',
                    OcasiaoBatismoEspiritoSanto = "vigília",
                    TempoEstaFirme = "10 anos"
                };
                var dadosEducacionais = new DadosEducacionais { 
                    EstudaAtualmente = 'N',
                    Grau = "ensino superior completo",
                    GrauEscolaridade = "ensino médio completo",
                    NomeCursoSuperior = "Marketing",
                    NomeInstituicaoEnsino = "Castelo Branco",
                    PossuiNivelSuperior = 'S'
                };
                var situacaoIURDFJU = new SituacaoIURDFJU { 
                    EhObreiro = 'S',
                    AnosObreiro = 10,
                    EhPertencenteFJU = 'S',
                    EhLiderProjeto = 'N'                    
                };
                var igrejaSedeCachoerinha = new Igreja { Id = 1 };
                var tipoEstadoCivil = new TipoEstadoCivil { Code = 1 };

                var jovemGenesis = new Jovem
                {
                    Nome = "Golsanvez Ledo da cunha",
                    DataCadastro = DateTime.Now,
                    DataNascimento = DateTime.Parse("26/10/1998"),
                    PertenceGrupoMulheresIURD = 'N',
                    PossuiFilhos = 'S',
                    DataCasamento = DateTime.Parse("01/11/2000"),
                    ConjugeEhIURD = 'S',
                    NomeConjuge = "Vencedor carlos",
                    PossuiTituloEleitor = 'S',
                    QuantidadeFilhos = 1,
                    NomeArquivoFoto = "vencedor.png",
                    ContatoJovem = contatoJovem,
                    EnderecoJovem = enderecoJovem,
                    RedeSocialJovem = redeSocialJovem,
                    DadosProfissionaisJovem = dadosProfissionais,
                    DadosEspirituaisJovem = dadosEspirituais,
                    DadosEducacionaisJovem = dadosEducacionais,
                    SituacaoJovemIURDFJU = situacaoIURDFJU,
                    EstadoCivilJovem = tipoEstadoCivil,
                    IgrejaAQualJovemPertence = igrejaSedeCachoerinha
                };

                var cursoWebWriter = new CursoRelacionadoProjeto
                {
                    NomeCurso = "Designer gráfico",
                    ProjetoRelacionado = projetoHelp
                };

                jovemGenesis.AddCursoRelacionado(cursoWebWriter);
                var testemunho = new Testemunho
                {
                    JovemTestemunho = jovemGenesis,
                    SofreuComDepressao = 'S',
                    TempoLivreDepressao = "6 anos",
                    TempoSofreuDepressao = "2 ano",
                    TentouSuicidio = 'N',
                    TextoTestemunho = "tinha uma depressão venci, foram muitas lutas mais venci!!"
                };

                var comoVencerSuasGuerras = new Livro { Code = 1 };
                
                var algoAMais = new ReuniaoFJU { NomeReuniaoFJU = "Algo a mais" };

                var departamentoHelpConteudo = new DepartamentoProjeto
                {
                    Projeto = projetoHelp,
                    NomeDepartamentoProjeto = "Conteúdo"
                };

                var idiomaIngles = new Idioma { NomeIdioma = "Inglês" };

                var nivelExcelente = new Nivel { Descricao = "Excelente" };

                var jovemIdioma = new JovemIdioma { Jovem = jovemGenesis, Idioma = idiomaIngles, Nivel = nivelExcelente };

                var habilidadeEscritor = new HabilidadeProjeto
                {
                    NomeHabilidade = "Escritora",
                    DepartamentoRelacionado = departamentoHelpConteudo,
                    ProjetoRelacionado = projetoHelp
                };

                var jovemPHabilidade = new JovemHabilidadeProjeto {
                    Jovem = jovemGenesis,
                    Habilidade = habilidadeEscritor,
                    Nivel = nivelExcelente
                };

                var jovemProjeto = new JovemProjeto
                {
                    Jovem = jovemGenesis,
                    AnosProjeto = 5,
                    TempoProjeto = "5 anos",
                    PertenceuOutroProjeto = 'N',
                    Projeto = projetoHelp,
                    ProjetoAnterior = null
                };

                jovemGenesis.addLivroLidoPeloJovem(comoVencerSuasGuerras);
                jovemGenesis.addReuniaoFJUAssistidaPeloJovem(reuniaoFJU: algoAMais);
                jovemGenesis.addDepartamentoProjetoJovemFazParte(departamentoProjeto: departamentoHelpConteudo);

                

                //session.Save(contatoJovem);
                //session.Save(enderecoJovem);                
                //session.Save(redeSocialJovem);
                //session.Save(dadosProfissionais);
                //session.Save(dadosEspirituais);
                //session.Save(dadosEducacionais);
                //session.Save(situacaoIURDFJU);

                ////session.Save(comoVencerSuasGuerras);
                //session.Save(departamentoHelpConteudo);
                //session.Save(algoAMais);

                //session.Save(habilidadeEscritor);

                //session.Save(jovemGenesis);

                //session.Save(idiomaIngles);
                //session.Save(nivelExcelente);

                //session.Save(jovemIdioma);
                //session.Save(jovemPHabilidade);
                //session.Save(jovemProjeto);
                //session.Save(testemunho);



                //transaction.Commit();
            }

            */

        }
    }
}
