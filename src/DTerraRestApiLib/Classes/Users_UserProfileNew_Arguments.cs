using System;
using System.Collections.Generic;
using System.Text;

namespace DocTerraRestApiLib.Classes
{
    /// <summary>
    /// Вспомогательный класс для определения профиля пользователя (создание профиля)
    /// </summary>
    public class Users_UserProfileNew_Arguments
    {
        public class userInfo_Definition
        {
            public string? email { get; set; }

            public string? firstName { get; set; }

            public string? middleName { get; set; }

            public string? lastName { get; set; }
        }

        public string? userName { get; set; }

        public userInfo_Definition? userInfo { get; set; }

        public string[]? userRoles { get; set; }
        public string? userRole { get { return string.Join(",", userRoles ?? new string[] { }); } }

        public bool? isDontSendEmail { get; set; }

        public string ToJson()
        {
            return System.Text.Json.JsonSerializer.Serialize(this, typeof(Users_UserProfileNew_Arguments), CommonData.p_JsonSerializerOptions_Write);
        }
    }
}
