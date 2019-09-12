using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_To_Hex
{
    public class ExtensionGroup
    {
        public string Name { get; set; }
        public ObservableCollection<ExtensionInfo> ExtensionInfos { get; set; }
    }
}
