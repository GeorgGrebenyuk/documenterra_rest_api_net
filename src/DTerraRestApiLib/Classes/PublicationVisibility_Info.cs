using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DocTerraRestApiLib.Enumerations;

namespace DocTerraRestApiLib.Classes
{
    /// <summary>
    /// Вспомогательный класс для задания видимости публикации
    /// </summary>
    public class PublicationVisibility_Info
    {
        public string updatedFields { get; set; }

        [JsonIgnore]
        public PublicationVisibilityVariant visibility0 { get; set; }

        public PublicationVisibility_Info(PublicationVisibilityVariant visibility0)
        {
            updatedFields = "visibility";
            this.visibility0 = visibility0;
        }

        public string visibility { get { return visibility0.ToString(); } }

        public string ToJson()
        {
            return System.Text.Json.JsonSerializer.Serialize(this, typeof(PublicationVisibility_Info), CommonData.p_JsonSerializerOptions_Write);
        }
    }
}
