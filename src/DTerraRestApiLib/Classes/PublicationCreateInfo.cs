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
    public class PublicationCreateInfo
    {
        public string? pubId { get; set; }

        public string? pubName { get; set; }

        public bool? isPublishOnlyReadyTopics { get; set; }

        public string[]? outputTags { get; set; }

        [JsonIgnore]
        public PublicationVisibilityVariant pubVisibility0 { get; set; } = PublicationVisibilityVariant.Private;
        public string? pubVisibility { get { return pubVisibility0.ToString(); } }

        public string[]? publishedTocNodeIds { get; set; }

        public PublicationCreateInfo(string pubId, string pubName)
        {
            this.pubId = pubId;
            this.pubName = pubName;
        }

        public string ToJson()
        {
            return System.Text.Json.JsonSerializer.Serialize(this, typeof(PublicationCreateInfo), CommonData.p_JsonSerializerOptions_Write);
        }
    }
}
