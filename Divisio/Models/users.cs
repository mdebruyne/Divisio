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
    
    public partial class users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public users()
        {
            this.accounts = new HashSet<accounts>();
        }
    
        public int IdUser { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string Straat { get; set; }
        public string Huisnummer { get; set; }
        public Nullable<int> postcodeGemeente_IdGemeente { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<accounts> accounts { get; set; }
        public virtual postcodeGemeente postcodeGemeente { get; set; }
    }
}
