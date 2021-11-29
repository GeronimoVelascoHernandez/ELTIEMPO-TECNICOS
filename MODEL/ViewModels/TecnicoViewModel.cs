using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MODEL;
namespace MODEL.ViewModels
{
    public partial class TecnicoViewModel
    {
        [Required]
        [Display(Name = "Código")]
        [RegularExpression(@"^[A-Za-z0-9_-]*$",
         ErrorMessage = "No se permiten caracteres especiales")]
        public string idTecnico { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z0-9_-]*$",
        ErrorMessage = "No se permiten caracteres especiales")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Required]
        [RegularExpression(@"^[0-9_-]*$",
         ErrorMessage = "No se permiten letras")]
        [Display(Name = "Salario")]
        public int salario { get; set; }
        [Display(Name = "Sucursal")]
        public string sucursal { get; set; }
        [Required]
        [Display(Name = "Sucursal")]
        public int IdSucursal { get; set; }
        [Display(Name = "Elementos")]
        public int cantidadElementos { get; set; }

        public List<TecnicoElementoViewModel> elements { get; set; }

        public static implicit operator TecnicoViewModel(Tecnico tecnico)
        {
            TecnicoViewModel tecnicoViewModel = new TecnicoViewModel();
            tecnicoViewModel.idTecnico = tecnico.idTecnico;
            tecnicoViewModel.nombre = tecnico.nombre;
            tecnicoViewModel.salario = tecnico.salario;
            tecnicoViewModel.IdSucursal = tecnico.IdSucursal;
            return tecnicoViewModel;
        }
    }


}
