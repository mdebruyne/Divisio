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
    
    public partial class postcodeGemeente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public postcodeGemeente()
        {
            this.users = new HashSet<users>();
        }
    
        public string Postcode { get; set; }
        public string Gemeente { get; set; }
        public int IdGemeente { get; set; }
        public Nullable<int> Provincie_IdProvincie { get; set; }
    
        public virtual provincie provincie { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<users> users { get; set; }
    }
}
