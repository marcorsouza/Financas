using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financas.Core.Entidades
{

    public class Relatorio
    {
        public long Id { get; set; }
        public string Referencia { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        [ForeignKey("PapelTipoId")]
        public PapelTipo PapelTipo { get; set; }

        public ICollection<RelatorioItem> RelatorioItens { get; set; } = new List<RelatorioItem>();

        public ICollection<RelatorioFiiItem> RelatorioFiiItens { get; set; } = new List<RelatorioFiiItem>();
    }
}