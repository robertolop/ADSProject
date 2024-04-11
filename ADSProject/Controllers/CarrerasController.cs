using ADSProject.Interfaces;
using ADSProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ADSProject.Controllers
{
    
        [Route("api/carreras/")]
        public class CarrerasController : ControllerBase
        {
            private readonly ICarrera carrera;
            private const string COD_EXITO = "000000";  
            private const string COD_ERROR = "999999";
            private string pCodRespuesta;
            private string pMensajeUsuario;
            private string pMensajeTecnico;

            public CarrerasController(ICarrera carrera )
            {
                this.carrera = carrera;
            }



            [HttpPost("AgregarCarrera")]

            public ActionResult<string> AgregarCarrera([FromBody] Carrera carrera)
            {
                try
                {
                //verificar que todas las validaciones por atributo del modelo este correcto.
                if (!ModelState.IsValid)
                {
                    // En caso de no cumplir con todas las validaciones se procede a retonar una respuesta erronea.
                    return BadRequest(ModelState);
                }

                int contador = this.carrera.AgregarCarrera(carrera);
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
            [HttpPost("ActualizarCarrera/{id}")]
            public ActionResult<string> ActualizarCarrera(int id, [FromBody] Carrera carrera)
            {
                try
                {
                //verificar que todas las validaciones por atributo del modelo este correcto.
                if (!ModelState.IsValid)
                {
                    // En caso de no cumplir con todas las validaciones se procede a retonar una respuesta erronea.
                    return BadRequest(ModelState);
                }
                int contador = this.carrera.ActualizarCarrera(id, carrera);
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
            [HttpDelete("EliminarCarrrera/{id}")]
            public ActionResult<string> EliminarCarrrera(int id)
            {
                try
                {
                    bool eliminado = this.carrera.EliminarCarrrera(id);

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
            [HttpGet("ObtenerCarreraPorID/{id}")]
            public ActionResult<Estudiante> ObtenerCarreraPorID(int id)
            {
                try
                {
                    Carrera carrera = this.carrera.ObtenerCarreraPorID(id);

                    if (carrera != null)
                    {
                        return Ok(carrera);
                    }
                    else
                    {
                        pCodRespuesta = COD_ERROR;
                        pMensajeUsuario = "No se encontraron datos de la carrera";
                        pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                    }
                    return NotFound(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
                }
                catch (Exception)
                {

                    throw;
                }
            }
            [HttpGet("ObtenerTodasLasCarreras")]
            public ActionResult<List<Carrera>> ObtenerTodasLasCarreras()
            {
                try
                {
                    List<Carrera> lstCarrera = this.carrera.ObtenerTodasLasCarreras();

                    return Ok(lstCarrera);
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }
    
}
