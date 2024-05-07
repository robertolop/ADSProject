using ADSProject.DB;
using ADSProject.Interfaces;
using ADSProject.Migrations;
using ADSProject.Models;

namespace ADSProject.Repositories
{
    public class ProfesorRepository : IProfesor
    {
        /* private List<Profesor> lstProfesor = new List<Profesor>
         {
             new Profesor{IdProfesor = 1, NombresProfesor = "Pedro Antonio ", ApellidosProfesor = "Cuncurrumin chicha",
             Email = "PedroCuncurrumin@gmail.com"}
         };*/

        private readonly ApplicationDbContext applicationDbContext;

        public ProfesorRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public int ActualizarProfesor(int idProfesor, Profesor profesor)
        {
            try
            {
                //Obtener el indice del Objeto para actualizar 
                /* int indice = lstProfesor.FindIndex(tmp => tmp.IdProfesor == idProfesor);

                 //procedemos con la actualizacion
                 lstProfesor[indice] = profesor;*/

                var item = applicationDbContext.Profesores.SingleOrDefault(x => x.IdProfesor == idProfesor);

                applicationDbContext.Entry(item).CurrentValues.SetValues(profesor);

                applicationDbContext.SaveChanges();

                return idProfesor;
            }
            catch (Exception)
            {
                throw;
            }
            //throw new NotImplementedException();
        }
        public int AgregarProfesor(Profesor profesor)
        {
            try
            {
                //validar si existen datos en la lista, debe se asi, tomaremos el ultimo ID
                // y lo incrementamos en una unidad 
                /*if (lstProfesor.Count > 0)
                {
                    profesor.IdProfesor = lstProfesor.Last().IdProfesor + 1;
                }
                lstProfesor.Add(profesor);*/

                applicationDbContext.Profesores.Add(profesor);
                applicationDbContext.SaveChanges();

                return profesor.IdProfesor;
            }
            catch (Exception)
            {
                throw;
            }
           // throw new NotImplementedException();
        }
        public bool EliminarProfesor(int idProfesor)
        {
            try
            {
                //Obtener el indice del Objeto para Eliminar 
                /*int indice = lstProfesor.FindIndex(tmp => tmp.IdProfesor == idProfesor);

                //procedemos a eliminar el registro
                lstProfesor.RemoveAt(indice);*/

                var item = applicationDbContext.Profesores.SingleOrDefault(x => x.IdProfesor == idProfesor);

                applicationDbContext.Profesores.Remove(item);
                applicationDbContext.SaveChanges();

                return true;


            }
            catch (Exception)
            {
                throw;
            }
            //throw new NotImplementedException();
        }
        public Profesor ObtenerProfesorPorID(int idProfesor)
        {
            try
            {

                //Profesor profesor = lstProfesor.FirstOrDefault(tmp => tmp.IdProfesor == idProfesor);
                var profesor = applicationDbContext.Profesores.SingleOrDefault(x => x.IdProfesor == idProfesor);

                return profesor;

            }
            catch (Exception)
            {
                throw;
            }
          //  throw new NotImplementedException();
        }
        public List<Profesor> ObtenerTodosLosProfesores()
        {
            try
            {
                // return lstProfesor;
                return applicationDbContext.Profesores.ToList();
            }
            catch (Exception)
            {
                throw;
            }
           // throw new NotImplementedException();
        }
    }

}
