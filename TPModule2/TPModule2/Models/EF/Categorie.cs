//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TPModule2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Categorie
    {
        public Categorie()
        {
            this.Produits = new HashSet<Produit>();
        }
    
        public int Id { get; set; }
        public string Nom { get; set; }
    
        public virtual ICollection<Produit> Produits { get; set; }
    }
}
