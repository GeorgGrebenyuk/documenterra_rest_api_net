using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocTerraRestApiLib.Classes
{
    /// <summary>
    /// Вспомогательный класс для задания входных данных параметров поискового запроса по порталу
    /// </summary>
    public class Search_ExplorePortal_Arguments
    {
        public int count { get; set; } = 10;

        [Obsolete]
        private string? projectUrls { get; set; }

        public string? projectIds { get { return string.Join(",", projectIds0 ?? new string[] { }); } }
        public string[] projectIds0 { get; set; } = new string[] { };

        public string? lang { get; set; }

        public int? isReturnSnippets { get; set; }

        public string q { get; set; }
    }
}
