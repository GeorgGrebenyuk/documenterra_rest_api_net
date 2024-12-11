using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocTerraRestApiLib.Enumerations
{
    /// <summary>
    /// Варианты видимости публикации
    /// </summary>
    public enum PublicationVisibilityVariant
    {
        Public, // Открытая
        Private, // Закрытая
        Restricted //Ограниченная
    }

    public enum UpdateModeVariant
    {
        FullReplace,
        Partial
    }


}
