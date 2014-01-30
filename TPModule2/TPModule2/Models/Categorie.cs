using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TPModule2.Models
{
    [MetadataType(typeof(CategorieMetadata))]
    public partial class Categorie : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();
            if (Nom.Length < 5 || Nom.Length > 100)
            {
                result.Add(new ValidationResult("Le nom de la catégorie doit comprendre entre 5 et 100 charactères"));
            }
            return result;
        }
    }

    public class CategorieMetadata
    {
        [Required]
        [Display(Name="Nom de la catégorie")]
        public string Nom { get; set; }
    }
}