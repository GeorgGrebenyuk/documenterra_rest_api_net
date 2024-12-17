using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace DocTerraRestApiLib.Classes
{
    /// <summary>
    /// Описание элемента дерева страниц (TOC -- Table of content)
    /// </summary>
    public class TOC_Element_Info
    {
        public string? caption { get; set; }

        public string? id { get; set; }

        public bool? isShowInToc { get; set; }

        public int? ordinalNo { get; set; }

        public string? parentId { get; set; }

        public string? topicId { get; set; }

        public static TOC_Element_Info? LoadFrom(string json)
        {
            return (TOC_Element_Info?)JsonSerializer.Deserialize(json,
                             typeof(TOC_Element_Info), CommonData.p_JsonSerializerOptions_Read);
        }
    }
}
