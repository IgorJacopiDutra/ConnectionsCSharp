using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionsWindowsFormsCSharp.Model
{
    [Table("CLIENTES")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int? Id { get; set; }
        [Column("NOME")]
        public string? Nome { get; set; }
        [Column("TPDOCTO")]
        public string? TpDocto { get; set; }
        [Column("DOCTO")]
        public string? Docto { get; set; }
        [Column("TELEFONE")]
        public string? Telefone { get; set; }
    }
}
