//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MODEL
{
    using MODEL.ViewModels;
    using System;
    using System.Collections.Generic;
    
    public partial class Sucursal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sucursal()
        {
            this.Tecnicoes = new HashSet<Tecnico>();
        }
    
        public int idSucursal { get; set; }
        public string nombre { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tecnico> Tecnicoes { get; set; }

        public static implicit operator Sucursal(SucursalViewModel sucursalViewModel)
        {
            Sucursal sucursal = new Sucursal();
            sucursal.idSucursal = sucursalViewModel.idSucursal;
            sucursal.nombre = sucursalViewModel.nombre;
            return sucursalViewModel;
        }
    }
}
