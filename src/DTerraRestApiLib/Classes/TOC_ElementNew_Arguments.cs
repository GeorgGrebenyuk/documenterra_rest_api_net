﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DocTerraRestApiLib.Classes
{
    /// <summary>
    /// Вспомогательный класс для описания нового элемента Дерева страниц
    /// </summary>
    public class TOC_ElementNew_Arguments
    {
        public string? caption { get; set; }

        [JsonPropertyName("isShowInToc")]
        public bool? ShowFolderIcon { get; set; } = false;

        public int? ordinalNo { get; set; } = -1; //TODO: проверить, дейстует ли это как по-умолчанию (не учитывать)

        public string? parentId { get; set; } = null;

        public string ToJson()
        {
            return System.Text.Json.JsonSerializer.Serialize(this, typeof(TOC_ElementNew_Arguments), CommonData.p_JsonSerializerOptions_Write);
        }
    }
}
