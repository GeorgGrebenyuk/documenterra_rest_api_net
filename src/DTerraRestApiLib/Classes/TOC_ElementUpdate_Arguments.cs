using System;
using System.Collections.Generic;
using System.Text;

namespace DocTerraRestApiLib.Classes
{
    public class TOC_ElementUpdate_Arguments
    {
        public string? caption { get; set; }

        public bool? isShowInToc { get; set; } = false;

        public int? ordinalNo { get; set; }

        public string? parentId { get; set; } = null;

        public string? updatedFields { get; internal set; }

        public string ToJson()
        {
            return System.Text.Json.JsonSerializer.Serialize(this, typeof(TOC_ElementUpdate_Arguments), CommonData.p_JsonSerializerOptions_Write);
        }
    }
}
