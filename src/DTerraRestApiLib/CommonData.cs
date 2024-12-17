using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocTerraRestApiLib
{
    internal class CommonData
    {
        public static System.Text.Json.JsonSerializerOptions p_JsonSerializerOptions_Write
        {
            get
            {
                return new System.Text.Json.JsonSerializerOptions
                {
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(System.Text.Unicode.UnicodeRanges.BasicLatin, System.Text.Unicode.UnicodeRanges.Cyrillic),
                    WriteIndented = true,
                };
            }
        }

        public static System.Text.Json.JsonSerializerOptions p_JsonSerializerOptions_Read
        {
            get
            {
                return new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
            }
        }
    }
}
