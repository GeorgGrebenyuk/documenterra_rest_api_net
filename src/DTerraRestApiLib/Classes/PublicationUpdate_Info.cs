using DTerraRestApiLib.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTerraRestApiLib.Classes
{
    /// <summary>
    /// Описание параметров обновления публикации
    /// </summary>
    public class PublicationUpdate_Info
    {
        public string updatedPubId { get; set; }

        public string pubName { get; set; }

        [JsonIgnore]
        public UpdateModeVariant updateMode0 { get; set; } = UpdateModeVariant.FullReplace;

        public string updateMode { get { return updateMode0.ToString(); } }

        public bool isReplacePubScripts { get; set; } = false;

        public bool isReplacePubStyles { get; set; } = false;

        public bool isPublishOnlyReadyTopics { get; set; } = false;

        public string[] outputTags { get; set; } = new string[] { };

        [JsonIgnore]
        public PublicationVisibilityVariant pubVisibility0 { get; set; } = PublicationVisibilityVariant.Private;
        public string pubVisibility { get { return pubVisibility0.ToString(); } }

        public string[] publishedTocNodeIds { get; set; } = new string[] { };

        public PublicationUpdate_Info(string updatedPubId, string pubName, UpdateModeVariant updateMode0)
        {
            this.updatedPubId = updatedPubId;
            this.pubName = pubName;
            this.updateMode0 = updateMode0;
        }

        public string ToJson()
        {
            if (updateMode0 == UpdateModeVariant.FullReplace)
            {
                isReplacePubScripts = false;
                isReplacePubStyles = false;
            }
            return System.Text.Json.JsonSerializer.Serialize(this, typeof(PublicationUpdate_Info), CommonData.p_JsonSerializerOptions_Write);
        }
    }
}
