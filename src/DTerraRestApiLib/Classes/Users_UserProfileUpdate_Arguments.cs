using System;
using System.Collections.Generic;
using System.Text;

namespace DocTerraRestApiLib.Classes
{
    /// <summary>
    /// Описание параметров для обновления профиля пользователя
    /// </summary>
    public class Users_UserProfileUpdate_Arguments
    {
        public string? email { get; set; }
        public string? userRole { get; set; }
        public bool? isEnabled { get; set; }
        public string? updatedFields { get; internal set; }

        public string ToJson()
        {
            return System.Text.Json.JsonSerializer.Serialize(this, typeof(Users_UserProfileUpdate_Arguments), CommonData.p_JsonSerializerOptions_Write);
        }
    }
}
