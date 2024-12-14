using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifyImagesBorder
{
    internal class InputArgs
    {
        public string? Storage_path { get; set; }

        public string? ImageExtension { get; set; } = ".jpg";

        public Color? Color { get; set; } = System.Drawing.Color.FromArgb(0, 0, 0);

        public static Color ColorBlack => System.Drawing.Color.FromArgb(0, 0, 0);

        public int BorderSize { get; set; } = 1;

        public InputArgs(string storage_path)
        {
            Storage_path = storage_path;
        }
    }
}
