//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Divisio.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class provincie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public provincie()
        {
            this.postcodeGemeente = new HashSet<postcodeGemeente>();
        }
    
        public int Idprovincie { get; set; }
        public string ProvincieNaam { get; set; }
        public Nullable<int> Land_IdLand { get; set; }
    
        public virtual land land { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<postcodeGemeente> postcodeGemeente { get; set; }
    }
}
