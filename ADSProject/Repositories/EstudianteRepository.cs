using ADSProject.DB;
using ADSProject.Interfaces;
using ADSProject.Models;

namespace ADSProject.Repositories
{
    public class EstudianteRepository : IEstudiante
    {
        /*private List<Estudiante> lstEstudiantes = new List<Estudiante>
        {
        new Estudiante{IdEstudiante = 1, NombresEstudiante = "JUAN CARLOS",
        ApellidosEstudiante = "PEREZ SOSA", CodigoEstudiante ="PS24I04002",
        CorreoEstudiante = "PS24I04002@usonsonate.edu.sv"}
        };*/

        private readonly ApplicationDbContext applicationDbContext;
        
        public EstudianteRepository(ApplicationDbContext applicationDbContext) 
        {
        this.applicationDbContext = applicationDbContext;
        }

        public int ActualizarEstudiante(int idEstudiante, Estudiante estudiante)
        {
            try
            {
                //Obtener el indice del Objeto para actualizar 
                //int indice = lstEstudiantes.FindIndex(tmp => tmp.IdEstudiante == idEstudiante);

                //procedemos con la actualizacion
               //lstEstudiantes[indice] = estudiante;

                var item = applicationDbContext.Estudiantes.SingleOrDefault(x => x.IdEstudiante == idEstudiante);

                applicationDbContext.Entry(item).CurrentValues.SetValues(estudiante);

                applicationDbContext.SaveChanges();

                return idEstudiante;
            }
            catch (Exception)
            {
                throw;
            }
            //throw new NotImplementedException();
        }
        public int AgregarEstudiante( Estudiante estudiante)
        {
            try
            {
                //validar si existen datos en la lista, debe se asi, tomaremos el ultimo ID
                // y lo incrementamos en una unidad 
                /*if(lstEstudiantes.Count > 0)
                {
                    estudiante.IdEstudiante = lstEstudiantes.Last().IdEstudiante + 1;
                }
                lstEstudiantes.Add(estudiante);*/

                applicationDbContext.Estudiantes.Add(estudiante);
                applicationDbContext.SaveChanges();

                return estudiante.IdEstudiante;
            }
            catch(Exception)
            {
                throw;
            }
            //throw new NotImplementedException();
        }
        public bool EliminarEstudiante(int idEstudiante)
        {
            try
            {
                //Obtener el indice del Objeto para Eliminar 
               /* int indice = lstEstudiantes.FindIndex(tmp => tmp.IdEstudiante == idEstudiante);

                //procedemos a eliminar el registro
                lstEstudiantes.RemoveAt(indice);*/

                var item = applicationDbContext.Estudiantes.SingleOrDefault(x => x.IdEstudiante == idEstudiante);

                applicationDbContext.Estudiantes.Remove(item);
                applicationDbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
           //throw new NotImplementedException();
        }
        public Estudiante ObtenerEstudiantePorID(int idEstudiante)
        {
            try
            {
                //Buscamos y asignamos el objeto estudiante
                // Estudiante estudiante = lstEstudiantes.FirstOrDefault(tmp => tmp.IdEstudiante == idEstudiante);

                var estudiante = applicationDbContext.Estudiantes.SingleOrDefault(x => x.IdEstudiante == idEstudiante);

                return estudiante;


            }
            catch (Exception)
            {
                throw;
            }
            //throw new NotImplementedException();
        }
        public List<Estudiante> ObtenerTodosLosEstudiantes()
        {
            try
            {
               // return lstEstudiantes;
               return applicationDbContext.Estudiantes.ToList();
            }
            catch (Exception)
            {
                throw;
            }
           // throw new NotImplementedException();
        }
    }
}
