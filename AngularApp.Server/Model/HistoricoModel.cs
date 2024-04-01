using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AngularApp.Server.Model
{
    public class HistoricoModel
    {
        [Column("_id")]
        public int Id { get; init; }
        [Required]
        [Column("COD_JOGADOR")]
        public required string CodigoUsuario { get; set; }
        [Column("TENTATIVA")]
        public required int Tentativa { get; set; }
        [Column("DT_HR_TENTATIVA")]
        public DateTime DataHora { get; set; } = DateTime.Now;
        [Column("RESULTADO")]
        public int Resultado { get; set; }
        public int numeroSorteado;
        [Required] 
        public int Chute { get; set; }
        public int dificuldade;

    }
}
