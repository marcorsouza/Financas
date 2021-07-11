using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financas.Core.Entidades
{
    public class RelatorioItem
    {
        [Key] 
        public long Id { get; set; }

        [ForeignKey("RelatorioId")]
        public Relatorio Relatorio { get; set; }
        public string Chave { get; set; }
        public decimal Cotacao {get;set;}
        public decimal PL {get;set;}
        public decimal PVp {get;set;}
        public decimal Psr {get;set;}
        public decimal DY {get;set;}
        public decimal PAtivo {get;set;}
        public decimal PCapGiro {get;set;}
        public decimal PEbit {get;set;}
        public decimal PAtivCircLiq {get;set;}
        public decimal EvEbit {get;set;}
        public decimal EvEbitda {get;set;}
        public decimal MrgEbit {get;set;}
        public decimal MrgLiq {get;set;}
        public decimal LiqCorr {get;set;}
        public decimal Roic {get;set;}
        public decimal Roe {get;set;}
        public decimal Liq2Meses {get;set;}
        public decimal PatrimLiq {get;set;}
        public decimal DivBrutPatrim {get;set;}
        public decimal CrescRec5a {get;set;}
    }


    public class RelatorioFiiItem
    {
        [Key] 
        public long Id { get; set; }

        [ForeignKey("RelatorioId")]
        public Relatorio Relatorio { get; set; }
        public string Chave { get; set; }
        public string Segmento { get; set; }
        public decimal Cotacao {get;set;}
        public decimal FFoYield {get;set;}
        public decimal DY {get;set;}
        public decimal PVp {get;set;}
        public decimal ValorDeMercado {get;set;}
        public decimal Liquidez {get;set;}
        public decimal QtdImoveis {get;set;}
        public decimal PrecoM2 {get;set;}
        public decimal AluguelM2 {get;set;}
        public decimal CapRate {get;set;}
        public decimal VacanciaMedia {get;set;}
    }
}