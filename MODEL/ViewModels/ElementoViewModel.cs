namespace MODEL.ViewModels
{
    public partial class ElementoViewModel
    {
        public int idElemento { get; set; }
        public string nombre { get; set; }

        public static implicit operator ElementoViewModel(Elemento elemento)
        {
            ElementoViewModel elementoViewModel = new ElementoViewModel();
            elementoViewModel.idElemento = elemento.idElemento;
            elementoViewModel.nombre = elemento.nombre;
            return elementoViewModel;
        }
    }
}
