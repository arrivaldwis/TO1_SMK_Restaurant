//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TO1_SMK_Restaurant
{
    using System;
    using System.Collections.Generic;
    
    public partial class MenuIngredient
    {
        public int menuIngredientsId { get; set; }
        public int menuId { get; set; }
        public int ingredientsId { get; set; }
        public int qty { get; set; }
    
        public virtual Ingredient Ingredient { get; set; }
        public virtual Menu Menu { get; set; }
    }
}