using ADSProject.Interfaces;
using ADSProject.Models;

namespace ADSProject.Repositories
{
    public class ProfesorRepository : IProfesor
    {
        private List<Profesor> lstProfesor = new List<Profesor>
        {
            new Profesor{IdProfesor = 1, NombresProfesor = "Pedro Antonio ", ApellidosProfesor = "Cuncurrumin chicha",
            Email = "PedroCuncurrumin@gmail.com"}
        };

        public int ActualizarProfesor(int idProfesor, Profesor profesor)
        {
            try
            {
                //Obtener el indice del Objeto para actualizar 
                int indice = lstProfesor.FindIndex(tmp => tmp.IdProfesor == idProfesor);

                //procedemos con la actualizacion
                lstProfesor[indice] = profesor;

                return idProfesor;
            }
            catch (Exception)
            {
                throw;
            }
            throw new NotImplementedException();
        }
        public int AgregarProfesor(Profesor profesor)
        {
            try
            {
                //validar si existen datos en la lista, debe se asi, tomaremos el ultimo ID
                // y lo incrementamos en una unidad 
                if (lstProfesor.Count > 0)
                {
                    profesor.IdProfesor = lstProfesor.Last().IdProfesor + 1;
                }
                lstProfesor.Add(profesor);
                return profesor.IdProfesor;
            }
            catch (Exception)
            {
                throw;
            }
            throw new NotImplementedException();
        }
        public bool EliminarProfesor(int idProfesor)
        {
            try
            {
                //Obtener el indice del Objeto para Eliminar 
                int indice = lstProfesor.FindIndex(tmp => tmp.IdProfesor == idProfesor);

                //procedemos a eliminar el registro
                lstProfesor.RemoveAt(indice);

                return true;


            }
            catch (Exception)
            {
                throw;
            }
            throw new NotImplementedException();
        }
        public Profesor ObtenerProfesorPorID(int idProfesor)
        {
            try
            {

                Profesor profesor = lstProfesor.FirstOrDefault(tmp => tmp.IdProfesor == idProfesor);

                return profesor;


            }
            catch (Exception)
            {
                throw;
            }
            throw new NotImplementedException();
        }
        public List<Profesor> ObtenerTodosLosProfesores()
        {
            try
            {
                return lstProfesor;
            }
            catch (Exception)
            {
                throw;
            }
            throw new NotImplementedException();
        }
    }

}
