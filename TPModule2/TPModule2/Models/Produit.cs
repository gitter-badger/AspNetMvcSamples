using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TPModule2.Models
{
    [MetadataType(typeof(ProduitMetadata))]
    public partial class Produit
    {
    }

    public class ProduitMetadata
    {
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Nom { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        public decimal Prix { get; set; }
    }
}