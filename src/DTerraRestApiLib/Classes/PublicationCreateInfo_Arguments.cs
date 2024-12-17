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
    public class PublicationCreateInfo_Arguments
    {
        public string? pubId { get; set; }

        public string? pubName { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? isPublishOnlyReadyTopics { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string[]? outputTags { get; set; }

        [JsonIgnore]
        public PublicationVisibilityVariant? pubVisibility0 { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? pubVisibility { get { return pubVisibility0?.ToString() ?? null; } }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string[]? publishedTocNodeIds { get; set; }

        public PublicationCreateInfo_Arguments(string pubId, string pubName)
        {
            this.pubId = pubId;
            this.pubName = pubName;
        }

        public string ToJson()
        {
            return System.Text.Json.JsonSerializer.Serialize(this, typeof(PublicationCreateInfo_Arguments), CommonData.p_JsonSerializerOptions_Write);
        }
    }
}
