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

        public DTerra_Connection(string API_Link, string Login, string Password)
        {
            this.p_API_Link = API_Link;
            this.p_Login = Login;
            this.p_Password = Password;
        }
#if DEBUG
        public DTerra_Connection()
        {
            string projectPath = Path.Combine(new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.FullName ?? "", "dterra_reg.txt");
            if (!File.Exists(projectPath)) throw new FileNotFoundException("Reg Data project not exists in library's project folder!");

            string[] regData = System.IO.File.ReadAllLines(projectPath);
            p_API_Link = regData[0];
            p_Login = regData[1];
            p_Password = regData[2];
        }

#endif

        public async Task<DTerra_Task> CreateRequest(ConnectType c_type, string Address, string command)
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
                if (c_type == ConnectType.POST) _r = await client.ExecutePostAsync(request);
                else if (c_type == ConnectType.PATCH) _r = await client.ExecutePatchAsync(request);
                else if (c_type == ConnectType.GET) _r = await client.ExecuteGetAsync(request);
                else if (c_type == ConnectType.DEL) _r = await client.ExecuteDeleteAsync(request);
                else if (c_type == ConnectType.HEAD) _r = await client.ExecuteHeadAsync(request);
            }
            catch (Exception e)
            {
                //DTerra_Error? errorHandler = DTerra_Error.LoadFrom(e.Message);
                Console.Out.WriteLine("-----------------");
                Console.Out.WriteLine(e.Message);
            }
            return new DTerra_Task(_r);
        }
    }
}
