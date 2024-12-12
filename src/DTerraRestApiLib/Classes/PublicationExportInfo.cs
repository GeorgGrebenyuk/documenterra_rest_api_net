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
    public class PublicationExportInfo
    {
        /// <summary>
        /// Описание конфигурации ФТП-сервера для загрузки на него результатов публикации
        /// </summary>
        public class FtpInfo
        {
            public string? hostName { get; set; }
            public string? userName { get; set; }
            public string? password { get; set; }
            public bool? isUsePassiveMode { get; set; }
            public int? port { get; set; }

        }
        [JsonIgnore]
        public PublicationFormatVariant format0 { get; set; }

        public string? format { get { return format0.ToString(); } }

        public string? outputFileName { get; set; }

        public string? exportPresetName { get; set; }

        public FtpInfo? ftpInfo { get; set; }

        public string ToJson()
        {
            return System.Text.Json.JsonSerializer.Serialize(this, typeof(PublicationExportInfo), CommonData.p_JsonSerializerOptions_Write);
        }
    }
}
