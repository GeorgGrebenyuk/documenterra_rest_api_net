using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Threading;

namespace DocTerraRestApiLib
{
    public class DTerra_Connection
    {
        private string p_API_Link;
        private string p_Login;
        private string p_Password;


        public enum ConnectType : int
        {
            //TODO new types?
            GET = 1,
            POST = 4,
            PATCH = 8,
            DEL = 16,
            HEAD = 32
        }

        //private DTerra_Connection() { }

        public DTerra_Connection(string API_Link, string Login, string Password)
        {
            this.p_API_Link = API_Link;
            this.p_Login = Login;
            this.p_Password = Password;
        }

        public DTerra_Connection(string filePath)
        {
            if (!File.Exists(filePath)) throw new FileNotFoundException("File wan not found by path " + filePath);

            string[] regData = System.IO.File.ReadAllLines(filePath);

            this.p_API_Link = regData[0];
            this.p_Login = regData[1];
            this.p_Password = regData[2];
        }

        //async Task<DTerra_Task>
        public DTerra_Task CreateRequest(ConnectType c_type, string Address, string command)
        {
            //response = "";
            var client = new RestClient(p_API_Link);
            var request = new RestRequest(Address);

            string encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
                                       .GetBytes(p_Login + ":" + p_Password));
            request.AddHeader("Authorization", "Basic " + encoded);

            if (command != "")
            {
                request.AddBody(command, ContentType.Json);
            }

            RestResponse _r = new RestResponse();

            try
            {
                //if (c_type == ConnectType.POST) _r = await client.ExecutePostAsync(request);
                //else if (c_type == ConnectType.PATCH) _r = await client.ExecutePatchAsync(request);
                //else if (c_type == ConnectType.GET) _r = await client.ExecuteGetAsync(request);
                //else if (c_type == ConnectType.DEL) _r = await client.ExecuteDeleteAsync(request);
                //else if (c_type == ConnectType.HEAD) _r = await client.ExecuteHeadAsync(request);

                if (c_type == ConnectType.POST) _r = client.Post(request);
                else if (c_type == ConnectType.PATCH) _r = client.Patch(request);
                else if (c_type == ConnectType.GET) _r = client.Get(request);
                else if (c_type == ConnectType.DEL) _r = client.Delete(request);
                else if (c_type == ConnectType.HEAD) _r = client.Head(request);
            }
            catch (Exception e)
            {
                //TODO: DTerra_Error? errorHandler = DTerra_Error.LoadFrom(e.Message);
                Console.Out.WriteLine("-----------------");
                Console.Out.WriteLine(e.Message);
            }
            return new DTerra_Task(_r);
        }
    }
}
