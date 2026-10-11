using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CabinetMaker.Domain.Entities;

[Table("Type")]
public class CmType : CmEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int TypeID { get; set; }
    public int TypeClassID { get; set; }
    [MaxLength(255)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(2000)]
    public string Description { get; set; } = string.Empty;
    public int Ordering { get; set; } = 0;
    public int? TypeInt { get; set; } = default;
    public string? TypeString { get; set; } = default;
    public decimal? TypeDecimal { get; set; } = default;
}
