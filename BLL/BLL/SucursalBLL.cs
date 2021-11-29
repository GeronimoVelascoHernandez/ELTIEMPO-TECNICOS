using DAL.DAL;
using MODEL;
using MODEL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL
{
    public class SucursalBLL
    {
        private SucursalDAL SucursalDAL = new SucursalDAL();

        public List<SucursalViewModel> listSucursals() {
           return  SucursalDAL.ListSucursals();
        }
    }
}
