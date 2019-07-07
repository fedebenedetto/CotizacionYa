using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class VariablesGlobales
    {
        #region manejo de swal

        /// <summary>
        /// setea nombre del swal error
        /// </summary>
        /// <returns></returns>
        public string SwalError()
        {
            return "error";
        }

        /// <summary>
        /// setea nombre del swal succes
        /// </summary>
        /// <returns></returns>
        public string SwalSuccess()
        {
            return "success";
        }


        /// <summary>
        /// setea nombre del swal info
        /// </summary>
        /// <returns></returns>
        public string SwalInfo()
        {
            return "info";
        }
        #endregion
    }
}
