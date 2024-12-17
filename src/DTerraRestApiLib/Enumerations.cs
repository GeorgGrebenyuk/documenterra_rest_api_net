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

    /// <summary>
    /// Варианты режимов обновления документации (для публикации)
    /// </summary>
    public enum UpdateModeVariant
    {
        FullReplace, // Полностью
        Partial //Частично
    }

    /// <summary>
    /// Варианты экспорта публикации в представление
    /// </summary>
    public enum PublicationFormatVariant
    {
        WebHelp,
        PureHtml,
        Chm,
        Pdf,
        Doc,
        Docx,
        Rtf,
        Epub,
        Mht,
        Odt
    }

    /// <summary>
    /// Варианты формата файла
    /// </summary>
    public enum FormatVariant
    {
        base64
    }

    /// <summary>
    /// Тип действия, примененного к странице
    /// </summary>
    public enum actionTypeVariant
    {
        _None,
        DirectNavigation,
        FromToc,
        FromIndex,
        FromSearch,
        FromContextHelp
    }


    public enum StatusVariant
    {
        draft
    }

}
