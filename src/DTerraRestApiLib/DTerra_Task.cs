using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DocTerraRestApiLib
{
    /// <summary>
    /// Вспомогательный класс для описания задания для Документерра Rest API
    /// </summary>
    public class DTerra_Task
    {
        private RestSharp.RestResponse _r;
        public string Response { get { return this._r.Content ?? ""; } }

        public System.Net.HttpStatusCode StatusCode { get { return this._r.StatusCode; } }

        public DTerra_Task(RestSharp.RestResponse r)
        {
            _r = r;
        }
    }
}
