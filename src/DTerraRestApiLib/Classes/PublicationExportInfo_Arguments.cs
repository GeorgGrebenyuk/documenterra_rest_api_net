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
    /// Описание параметров для экспорта публикации
    /// </summary>
    public class PublicationExportInfo_Arguments
    {
        /// <summary>
        /// Описание конфигурации ФТП-сервера для загрузки на него результатов публикации
        /// </summary>
        public class FtpInfo
        {
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public string? hostName { get; set; }

            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public string? userName { get; set; }

            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public string? password { get; set; }

            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public bool? isUsePassiveMode { get; set; }

            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public int? port { get; set; }

        }
        [JsonIgnore]
        public PublicationFormatVariant? format0 { get; set; }

        public string? format { get { return format0?.ToString() ?? null; } }

        public string? outputFileName { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? exportPresetName { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public FtpInfo? ftpInfo { get; set; }

        public string ToJson()
        {
            return System.Text.Json.JsonSerializer.Serialize(this, typeof(PublicationExportInfo_Arguments), CommonData.p_JsonSerializerOptions_Write);
        }
    }
}
