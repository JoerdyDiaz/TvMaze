//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaDatos.AdoModelEF
{
    using System;
    using System.Collections.Generic;
    
    public partial class External
    {
        public int ShowId { get; set; }
        public Nullable<int> Tvrage { get; set; }
        public Nullable<int> Thetvdb { get; set; }
        public string Imdb { get; set; }
    
        public virtual Show Show { get; set; }
    }
}
