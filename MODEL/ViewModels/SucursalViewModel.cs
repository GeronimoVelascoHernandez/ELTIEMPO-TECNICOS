namespace MODEL.ViewModels
{
    public partial class SucursalViewModel
    {
        public int idSucursal { get; set; }
        public string nombre { get; set; }

        public static implicit operator SucursalViewModel(Sucursal sucursal)
        {
            SucursalViewModel sucursalViewModel = new SucursalViewModel();
            sucursalViewModel.idSucursal = sucursal.idSucursal;
            sucursalViewModel.nombre = sucursal.nombre;
            return sucursalViewModel;
        }
    }
}
