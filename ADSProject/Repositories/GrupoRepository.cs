using ADSProject.DB;
using ADSProject.Interfaces;
using ADSProject.Migrations;
using ADSProject.Models;

namespace ADSProject.Repositories
{
    public class GrupoRepository : IGrupo

    {
        /*private List<Grupo> lstGrupo = new List<Grupo>
        {
            new Grupo{IdGrupo = 1, IdCarrera = 1, IdMateria = 1,
            IdProfesor = 1, Ciclo = 01, 
            Anio = 2024}
        };*/

        private readonly ApplicationDbContext applicationDbContext;

        public GrupoRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public int ActualizarGrupo(int idGrupo, Grupo grupo)
        {
            try
            {
                //Obtener el indice del Objeto para actualizar 
                /* int indice = lstGrupo.FindIndex(tmp => tmp.IdGrupo == idGrupo );

                 //procedemos con la actualizacion
                 lstGrupo[indice] = grupo;*/

                var item = applicationDbContext.Grupos.SingleOrDefault(x => x.IdGrupo == idGrupo);

                applicationDbContext.Entry(item).CurrentValues.SetValues(grupo);

                applicationDbContext.SaveChanges();

                return idGrupo;
            }
            catch (Exception)
            {
                throw;
            }
            //throw new NotImplementedException();
        }
        public int AgregarGrupo(Grupo grupo)
        {
            try
            {
                //validar si existen datos en la lista, debe se asi, tomaremos el ultimo ID
                // y lo incrementamos en una unidad 
                /*if (lstGrupo.Count > 0)
                {
                    grupo.IdGrupo = lstGrupo.Last().IdGrupo + 1;
                }
                lstGrupo.Add(grupo);*/

                applicationDbContext.Grupos.Add(grupo);
                applicationDbContext.SaveChanges();

                return grupo.IdGrupo;
            }
            catch (Exception)
            {
                throw;
            }
           // throw new NotImplementedException();
        }
        public bool EliminarGrupo(int idGrupo)
        {
            try
            {
                //Obtener el indice del Objeto para Eliminar 
                /* int indice = lstGrupo.FindIndex(tmp => tmp.IdGrupo == idGrupo);

                 //procedemos a eliminar el registro
                 lstGrupo.RemoveAt(indice);*/

                var item = applicationDbContext.Grupos.SingleOrDefault(x => x.IdGrupo == idGrupo);

                applicationDbContext.Grupos.Remove(item);
                applicationDbContext.SaveChanges();

                return true;

            }
            catch (Exception)
            {
                throw;
            }
           // throw new NotImplementedException();
        }
        public Grupo ObtenerGrupoPorID(int idGrupo)
        {
            try
            {

                // Grupo grupo = lstGrupo.FirstOrDefault(tmp => tmp.IdGrupo == idGrupo);

                var grupo = applicationDbContext.Grupos.SingleOrDefault(x => x.IdGrupo == idGrupo);

                return grupo;
            }
            catch (Exception)
            {
                throw;
            }
            //throw new NotImplementedException();
        }
        public List<Grupo> ObtenerTodosLosGrupos()
        {
            try
            {
                // return lstGrupo;
                return applicationDbContext.Grupos.ToList();
            }
            catch (Exception)
            {
                throw;
            }
           // throw new NotImplementedException();
        }
    }
}
