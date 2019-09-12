using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_To_Hex
{
    public class ExtensionInfo
    {
        public string Extension { get; set; }
        public bool IsChecked { get; set; }

        public ExtensionInfo(string extension)
        {
            Extension = extension;
        }
    }
}
