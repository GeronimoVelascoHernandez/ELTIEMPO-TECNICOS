using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MODEL.ViewModels;

namespace DAL.DAL
{
    public class ElementoDAL
    {
        public List<ElementoViewModel> ListElements()
        {
            using (TECNICOSEntities db = new TECNICOSEntities())
            {
                var elements = db.Elementoes.Select(e => new ElementoViewModel { 
                    idElemento = e.idElemento,
                    nombre = e.nombre
                }).ToList();
                return elements;
            }
        }
    }
}
