using System;
using System.Collections.Generic;
using System.Text;

namespace DocTerraRestApiLib.Classes
{
    internal class Pages_Deleting_Arguments
    {
        public string[]? ids { get; set; }  
        public Pages_Deleting_Arguments(string[] topics)
        {
            this.ids = topics;
        }

        public string ToJson()
        {
            return System.Text.Json.JsonSerializer.Serialize(this, typeof(Pages_Deleting_Arguments), CommonData.p_JsonSerializerOptions_Write);
        }
    }
}
