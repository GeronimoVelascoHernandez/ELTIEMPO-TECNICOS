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
    using System.Collections.Generic;
    
    public partial class Elemento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Elemento()
        {
            this.TecnicoElementoes = new HashSet<TecnicoElemento>();
        }
    
        public int idElemento { get; set; }
        public string nombre { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TecnicoElemento> TecnicoElementoes { get; set; }

        public static implicit operator Elemento(ElementoViewModel elementoViewModel) {
            Elemento elemento = new Elemento();
            elemento.idElemento = elementoViewModel.idElemento; 
            elemento.nombre = elementoViewModel.nombre;
            return elemento;
        }
    }
}
