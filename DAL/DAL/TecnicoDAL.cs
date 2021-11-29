using System;
using System.Collections.Generic;
using System.Linq;
using MODEL;
using MODEL.ViewModels;
using System.Data.Entity;
namespace DAL.DAL
{
    public class TecnicoDAL
    {
        public List<TecnicoViewModel> ListTechnicians()
        {
            using (TECNICOSEntities db = new TECNICOSEntities())
            {
                var technicians = db.Tecnicoes.Include(s => s.Sucursal).Include(te => te.TecnicoElementoes)
                                              .Select(tech =>
                                                  new TecnicoViewModel
                                                  {
                                                      idTecnico = tech.idTecnico,
                                                      nombre = tech.nombre,
                                                      salario = tech.salario,
                                                      IdSucursal = tech.IdSucursal,
                                                      sucursal = tech.Sucursal.nombre,
                                                      cantidadElementos = tech.TecnicoElementoes.Sum(s => s.cantidad)
                                                  }
                                              ).ToList();

                db.SaveChanges();
                return technicians;
            }
        }

        public List<TecnicoElementoViewModel> FindTechnicianElements(string id)
        {
            using (TECNICOSEntities db = new TECNICOSEntities())
            {
                var technicians = db.TecnicoElementoes.Include(e => e.Elemento).Where(te => te.idTecnico == id)
                                              .Select(tech =>
                                                  new TecnicoElementoViewModel
                                                  { 
                                                      idElemento = tech.idElemento,
                                                      cantidad = tech.cantidad,
                                                      elemento = tech.Elemento.nombre
                                                  }
                                              ).ToList();

                db.SaveChanges();
                return technicians;
            }
        }

        public List<TecnicoElementoViewModel> FindTechnicianElementsByIdTechnico(string id)
        {
            using (TECNICOSEntities db = new TECNICOSEntities())
            {
                var technicians = db.TecnicoElementoes.Include(e => e.Elemento).Where(te => te.idTecnico == id)
                                              .Select(tech =>
                                                  new TecnicoElementoViewModel
                                                  {
                                                      idElemento = tech.idElemento,
                                                      cantidad = tech.cantidad,
                                                      elemento = tech.Elemento.nombre
                                                  }
                                              ).ToList();

                db.SaveChanges();
                return technicians;
            }
        }
        public bool CreateTechnician(TecnicoViewModel technician)
        {
            using (TECNICOSEntities db = new TECNICOSEntities())
            {
                var transaction = db.Database.BeginTransaction();
                try
                {
                    Tecnico tecnico = technician;
                    db.Tecnicoes.Add(tecnico);
                    db.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        public bool CreateTechnicianElements(List<TecnicoElementoViewModel> technicianElements, string idTecnico)
        {
            using (TECNICOSEntities db = new TECNICOSEntities())
            {
                var transaction = db.Database.BeginTransaction();
                try
                {
                    foreach (var teElement in technicianElements) {
                        TecnicoElemento tecnicoElemento = new TecnicoElemento();
                        tecnicoElemento.idElemento = teElement.idElemento;
                        tecnicoElemento.cantidad = teElement.cantidad;  
                        tecnicoElemento.idTecnico = idTecnico;
                        db.TecnicoElementoes.Add(tecnicoElemento);
                        db.SaveChanges();
                    }
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        public TecnicoViewModel FindTechnicianById(string id)
        {
            using (TECNICOSEntities db = new TECNICOSEntities())
            { 
                try
                {
                    var technician = db.Tecnicoes.Where(tec => tec.idTecnico == id).FirstOrDefault();
                    db.SaveChanges();
                    TecnicoViewModel technicianViewModel = technician;
                    return technicianViewModel;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public bool EditTechnician(TecnicoViewModel Technician)
        {
            using (TECNICOSEntities db = new TECNICOSEntities())
            {
                var transaction = db.Database.BeginTransaction();
                try
                {
                    Tecnico technician = Technician;
                    db.Entry(technician).State = EntityState.Modified;
                    db.SaveChanges();
                    transaction.Commit();
                    return true;

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
          
        }
        public bool DeleteTechnician(string id)
        {
            using (TECNICOSEntities db = new TECNICOSEntities())
            {
                var transaction = db.Database.BeginTransaction();
                try
                {
                    Tecnico technician = db.Tecnicoes.Find(id);
                    db.Tecnicoes.Remove(technician);
                    db.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
            
        }
        public bool DeleteTechnicianElements(string id)
        {
            using (TECNICOSEntities db = new TECNICOSEntities())
            {
                var transaction = db.Database.BeginTransaction();
                try
                {
                    List<TecnicoElemento> elementos = db.TecnicoElementoes.Where(tech => tech.idTecnico == id).ToList();
                    foreach (var elemento in elementos)
                    {
                        db.TecnicoElementoes.Remove(elemento);
                    }
                    db.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }

        }

      
}
}
