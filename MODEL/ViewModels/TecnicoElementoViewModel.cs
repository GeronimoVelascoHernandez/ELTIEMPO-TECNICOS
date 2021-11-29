namespace MODEL.ViewModels
{
    public partial  class TecnicoElementoViewModel
    {
        public int idTecnicoElemento { get; set; }
        public int cantidad { get; set; }
        public string idTecnico { get; set; }
        public int idElemento { get; set; }
        public string elemento { get; set; }

        public static implicit operator TecnicoElementoViewModel(TecnicoElemento tecnicoElement)
        {
            TecnicoElementoViewModel tecnicoElementoViewModel = new TecnicoElementoViewModel();
            tecnicoElementoViewModel.cantidad = tecnicoElement.cantidad;
            tecnicoElementoViewModel.idTecnico = tecnicoElement.idTecnico;
            tecnicoElementoViewModel.elemento = tecnicoElement.elemento;
            return tecnicoElementoViewModel;
        }
    }
}
