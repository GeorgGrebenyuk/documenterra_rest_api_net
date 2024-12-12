using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace DocTerraRestApiLib.Classes
{
    /// <summary>
    /// Описание токена для авторизованного пользователя
    /// </summary>
    public class Users_UserTolen_Info
    {
        public DateTime? expirationDate { get; set; }

        public string? token { get; set; }

        public string? userName { get; set; }

        public bool? isMultiUse { get; set; }

        public static Users_UserTolen_Info? LoadFrom(string json)
        {
            return (Users_UserTolen_Info?)JsonSerializer.Deserialize(json,
                             typeof(Users_UserTolen_Info), CommonData.p_JsonSerializerOptions_Read);
        }
    }
}
