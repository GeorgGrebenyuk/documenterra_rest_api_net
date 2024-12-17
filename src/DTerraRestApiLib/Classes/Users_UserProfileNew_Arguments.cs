using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

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

            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public string? firstName { get; set; }

            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public string? middleName { get; set; }

            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public string? lastName { get; set; }
        }

        public string? userName { get; set; }

        public userInfo_Definition? userInfo { get; set; }

        [JsonIgnore]
        public string[]? userRoles { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? userRole { get { return string.Join(",", userRoles ?? new string[] { }); } }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? isDontSendEmail { get; set; }

        public string ToJson()
        {
            return System.Text.Json.JsonSerializer.Serialize(this, typeof(Users_UserProfileNew_Arguments), CommonData.p_JsonSerializerOptions_Write);
        }
    }
}
