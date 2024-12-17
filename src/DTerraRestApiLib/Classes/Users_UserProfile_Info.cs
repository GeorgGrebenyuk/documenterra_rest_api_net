using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace DocTerraRestApiLib.Classes
{
    public class Users_UserProfile_Info
    {
        public class userInfo_Definition
        {
            public string? about { get; set; }

            public string? avatarImageUrl { get; set; }

            public string? cultureInfoId { get; set; }

            public string? email { get; set; }

            public string? firstName { get; set; }

            public bool? isAutoDetectCultureInfo { get; set; }

            public bool? isAutoDetectTimeZone { get; set; }

            public DateTime? lastActivityDate { get; set; }

            public string? lastName { get; set; }

            public string? middleName { get; set; }

            public string? timeZoneId { get; set; }
        }

        public userInfo_Definition? userInfo { get; set; }

        public string? userName { get; set; }

        public string? userRole { get; set; }

        public bool? isEnabled { get; set; }

        public static Users_UserProfile_Info? LoadFrom(string json)
        {
            return (Users_UserProfile_Info?)JsonSerializer.Deserialize(json,
                             typeof(Users_UserProfile_Info), CommonData.p_JsonSerializerOptions_Read);
        }
    }
}
