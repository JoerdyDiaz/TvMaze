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
    
    public partial class Show
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Show()
        {
            this.Genres = new HashSet<Genre>();
            this.ScheduleDays = new HashSet<ScheduleDay>();
        }
    
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Language { get; set; }
        public string Status { get; set; }
        public Nullable<int> Runtime { get; set; }
        public Nullable<int> AverageRuntime { get; set; }
        public Nullable<System.DateTime> Premiered { get; set; }
        public Nullable<System.DateTime> Ended { get; set; }
        public string OfficialSite { get; set; }
        public Nullable<int> Weight { get; set; }
        public string Summary { get; set; }
        public Nullable<long> Updated { get; set; }
        public string webChannel { get; set; }
        public string dvdCountry { get; set; }
        public Nullable<int> NetworkId { get; set; }
    
        public virtual External External { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual Image Image { get; set; }
        public virtual Link Link { get; set; }
        public virtual Network Network { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ScheduleDay> ScheduleDays { get; set; }
        public virtual Rating Rating { get; set; }
    }
}
