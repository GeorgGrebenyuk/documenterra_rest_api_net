using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DocTerraRestApiLib.Classes
{
    /// <summary>
    /// Описание поисковой выдачи поиска по порталу
    /// </summary>
    public class Search_ExplorePortal_Info
    {
        public string? assigneeUserName { get; set; }

        public string? body { get; set; }

        public DateTime? createdOn { get; set; }

        public string? ftsSnippetHtml { get; set; }

        public string? ftsTitleHtml { get; set; }

        public string? fullUrl { get; set; }

        public string? html { get; set; }

        public string? id { get; set; }

        public string? indexKeywords { get; set; }

        public DateTime? modifiedOn { get; set; }

        public string? ownerUserName { get; set; }

        public string? projectId { get; set; }

        public string? projectTitle { get; set; }

        [Obsolete]
        public string? projectUrl { get; set; }

        public string? smartLink { get; set; }

        public string? statusName { get; set; }

        public string? title { get; set; }

        public string? tocNodeId { get; set; }

        [Obsolete]
        public string? url { get; set; }

        public static Search_ExplorePortal_Info? LoadFrom(string json)
        {
            return (Search_ExplorePortal_Info?)JsonSerializer.Deserialize(json,
                             typeof(Search_ExplorePortal_Info), CommonData.p_JsonSerializerOptions_Read);
        }
    }
}
