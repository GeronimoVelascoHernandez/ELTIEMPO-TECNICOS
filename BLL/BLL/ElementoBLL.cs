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
    public class ElementoBLL
    {
        private  ElementoDAL ElementoDAL = new ElementoDAL();

        public List<ElementoViewModel> ListElements() {
            return ElementoDAL.ListElements();
        }
    }
}
