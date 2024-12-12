using System;
using System.Collections.Generic;
using System.Text;

namespace DocTerraRestApiLib.Classes
{
    internal class TOC_ElementsDelete_Arguments
    {
        public string[]? tocNodeIds { get; set; }

        public TOC_ElementsDelete_Arguments(string[] paths)
        {
            tocNodeIds = paths;
        }

        public string ToJson()
        {
            return System.Text.Json.JsonSerializer.Serialize(this, typeof(TOC_ElementsDelete_Arguments), CommonData.p_JsonSerializerOptions_Write);
        }
    }
}
