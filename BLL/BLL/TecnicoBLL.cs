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
    public class TecnicoBLL
    {
        private TecnicoDAL TechnicianDAL = new TecnicoDAL();
        public List<TecnicoViewModel> ListTechnicians()
        {
            return TechnicianDAL.ListTechnicians();
        }
        public bool CreateTechnician(TecnicoViewModel technician)
        {
                var technicianElements = technician.elements;
                TechnicianDAL.CreateTechnician(technician);
                TechnicianDAL.CreateTechnicianElements(technicianElements, technician.idTecnico);
                return true;

        }

        public bool EditTechnician(TecnicoViewModel technician, string idTecnico)
        {
            
            if (TechnicianDAL.EditTechnician(technician))
            {
                TechnicianDAL.DeleteTechnicianElements(technician.idTecnico);
                var technicianElements = technician.elements;
                TechnicianDAL.CreateTechnicianElements(technicianElements,idTecnico );
                return true;
            }
            return false;

        }

        public TecnicoViewModel FindTechnicianById(string id)
        {
            return TechnicianDAL.FindTechnicianById(id);
        }

        public bool DeleteTechnician(string id)
        {
            
            if (TechnicianDAL.DeleteTechnicianElements(id))
            {
                TechnicianDAL.DeleteTechnician(id);
                return true;
            }
            return false;

        }

        public List<TecnicoElementoViewModel> FindTechnicianElements(string id)
        {
            return TechnicianDAL.FindTechnicianElements(id);
        }
    }
}
