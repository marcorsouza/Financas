using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Financas.Core;
using Financas.Core.Entidades;
using System.Linq;

namespace Financas.App.Desktop
{
    public static class UtilsExtensions {
        public static string RemoveCaracteres(this string text){
            text = text.Replace("%","");

            return text;
        }
    }
    class Program
    {
        public static EFCoreContext Context = new EFCoreContext();

        public static string Dir = @"C:\Dados\Projetos\Financas\Arquivos\";
        public static List<PapelTipo> PapelTipos { get; set; }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            try
            {
                PapelTipos = Context.PapelTipos.ToList();

                //InsertPapeis(1);
                //InserirRelatorioAcoes();
                
               // InsertPapeis(2);
               //InserirRelatorioFiis();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
            }

            //Console.ReadKey();
        }

        private static void InsertPapeis(int tipo)
        {
            string linha = "";
            string[] linhaseparada = null;
            List<Papel> papeis = new List<Papel>();
            StreamReader reader =null;
            if(tipo == 1){
                reader = new StreamReader(Dir+"papel.csv", Encoding.UTF8, true);
                
                while (true)
                {
                    linha = reader.ReadLine();
                    if (linha == null) break;
                    linhaseparada = linha.Split(';');

                    var papel = new Papel();
                    papel.Chave = linhaseparada[0];
                    papel.Nome = linhaseparada[1];
                    papel.PapelTipo = PapelTipos.FirstOrDefault(x => x.Id.Equals(2));
                    papeis.Add(papel);
                }

                foreach (var papel in papeis)
                {
                    try
                    {
                        Context.Add(papel);
                        Context.SaveChanges();
                        Console.WriteLine($"ID => {papel.Chave} || Nome => {papel.Nome}");
                    }
                    catch (System.Exception ex)
                    {
                        Console.WriteLine(ex.InnerException.Message);
                    }
                }
            }else{
               /* reader = new StreamReader(Dir+"papelFii.csv", Encoding.UTF8, true);
                
                while (true)
                {
                    linha = reader.ReadLine();
                    if (linha == null) break;
                    linhaseparada = linha.Split(';');

                    var papel = new Papel();
                    papel.Chave = linhaseparada[0];
                    papel.Nome = linhaseparada[1];
                    papel.PapelTipo = PapelTipos.FirstOrDefault(x => x.Id.Equals(1));
                    papeis.Add(papel);
                }

                foreach (var papel in papeis)
                {
                    try
                    {
                        Context.Add(papel);
                        Context.SaveChanges();
                        Console.WriteLine($"ID => {papel.Chave} || Nome => {papel.Nome}");
                    }
                    catch (System.Exception ex)
                    {
                        Console.WriteLine(ex.InnerException.Message);
                    }
                }*/
            }
        }

