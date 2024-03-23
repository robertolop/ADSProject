using ADSProject.Interfaces;
using ADSProject.Models;

namespace ADSProject.Repositories
{
    public class CarreraRepository : ICarrera
    {

        private List<Carrera> lstCarrera = new List<Carrera>
        {
        new Carrera{Id = 1, Codigo = "PS24I04002",
        Nombre = "Ingenieria En Sistemas"}
        };
        public int ActualizarCarrera(int id, Carrera carrera)
        {
            try
            {
                //Obtener el indice del Objeto para actualizar 
                int indice = lstCarrera.FindIndex(tmp => tmp.Id == id);

                //procedemos con la actualizacion
                lstCarrera[indice] = carrera;

                return id;
            }
            catch (Exception)
            {
                throw;
            }
            throw new NotImplementedException();
        }
        public int AgregarCarrera(Carrera carrera)
        {
            try
            {
                //validar si existen datos en la lista, debe se asi, tomaremos el ultimo ID
                // y lo incrementamos en una unidad 
                if (lstCarrera.Count > 0)
                {
                    carrera.Id = lstCarrera.Last().Id + 1;
                }
                lstCarrera.Add(carrera);
                return carrera.Id;
            }
            catch (Exception)
            {
                throw;
            }
            throw new NotImplementedException();
        }
        public bool EliminarCarrrera(int id)
        {
            try
            {
                //Obtener el indice del Objeto para Eliminar 
                int indice = lstCarrera.FindIndex(tmp => tmp.Id == id);

                //procedemos a eliminar el registro
                lstCarrera.RemoveAt(indice);

                return true;


            }
            catch (Exception)
            {
                throw;
            }
            throw new NotImplementedException();
        }
        public Carrera ObtenerCarreraPorID(int id)
        {
            try
            {
                //Buscamos y asignamos el objeto estudiante
                Carrera carrera = lstCarrera.FirstOrDefault(tmp => tmp.Id == id);

                return carrera;


            }
            catch (Exception)
            {
                throw;
            }
            throw new NotImplementedException();
        }
        public List<Carrera> ObtenerTodasLasCarreras()
        {
            try
            {
                return lstCarrera;
            }
            catch (Exception)
            {
                throw;
            }
            throw new NotImplementedException();
        }
    }
}
