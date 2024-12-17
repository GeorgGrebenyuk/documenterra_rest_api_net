using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace DocTerraRestApiLib.Classes
{
    /// <summary>
    /// Описание структуры страницы
    /// </summary>
    public class Pages_Page_Info
    {
        public string? assigneeUserName { get; set; }

        public string? body { get; set; }

        public DateTime? createdOn { get; set; }

        public string? ftsSnippetHtml { get; set; }

        public string? ftsTitleHtml { get; set; }

        public string? fullUrl { get; set; }

        public string? html { get; set; }

        public string? id { get; set; }

        public string[]? indexKeywords { get; set; }

        //public string[]? indexKeywords0 { 
        //    get {
        //        if (indexKeywords == null) return null;
        //        if (indexKeywords.Contains(",")) return indexKeywords.Split(',');
        //        else return new string[] { indexKeywords };
        //    } 
        //}

        public DateTime? modifiedOn { get; set; }

        public string? ownerUserName { get; set; }

        public string? projectId { get; set; }

        public string? projectTitle { get; set; }

        [Obsolete]
        public string? projectUrl { get; set; }

        public string? smartLink { get; set; }

        public string? statusName { get; set; } //TODO: Найти все значения и заменить на enum

        public string? title { get; set; }

        public string? tocNodeId { get; set; }

        [Obsolete]
        public string? url { get; set; }

        public static Pages_Page_Info? LoadFrom(string json)
        {
            return (Pages_Page_Info?)JsonSerializer.Deserialize(json,
                             typeof(Pages_Page_Info), CommonData.p_JsonSerializerOptions_Read);
        }
    }
}
