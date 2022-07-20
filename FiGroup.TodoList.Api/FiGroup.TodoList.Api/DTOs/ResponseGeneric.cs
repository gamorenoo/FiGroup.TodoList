using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiGroup.TodoList.Api.DTOs
{
    public sealed class ResponseGeneric<T>
    {
        public bool Ok { get; set; }
        /// <summary>
        /// Peticion fallida
        /// </summary>
        public bool Error { get; set; }
        /// <summary>
        /// Mensaje de error
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Objeto con la respuesta
        /// </summary>
        public T Result { get; set; }

        /// <summary>
        /// Crea un resultado de petición con error
        /// </summary>
        /// <param name="mensajeError">Mensaje del error ocurrido</param>
        /// <returns> Resultado de la petición</returns>
        public static ResponseGeneric<T> CreateResponseError(string ErrorMessage)
        {
            ResponseGeneric<T> response = new ResponseGeneric<T>();
            return new ResponseGeneric<T>()
            {
                Error = true,
                Ok = false,
                ErrorMessage = ErrorMessage,
                Result = default(T)
            };
        }

        /// <summary>
        /// Crea un resultado de petición exitoso
        /// </summary>
        /// <param name="result">Objeto o lista de onjetos de la rspuesta</param>
        /// <param name="CodigoHttp">Código Http de respuestas satisfactoria</param>
        /// <returns> Resultado de la petición</returns>
        public static ResponseGeneric<T> CreateResponseOk(T result)
        {
            ResponseGeneric<T> response = new ResponseGeneric<T>();
            return new ResponseGeneric<T>()
            {
                Error = false,
                Ok = true,
                ErrorMessage = null,
                Result = result
            };
        }

    }
}
