using System.ComponentModel.DataAnnotations.Schema;

namespace Financas.Core.Entidades
{
    public class Papel
    {
        public long Id { get; set; }
        public string Chave { get; set; }
        public string Nome { get; set; }
        [ForeignKey("PapelTipoId")]
        public PapelTipo PapelTipo { get; set; }
    }

    public class PapelTipo
    {
        public long Id { get; set; }
        public string Tipo { get; set; }
    }
}