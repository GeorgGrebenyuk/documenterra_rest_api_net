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
    /// Описание структуры проекта для публикации
    /// </summary>
    public class PublicationCreate_Info
    {
        public string pubId { get; set; }

        public string pubName { get; set; }

        public bool isPublishOnlyReadyTopics { get; set; } = false;

        public string[] outputTags { get; set; } = new string[] { };

        [JsonIgnore]
        public PublicationVisibilityVariant pubVisibility0 { get; set; } = PublicationVisibilityVariant.Private;
        public string pubVisibility { get { return pubVisibility0.ToString(); } }

        public string[] publishedTocNodeIds { get; set; } = new string[] { };

        public PublicationCreate_Info(string pubId, string pubName)
        {
            this.pubId = pubId;
            this.pubName = pubName;
        }

        public string ToJson()
        {
            return System.Text.Json.JsonSerializer.Serialize(this, typeof(PublicationCreate_Info), CommonData.p_JsonSerializerOptions_Write);
        }
    }
}
