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
    
    public partial class algemene_groepen
    {
        public int Accounts_IdAccount { get; set; }
        public int Groepen_IdGroep { get; set; }
        public string Info { get; set; }
    
        public virtual accounts accounts { get; set; }
        public virtual groepen groepen { get; set; }
    }
}