        public static void InserirRelatorioAcoes(){
            var date = DateTime.Now;
                var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

                Relatorio relatorio = new Relatorio();
                relatorio.DataInicio = firstDayOfMonth;
                relatorio.DataFim = lastDayOfMonth;
                relatorio.Referencia = DateTime.Now.ToString("MM/yyyy");               
                relatorio.PapelTipo = PapelTipos.FirstOrDefault(x => x.Id.Equals(2));

                string linha = "";
                string[] linhaseparada = null;
                StreamReader reader = new StreamReader(Dir+"relatorio.csv", Encoding.UTF8, true);
                List<RelatorioItem> itens = new List<RelatorioItem>();

                var numLinha = 0;
                while (true)
                {
                    linha = reader.ReadLine();

                    if(numLinha == 0){
                        numLinha++;
                        continue;
                    }

                    if (linha == null) break;
                        linhaseparada = linha.Split(';');

                    var item = new RelatorioItem();
                    
                    item.Chave = linhaseparada[0];
                    item.Cotacao = decimal.Parse(linhaseparada[1].RemoveCaracteres());
                    item.PL = decimal.Parse(linhaseparada[2].RemoveCaracteres());
                    item.PVp = decimal.Parse(linhaseparada[3].RemoveCaracteres());
                    item.Psr = decimal.Parse(linhaseparada[4].RemoveCaracteres());
                    item.DY = decimal.Parse(linhaseparada[5].RemoveCaracteres());
                    item.PAtivo = decimal.Parse(linhaseparada[6].RemoveCaracteres());
                    item.PCapGiro = decimal.Parse(linhaseparada[7].RemoveCaracteres());
                    item.PEbit = decimal.Parse(linhaseparada[8].RemoveCaracteres());
                    item.PAtivCircLiq = decimal.Parse(linhaseparada[9].RemoveCaracteres());
                    item.EvEbit = decimal.Parse(linhaseparada[10].RemoveCaracteres());
                    item.EvEbitda = decimal.Parse(linhaseparada[11].RemoveCaracteres());
                    item.MrgEbit = decimal.Parse(linhaseparada[12].RemoveCaracteres());
                    item.MrgLiq = decimal.Parse(linhaseparada[13].RemoveCaracteres());
                    item.LiqCorr = decimal.Parse(linhaseparada[14].RemoveCaracteres());
                    item.Roic = decimal.Parse(linhaseparada[15].RemoveCaracteres());
                    item.Roe = decimal.Parse(linhaseparada[16].RemoveCaracteres());
                    item.Liq2Meses = decimal.Parse(linhaseparada[17].RemoveCaracteres());
                    item.PatrimLiq = decimal.Parse(linhaseparada[18].RemoveCaracteres());
                    item.DivBrutPatrim = decimal.Parse(linhaseparada[19].RemoveCaracteres());
                    item.CrescRec5a = decimal.Parse(linhaseparada[20].RemoveCaracteres());
                    item.Relatorio = relatorio;

                    itens.Add(item);

                }

                foreach (var item in itens)
                {
                   relatorio.RelatorioItens.Add(item);
                }

                Context.Add(relatorio);
                Context.SaveChanges();
        }

        public static void InserirRelatorioFiis(){
            var date = DateTime.Now;
                var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

                Relatorio relatorio = new Relatorio();
                relatorio.DataInicio = firstDayOfMonth;
                relatorio.DataFim = lastDayOfMonth;
                relatorio.Referencia = DateTime.Now.ToString("MM/yyyy");               
                relatorio.PapelTipo = PapelTipos.FirstOrDefault(x => x.Id.Equals(1));
                string linha = "";
                string[] linhaseparada = null;
                StreamReader reader = new StreamReader(Dir+"fiis.csv", Encoding.UTF8, true);
                List<RelatorioFiiItem> itens = new List<RelatorioFiiItem>();

                var numLinha = 0;
                while (true)
                {
                    linha = reader.ReadLine();

                    if(numLinha == 0){
                        numLinha++;
                        continue;
                    }

                    if (linha == null) break;
                        linhaseparada = linha.Split(';');

                    var item = new RelatorioFiiItem();                    
                    item.Chave = linhaseparada[0];
                    item.Segmento = linhaseparada[1];
                    item.Cotacao = decimal.Parse(linhaseparada[2].RemoveCaracteres());
                    item.FFoYield = decimal.Parse(linhaseparada[3].RemoveCaracteres());
                    item.DY = decimal.Parse(linhaseparada[4].RemoveCaracteres());
                    item.PVp = decimal.Parse(linhaseparada[5].RemoveCaracteres());
                    item.ValorDeMercado = decimal.Parse(linhaseparada[6].RemoveCaracteres());
                    item.Liquidez = decimal.Parse(linhaseparada[7].RemoveCaracteres());
                    item.QtdImoveis = decimal.Parse(linhaseparada[8].RemoveCaracteres());
                    item.PrecoM2 = decimal.Parse(linhaseparada[9].RemoveCaracteres());
                    item.AluguelM2 = decimal.Parse(linhaseparada[10].RemoveCaracteres());
                    item.CapRate = decimal.Parse(linhaseparada[11].RemoveCaracteres());
                    item.VacanciaMedia = decimal.Parse(linhaseparada[12].RemoveCaracteres());
                    item.Relatorio = relatorio;

                    if(item.Chave.Equals("MXRF11")){
                        Console.WriteLine($"item.Chave => {item.Chave}");
                    }
                    itens.Add(item);

                }

                foreach (var item in itens)
                {
                   relatorio.RelatorioFiiItens.Add(item);
                }

                Context.Add(relatorio);
                Context.SaveChanges();
        }
    }
}