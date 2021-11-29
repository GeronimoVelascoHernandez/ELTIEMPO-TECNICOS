using MODEL;
using MODEL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL
{
    public class SucursalDAL
    {
        public List<SucursalViewModel> ListSucursals()
        {
            using (TECNICOSEntities db = new TECNICOSEntities())
            {
                var sucursals = db.Sucursals.Select(s => new SucursalViewModel{ 
                    idSucursal  = s.idSucursal,
                    nombre = s.nombre
                }).ToList();
                return sucursals;
            }
        }
    }
}
