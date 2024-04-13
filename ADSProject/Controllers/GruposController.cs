﻿using ADSProject.Interfaces;
using ADSProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ADSProject.Controllers
{
    [Route("api/grupo/")]
    public class GruposController : ControllerBase
    {
        private readonly IGrupo grupo;
        private const string COD_EXITO = "000000";
        private const string COD_ERROR = "999999";
        private string pCodRespuesta;
        private string pMensajeUsuario;
        private string pMensajeTecnico;

        public GruposController(IGrupo grupo)
        {
            this.grupo = grupo;
        }



        [HttpPost("AgregarGrupo")]

        public ActionResult<string> AgregarGrupo([FromBody] Grupo grupo)
        {
            try
            {
                //verificar que todas las validaciones por atributo del modelo este correcto.
                if (!ModelState.IsValid)
                {
                    // En caso de no cumplir con todas las validaciones se procede a retonar una respuesta erronea.
                    return BadRequest(ModelState);
                }
                int contador = this.grupo.AgregarGrupo(grupo);
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
        [HttpPost("ActualizarGrupo/{idGrupo}")]
        public ActionResult<string> ActualizarGrupo(int idGrupo, [FromBody] Grupo grupo)
        {
            try
            {
                //verificar que todas las validaciones por atributo del modelo este correcto.
                if (!ModelState.IsValid)
                {
                    // En caso de no cumplir con todas las validaciones se procede a retonar una respuesta erronea.
                    return BadRequest(ModelState);
                }
                int contador = this.grupo.ActualizarGrupo(idGrupo, grupo);
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
        [HttpDelete("EliminarGrupo/{idGrupo}")]
        public ActionResult<string> EliminarGrupo(int idGrupo)
        {
            try
            {
                bool eliminado = this.grupo.EliminarGrupo(idGrupo);

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
        [HttpGet("obtenerGrupoPorID/{idGrupo}")]
        public ActionResult<Estudiante> ObtenerGrupoPorID(int idGrupo)
        {
            try
            {
                Grupo grupo = this.grupo.ObtenerGrupoPorID(idGrupo);

                if (grupo != null)
                {
                    return Ok(grupo);
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "No se encontraron datos del Grupo";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                return NotFound(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("obtenerTodosLosGrupos")]
        public ActionResult<List<Grupo>> ObtenerTodosLosGrupos()
        {
            try
            {
                List<Grupo> lstGrupo = this.grupo.ObtenerTodosLosGrupos();

                return Ok(lstGrupo);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
