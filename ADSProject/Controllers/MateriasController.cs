using ADSProject.Interfaces;
using ADSProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ADSProject.Controllers
{
        [Route("api/materia/")]
    public class MateriasController : ControllerBase
        {
        private readonly IMateria materia;
        private const string COD_EXITO = "000000";
        private const string COD_ERROR = "999999";
        private string pCodRespuesta;
        private string pMensajeUsuario;
        private string pMensajeTecnico;

        public MateriasController(IMateria materia)
        {
            this.materia = materia;
        }



        [HttpPost("AgregarMateria")]

        public ActionResult<string> AgregarMateria([FromBody] Materia materia)
        {
            try
            {
                //verificar que todas las validaciones por atributo del modelo este correcto.
                if (!ModelState.IsValid)
                {
                    // En caso de no cumplir con todas las validaciones se procede a retonar una respuesta erronea.
                    return BadRequest(ModelState);
                }
                int contador = this.materia.AgregarMateria(materia);
                if (contador > 0)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro insertado con exito";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrio un problema al insertar el registro";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost("actualizarMateria/{idMateria}")]
        public ActionResult<string> ActualizarMateria(int idMateria, [FromBody] Materia materia)
        {
            try
            {
                //verificar que todas las validaciones por atributo del modelo este correcto.
                if (!ModelState.IsValid)
                {
                    // En caso de no cumplir con todas las validaciones se procede a retonar una respuesta erronea.
                    return BadRequest(ModelState);
                }
                int contador = this.materia.ActualizarMateria(idMateria, materia);
                if (contador > 0)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro actualizado con exito";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrio un problema al actualizar el registro";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpDelete("eliminarMateria/{idMateria}")]
        public ActionResult<string> EliminarMateria(int idMateria)
        {
            try
            {
                bool eliminado = this.materia.EliminarMateria(idMateria);

                if (eliminado)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro eliminado con exito";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrio un problema al eliminar el registro";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("obtenerMateriaPorID/{idMateria}")]
        public ActionResult<Materia> ObtenerMateriaPorID(int idMateria)
        {
            try
            {
                Materia materia = this.materia.ObtenerMateriaPorID(idMateria);

                if (materia != null)
                {
                    return Ok(materia);
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "No se encontraron datos de la materia";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                return NotFound(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("ObtenerMateria")]
        public ActionResult<List<Materia>> ObtenerTodosLasMaterias()
        {
            try
            {
                List<Materia> lstMaterias = this.materia.ObtenerTodosLasMaterias();

                return Ok(lstMaterias);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
